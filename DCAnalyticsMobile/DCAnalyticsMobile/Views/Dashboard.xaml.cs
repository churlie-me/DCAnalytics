using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Utils;
using DCAnalyticsMobile.Views.Popups;
using GeoJSON.Net.Geometry;
using Newtonsoft.Json;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Configuration = DCAnalyticsMobile.Models.Configuration;
using Naxam.Controls.Forms;
using Naxam.Mapbox.Annotations;
using Naxam.Mapbox;
using DCAnalyticsMobile.Data;

namespace DCAnalyticsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage, PromptPageState, QuestionairePageState, ConfigurationPageState, LocationPageState
    {
        private FileData filedata;
        public Configuration configuration;
        public List<SQLiteQuestionaire> sQLiteQuestionaires = new List<SQLiteQuestionaire>();
        public List<Questionaire> savedQuestionaires = new List<Questionaire>();
        public List<QItem> qItems = new List<QItem>(); 
        private Location location;
        public User User;
        private Questionaire sQuestionaire, questionaire;
        private ObservableCollection<Annotation> annotations = new ObservableCollection<Annotation>();
        private ILocationService service = new LocationService();
        private bool canPressBackButton = false, initialize = true;
        private bool LocationEnableSessionActive = false;

        public Dashboard(string Title = null)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Title))
                this.Title = Title;
            else
                Title = "Dashboard";
        }

        private SelectQuestionaire selectQuestionaire;
        private async void PromptQuestionaireSelection()
        {
            try
            {
                selectQuestionaire = new SelectQuestionaire(configuration, this);
                await PopupNavigation.Instance.PushAsync(selectQuestionaire, true);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

        private SelectCategory selectCategory;
        private async void PromptCategorySelection()
        {
            try
            {
                selectCategory = new SelectCategory(questionaire, this);
                await PopupNavigation.Instance.PushAsync(selectCategory, true);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

        private SelectConfiguration selectConfiguration;
        private void PromptConfigurationSelection()
        {
            try
            {
                selectConfiguration = new SelectConfiguration(this);
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(selectConfiguration, true));
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

        private async void OnQuestionaireTapped(object sender, ItemTappedEventArgs args)
        {
            try
            {
                questionaire = configuration.Questionaires.Find(q => q.Key == (args.Item as QItem).ID);
       
                if(questionaire.Regions==null)
                    questionaire.Regions = new List<Models.Region>();
                if(questionaire.Categories.Count > 0 || questionaire.Regions.Count > 0)
                    await Navigation.PushAsync(new Starter(questionaire, null, this));
                else
                    await Navigation.PushAsync(new QSections(DCAnalytics.ObjectType.None, questionaire, this));
            }
            catch (Exception ex)
            {
                Log.Warning("Existing Questionaire", ex.Message);
            }
        }

        private void Init()
        {
            try
            {
                configuration = AiDataStore.GetConfiguration();
                User = AiDataStore.GetUser();

                var qns = configuration.Questionaires.Where(x => x.Status == DCAnalytics.Statuses.Partial || x.Status == DCAnalytics.Statuses.Completed).ToList();
                questionaires.IsVisible = false;
                noquestionaires.IsVisible = false;
                progressIndicator.IsVisible = true;
                (progressIndicator.Children[0] as ActivityIndicator).IsRunning = true;

                sQLiteQuestionaires.Clear();
                sQLiteQuestionaires = new DatabaseManager().GetSQLiteQuestionaires();

                savedQuestionaires.Clear();
                annotations.Clear();

                qItems.Clear();
                if (qns.Count > 0)
                    foreach (Questionaire qn in qns)
                    {
                        annotations.Add(new SymbolAnnotation
                        {
                            Coordinates = new LatLng(qn.Latitude, qn.Longitude),
                            IconImage = (ImageSource)"ic_marker.png",
                            IconSize = 1,
                            IconColor = Color.Green
                        });

                        qItems.Add(new QItem
                        {
                            ID = qn.Key,
                            Distance = (location != null) ? Location.CalculateDistance(qn.Latitude, qn.Longitude, location, DistanceUnits.Kilometers) : 0,
                            Name = (qn.Sections.FirstOrDefault().Questions.FirstOrDefault().Answers.Count() > 0)? qn.Sections.FirstOrDefault().Questions.FirstOrDefault().Answers.FirstOrDefault().AnswerText : qn.Key,
                            Sequence = (qns.IndexOf(qn) % 2 == 0) ? 0 : 1
                        });
                    }

                progressIndicator.IsVisible = false;
                (progressIndicator.Children[0] as ActivityIndicator).IsRunning = false;

                //if no questionaires are saved
                if (qItems.Count == 0)
                {
                    noquestionaires.IsVisible = true;
                    nextPageFAB.IsVisible = false;
                    questionaires.IsVisible = false;
                }
                else
                {
                    map.ZoomLevel = Device.RuntimePlatform == Device.Android ? 10 : 17;
                    map.LogoEnabled = false;
                    map.CompassEnabled = true;
                    map.ShowUserLocation = true;
                    map.Annotations = annotations;
                    if (location != null)
                        map.Center = new LatLng(location.Latitude, location.Longitude);

                    questionaires.IsVisible = true;
                    nextPageFAB.IsVisible = true;
                    questionaires.ItemsSource = null;
                    questionaires.ItemsSource = qItems;
                }
            }
            catch (Exception ex)
            {
                Log.Warning("SqlLite Exception ", ex.Message);
            }
        }

        private async void InitUserCoordinates()
        {
            try
            {
                if (location != null)
                {
                    questionaire.Longitude = location.Longitude;
                    questionaire.Latitude = location.Latitude;

                    if (questionaire.Regions == null)
                        questionaire.Regions = new List<Models.Region>();

                    if (questionaire.Categories.Count > 0 || questionaire.Regions.Count > 0)
                        await Navigation.PushAsync(new Starter(questionaire, null, this));
                    else
                        await Navigation.PushAsync(new QSections(DCAnalytics.ObjectType.None, questionaire, this));
                }
                else
                {
                    await PopupNavigation.Instance.PushAsync(new MessageBox("Your Gps location could not be extracted, make sure your gps is turned on and try again", MessageType.Gps, this, this));
                }
            }
            catch (Exception ex)
            {
                Log.Warning("GPS EXCEPTION", ex.Message);
            }
        }

        private async void InitUserLocation()
        {
            try
            {
                location = await GeolocationManager.GetLocationAsync();
                Init();
            }
            catch(Exception ex)
            {
                Log.Warning("GPS EXCEPTION", ex.Message);
            }
        }

        private GeolocationManager GeolocationManager;
        protected async override void OnAppearing()
        {
            try
            {
                GeolocationManager = new GeolocationManager(this);
                var enabled = await GeolocationManager.IsGpsEnabledAsync();
                if (enabled)
                {
                    InitUserLocation();
                }
                else
                    await PopupNavigation.Instance.PushAsync(new MessageBox("Your Gps position could not be extracted, please turn on your gps and please ensure you have internet before you try again", MessageType.Gps, this, this));
            }
            catch(Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this, this));
            }
        }

        private async void StartQuestionaire(object sender, EventArgs args)
        {
            try
            {
                if (configuration == null)
                {
                    await PopupNavigation.Instance.PushAsync(new MessageBox("You have no configuration attached, please attach one and try again", MessageType.Configuration, this));
                    return;
                }

                if (configuration.Questionaires.Where(x => x.Status == DCAnalytics.Statuses.Template).ToList().Count > 1)
                {
                    PromptQuestionaireSelection();
                }
                else if (configuration.Questionaires.Where(x => x.Status == DCAnalytics.Statuses.Template).ToList().Count == 1)
                {
                    sQuestionaire = configuration.Questionaires[0];
                    StartNewQuestionaire();
                }
                else
                {
                    await PopupNavigation.Instance.PushAsync(new MessageBox("Your configuration has no questionaires, please attach one that has and try again", MessageType.Configuration, this));
                    return;
                }
            }
            catch (Exception ex)
            {
                Log.Warning("Questionaire Error", ex.StackTrace);
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.Message, MessageType.Regular, this));
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return canPressBackButton;
        }

        private LocationDialog locationDialog;
        private async void StartNewQuestionaire()
        {
            try
            {
                questionaire = new Questionaire
                {
                    Name = sQuestionaire.Name,
                    CreatedBy = User.Key,
                    IsSystem = sQuestionaire.IsSystem,
                    Categories = sQuestionaire.Categories,
                    Regions = sQuestionaire.Regions,
                    TableName = sQuestionaire.TableName,
                    Sections = sQuestionaire.Sections,
                    Template = sQuestionaire.Key
                };
                questionaire.Sections.SelectMany(s => s.Questions).ForEach(q => q.Answers.Clear());

                if (questionaire.Categories.Count > 0)
                    PromptCategorySelection();
                else
                {
                    canPressBackButton = true;
                    locationDialog = new LocationDialog(this);
                    await PopupNavigation.Instance.PushAsync(locationDialog);
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        public void OnResumePage(object o)
        {
            try
            {
                this.filedata = (FileData)o;
                DeserializeConfiguration();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void DeserializeConfiguration()
        {
            try
            {
                string json = System.IO.File.ReadAllText(filedata.FilePath).Replace("\r\n", string.Empty).Replace("\t", string.Empty).Replace("  ", String.Empty); ;
                json = Regex.Unescape(json).Replace(@"\s+", "");
                configuration = JsonConvert.DeserializeObject<Configuration>(json);

                if (configuration != null)
                    InitQuestionaires();
            }
            catch (Exception ex)
            {
                Log.Warning("Configuration Deserialization Exception", ex.StackTrace);
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("Your configuration has an issue, please load another one to proceed", MessageType.Regular, this)));
            }
        }

        private void InitQuestionaires()
        {
            if (configuration.Questionaires.Count > 1)
                PromptQuestionaireSelection();
            else if (configuration.Questionaires.Count == 1)
                sQuestionaire = configuration.Questionaires[0];
        }

        SpecifyRole specifyRole;
        private void SelectRole(object sender, EventArgs args)
        {
            try
            {
                specifyRole = new SpecifyRole(this);
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(specifyRole));
            }
            catch (Exception ex)
            {
                Log.Warning("Role Selection Issue", ex.Message);

            }
        }

        public void OnSleepPage()
        {

        }

        public void OnRebound()
        {
            PromptConfigurationSelection();
        }

        public void OnRetrieve()
        {
            Init();
        }

        public void ChangeConfiguration(object sender, EventArgs args)
        {
            PromptConfigurationSelection();
        }

        public void ChangeQuestionaire(object sender, EventArgs args)
        {
            try
            {
                if (configuration.Questionaires.Count > 0)
                    PromptQuestionaireSelection();
            }
            catch (Exception ex)
            {

            }
        }

        private Questionaire _template;
        private void OnRefreshQuestionaires(object sender, EventArgs args)
        {
            try
            {
                _template = configuration.Questionaires.Find(q => q.Status == DCAnalytics.Statuses.Template);
                Task.Factory.StartNew(async () => {
                    var response = Synchronization.GetModifiedQuestionaire(_template.OID).Result;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    questionaire = JsonConvert.DeserializeObject<Questionaire>(responseContent);
                }).ContinueWith(task => {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (questionaire != null)
                        {
                            configuration.Questionaires[configuration.Questionaires.IndexOf(_template)] = questionaire;
                            AiDataStore.SaveConfiguration(configuration);
                            RefreshQuestionaires(questionaire);
                        }
                        else
                            Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("Something went wrong, please try again", MessageType.Regular, this)));
                    });
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch(Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("Something went wrong, please try again", MessageType.Regular, this)));
            }
        }

        //Add conditions into the loop
        void RefreshQuestionaires(Questionaire questionaire)
        {
            try
            {
                configuration.Questionaires.Where(x => x.Status == DCAnalytics.Statuses.Completed || x.Status == DCAnalytics.Statuses.Partial)
                                           .ForEach(q =>
                                           {

                                               for (int s = q.Sections.Count - 1; s >= 0; s--)
                                               {
                                                   var section = questionaire.Sections.Find(a => a.Key == q.Sections[s].Key);
                                                   if (section != null)
                                                   {
                                                       q.Sections[s].Name = section.Name;
                                                       for (int qn = q.Sections[s].Questions.Count - 1; qn >= 0; qn--)
                                                       {
                                                           var _question = section.Questions.Find(_q => _q.Key == q.Sections[s].Questions[qn].Key);
                                                           if (_question != null)
                                                           {
                                                               RefreshQuestion(q.Sections[s].Questions[qn], _question);
                                                           }
                                                           else
                                                               q.Sections[s].Questions.Remove(q.Sections[s].Questions[qn]);
                                                       }

                                                       //Get new questions
                                                       var newQns = section.Questions.Where(_new => q.Sections[s].Questions.All(_old => _old.OID != _new.OID)).ToList();
                                                       for (int n = newQns.Count - 1; n >= 0; n--)
                                                           //place question at the same index as that of the template
                                                           q.Sections[s].Questions.Insert(section.Questions.IndexOf(newQns[n]), newQns[n]);
                                                   }
                                                   else
                                                       q.Sections.Remove(q.Sections[s]);

                                                   //Get new sections
                                                   var newSections = questionaire.Sections.Where(_new => q.Sections.All(_old => _old.OID != _new.OID)).ToList();
                                                   for (int n = newSections.Count - 1; n >= 0; n--)
                                                       //place section at the same index as that of the template
                                                       q.Sections.Insert(questionaire.Sections.IndexOf(newSections[n]), newSections[n]);


                                                   //SubSection
                                                   for (int j = q.Sections[s].SubSections.Count - 1; j >= 0; j--)
                                                   { 
                                                       var subsection = section.SubSections.Find(sb => sb.Key == q.Sections[s].SubSections[j].Key);
                                                       if (subsection != null)
                                                       {
                                                           q.Sections[s].SubSections[j].Name = subsection.Name;

                                                           for (int qn = q.Sections[s].SubSections[j].Questions.Count - 1; qn >= 0; qn--)
                                                           {
                                                               var _question = subsection.Questions.Find(_q => _q.Key == q.Sections[s].SubSections[j].Questions[qn].Key);
                                                               if (_question != null)
                                                               {
                                                                   RefreshQuestion(q.Sections[s].SubSections[j].Questions[qn], _question);
                                                               }
                                                               else
                                                                   q.Sections[s].SubSections[j].Questions.Remove(q.Sections[s].SubSections[j].Questions[qn]);
                                                           }

                                                           //Get new subsection questions
                                                           var newQns = subsection.Questions.Where(_new => q.Sections[s].SubSections[j].Questions.All(_old => _old.OID != _new.OID)).ToList();
                                                           for (int n = newQns.Count - 1; n >= 0; n--)
                                                               //place subsection question at the same index as that of the template
                                                               q.Sections[s].SubSections[j].Questions.Insert(subsection.Questions.IndexOf(newQns[n]), newQns[n]);
                                                       }
                                                       else
                                                           q.Sections[s].SubSections.Remove(q.Sections[s].SubSections[j]);
                                                   }

                                                   //Get new subsections
                                                   var newSubSections = section.SubSections.Where(_new => q.Sections[s].SubSections.All(_old => _old.OID != _new.OID)).ToList();
                                                   for (int n = newSubSections.Count - 1; n >= 0; n--)
                                                       //place subsection at the same index as that of the template
                                                       q.Sections[s].SubSections.Insert(section.SubSections.IndexOf(newSubSections[n]), newSubSections[n]);
                                               }
                                           });
            }
            catch(Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.Message, MessageType.Regular, this)));
            }
        }

        public void RefreshQuestion(Question oldQuestion, Question newQuestion)
        {
            try
            {
                oldQuestion.QuestionText = newQuestion.QuestionText;
                oldQuestion.Required = newQuestion.Required;
                oldQuestion.QuestionType = newQuestion.QuestionType;

                //Refresh Dependencies
                for(int i = oldQuestion.Dependencies.Count - 1; i >= 0; i--)
                {
                    var _d = newQuestion.Dependencies.Find(d => d.Key == oldQuestion.Dependencies[i].Key);
                    if (_d != null)
                    {
                        oldQuestion.Dependencies[i].TargetObjectKey = _d.TargetObjectKey;
                        oldQuestion.Dependencies[i].TargetObjectType = _d.TargetObjectType;
                        oldQuestion.Dependencies[i].Name = _d.Name;
                    }
                    else
                        oldQuestion.Dependencies.Remove(oldQuestion.Dependencies[i]); //remove all dependencies that were removed from the latest template questionaire
                }

                //Get new dependencies
                var newDependencies = newQuestion.Dependencies.Where(_new => oldQuestion.Dependencies.All(_old => _old.OID != _new.OID)).ToList();
                for (int n = newDependencies.Count - 1; n >= 0; n--)
                    //place dependency at the same index as that of the template
                    oldQuestion.Dependencies.Insert(newQuestion.Dependencies.IndexOf(newDependencies[n]), newDependencies[n]);


                //Refresh Conditions
                for (int i = oldQuestion.Conditions.Count - 1; i >= 0; i--)
                {
                    var _c = newQuestion.Conditions.Find(c => c.Key == oldQuestion.Conditions[i].Key);
                    if (_c != null)
                    {
                        oldQuestion.Conditions[i].Target = _c.Target;
                        oldQuestion.Conditions[i].AttributeKey = _c.AttributeKey;
                        oldQuestion.Conditions[i].CollectionObjectType = _c.CollectionObjectType;
                        oldQuestion.Conditions[i].DataCollectionObectType = _c.DataCollectionObectType;
                        oldQuestion.Conditions[i].Answer = _c.Answer;
                        oldQuestion.Conditions[i].Name = _c.Name;
                    }
                    else
                        oldQuestion.Conditions.Remove(oldQuestion.Conditions[i]); //remove all conditions that were removed from the latest template questionaire
                }

                //Get new conditions
                var newConditions = newQuestion.Conditions.Where(_new => oldQuestion.Conditions.All(_old => _old.OID != _new.OID)).ToList();
                for (int c = newConditions.Count - 1; c >= 0; c--)
                    //place conditions at the same index as that of the template
                    oldQuestion.Conditions.Insert(newQuestion.Conditions.IndexOf(newConditions[c]), newConditions[c]);

            }
            catch(Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.Message, MessageType.Regular, this)));
            }
        }

        public void OnExit()
        {
            Init();
        }

        public void OnQuestionaireSelected(Questionaire questionaire)
        {
            sQuestionaire = questionaire;
            StartNewQuestionaire();
        }

        public void Profile()
        {
            try
            {
                Task.Run(async () => await Navigation.PushAsync(new Profile()));
            }
            catch (Exception ex)
            {

            }
        }

        private void SelectCertification(object sender, EventArgs args)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        public void OnCertificationSelected(Certification questionaire)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        public async void OnPurchaseRoleSeleted()
        {
            try
            {
                await PopupNavigation.Instance.RemovePageAsync(specifyRole);
            }
            catch (Exception ex)
            {

            }
        }

        public async void OnTrainingRoleSeleted()
        {
            try
            {
                await PopupNavigation.Instance.RemovePageAsync(specifyRole);
                await Navigation.PushAsync(new Trainings());
            }
            catch (Exception ex)
            {

            }
        }

        public void OnCertificationRoleSeleted()
        {

        }

        public void OnFieldInspectionSelected()
        {
            throw new NotImplementedException();
        }

        public async void OnLocationCollected(Location location) //Plugin.Geolocator.Abstractions.Position position)
        {
            try
            {
                if (location != null)
                    this.location = location;

                canPressBackButton = false;
                await PopupNavigation.Instance.RemovePageAsync(locationDialog);

                InitUserCoordinates();
            }
            catch(Exception ex)
            {

            }
        }

        public void OnEnableLocation()
        {
            try
            {
                GeolocationManager.TurnOnLocation();
            }
            catch(Exception ex)
            {

            }
        }

        public async void OnCategorySelectedAsync(Category category)
        {
            try
            {
                questionaire.Category = category;
                canPressBackButton = true;
                locationDialog = new LocationDialog(this);
                await PopupNavigation.Instance.PushAsync(locationDialog);
            }
            catch(Exception ex)
            {

            }
        }

        public async void OnLocationIgnored()
        {
            try
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox("Your location has not been enabled, the app will now exit", MessageType.Exit, this));
                Navigation.RemovePage(this);
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.Message, MessageType.Exit, this));
            }
        }

        public void OnConfirm()
        {
            throw new NotImplementedException();
        }

        public void OnSaveDraft()
        {
            try{}catch (Exception ex){}
        }
    }
}