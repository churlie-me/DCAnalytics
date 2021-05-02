using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Views.Popups;
using Naxam.Mapbox;
using Naxam.Mapbox.Annotations;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Questionaires : TabbedPage, ConfigurationPageState, LocationPageState, PromptPageState
    {
        private ObservableCollection<Annotation> annotations = new ObservableCollection<Annotation>();
        private Configuration configuration;
        private Questionaire questionaire;
        private DCAnalytics.ObjectType ObjectType;
        private User User = AiDataStore.GetUser();
        private List<QItem> qItems = new List<QItem>();
        private List<Questionaire> qns = new List<Questionaire>();
        private Location location;
        private bool canPressBackButton = false;
        public Questionaires(DCAnalytics.ObjectType objectType, QuestionairePageState questionairePageState = null, string Title = null)
        {
            InitializeComponent();
            ObjectType = objectType;
            if (!string.IsNullOrEmpty(Title))
                this.Title = Title;
        }

        private void Init()
        {
            try
            {
                configuration = AiDataStore.GetConfiguration();
                qns.Clear();
                qns = configuration.Questionaires.Where(x => x.Status == DCAnalytics.Statuses.Partial || x.Status == DCAnalytics.Statuses.Completed).ToList();
                questionaires.IsVisible = false;
                noquestionaires.IsVisible = false;
                progressIndicator.IsVisible = true;
                (progressIndicator.Children[0] as ActivityIndicator).IsRunning = true;

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
                            Name = qn.Sections.FirstOrDefault().Questions.Find(x => x.QuestionText == "Name").Answers.FirstOrDefault().AnswerText,
                            Sequence = (qns.IndexOf(qn) % 2 == 0) ? 0 : 1
                        });
                    }

                progressIndicator.IsVisible = false;
                (progressIndicator.Children[0] as ActivityIndicator).IsRunning = false;

                //if there are no questionees
                if (qItems.Count == 0)
                {
                    noquestionaires.IsVisible = true;
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
                    questionaires.ItemsSource = null;
                    questionaires.ItemsSource = qItems;
                }
            }
            catch (Exception ex)
            {
                Log.Warning("Exception : ", ex.Message);
            }
        }

        private void SearchBar_TextChanged(object sender, TappedEventArgs args)
        {

        }

        QuestionaireBrief questionaireBrief;
        private async void OnQuestionaireTapped(object sender, ItemTappedEventArgs args)
        {
            var qItem = args.Item as QItem;
            questionaire = qns.Find(q => q.Key == qItem.ID);
            try
            {
                if (ObjectType == DCAnalytics.ObjectType.Certification && configuration.Certifications.Count > 0)
                {
                    selectCertificates = new Certificates(configuration, questionaire, this);
                    await PopupNavigation.Instance.PushAsync(selectCertificates, true);
                }
                else if (ObjectType == DCAnalytics.ObjectType.Inspection && configuration.Inspections.Count > 0)
                {
                    questionaireBrief = new QuestionaireBrief(DCAnalytics.ObjectType.Inspection, questionaire, this);
                    await PopupNavigation.Instance.PushAsync(questionaireBrief, true);
                }
                else
                    await PopupNavigation.Instance.PushAsync(new MessageBox("The module you're attempting to access has no entities required to proceed, please contact admin for a possible solution", MessageType.Regular, this, null));
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true);
            }
        }

        private async void InitUserCoordinates()
        {
            if (location != null)
            {
                Init();
            }
            else
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox("Your Gps position could not be extracted, please turn on your gps and please ensure you have internet before you try again", MessageType.Gps, this, this));
            }
        }

        public async void OnLocationCollected(Location location) //Plugin.Geolocator.Abstractions.Position position)
        {
            try
            {
                //this.location = location;

                if (location != null)
                    this.location = location;
            }
            catch (Exception ex)
            {

            }
        }

        protected override bool OnBackButtonPressed()
        {
            return canPressBackButton;
        }

        public async void OnResumePage(object o)
        {
            try
            {
                //await Navigation.PushAsync(new QSections(DCAnalytics.ObjectType.None, questionaire));
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true);
            }
        }

        public void OnSleepPage()
        {
            throw new NotImplementedException();
        }

        public void OnRebound()
        {
            throw new NotImplementedException();
        }

        public void OnExit()
        {
            
        }

        public void OnConfirm()
        {
            throw new NotImplementedException();
        }

        public async void OnPurchaseRoleSeleted()
        {
            try
            {
                await PopupNavigation.Instance.RemovePageAsync(questionaireBrief);
                await Navigation.PushAsync(new Purchases(questionaire));
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true);
            }
        }

        private LocationDialog locationDialog;
        protected async void InitUserLocation()
        {
            try
            {
                location = await GeolocationManager.GetLocationAsync();

                if (location != null)
                    InitUserCoordinates();
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true);
            }
        }

        private GeolocationManager GeolocationManager;
        protected async override void OnAppearing()
        {
            GeolocationManager = new GeolocationManager(this);
            if (GeolocationManager.IsGpsEnabledAsync().Result)
                InitUserLocation();
            else
                await PopupNavigation.Instance.PushAsync(new MessageBox("Your Gps position could not be extracted, please turn on your gps and please ensure you have internet before you try again", MessageType.Gps, this, this));
        }

        public async void OnTrainingRoleSeleted()
        {
            await PopupNavigation.Instance.RemovePageAsync(questionaireBrief);
        }

        Certificates selectCertificates;
        public void OnCertificationRoleSeleted()
        {

        }

        public async void OnCertificationSelected(Certification certification)
        {
            try
            {
                await PopupNavigation.Instance.RemovePageAsync(selectCertificates);
                if(certification.Sections.Count > 0 || certification.Sections.SelectMany(x => x.Questions).Count() > 0)
                    await Navigation.PushAsync(new QSections(DCAnalytics.ObjectType.None, questionaire, null, certification));
                else
                    await PopupNavigation.Instance.PushAsync(new MessageBox("This certificcation is incomplete, please contact admin for more information", MessageType.Exit, this), true);
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true);
            }
        }

        public async void OnFieldInspectionSelected()
        {
            try
            {
                await PopupNavigation.Instance.RemovePageAsync(questionaireBrief);
                await Navigation.PushAsync(new Fields(questionaire));
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true);
            }
        }

        public void OnEnableLocation()
        {
            GeolocationManager.TurnOnLocation();
        }

        public async void OnLocationIgnored()
        {
            try
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox("Your location has not been enabled, the app will now exit", MessageType.Exit, this));
                Navigation.RemovePage(this);
            }
            catch(Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.Message, MessageType.Exit, this));
            }
        }

        public void OnSaveDraft()
        {
            throw new NotImplementedException();
        }
    }
}