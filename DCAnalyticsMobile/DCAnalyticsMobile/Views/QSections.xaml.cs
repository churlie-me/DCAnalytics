using DCAnalyticsMobile.Controls;
using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Utils;
using DCAnalyticsMobile.Views.Popups;
using Newtonsoft.Json;
using Plugin.FilePicker.Abstractions;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Location = Xamarin.Essentials.Location;

namespace DCAnalyticsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QSections : ContentPage, SelectPageState, PromptPageState, PicturePageState, LocationPageState
    {
        private static UIControls controls;
        private StackLayout sectionStack;
        public static QuestionaireStatus _questionaireStatus, certificationStatus, inspectionStatus;
        public static List<SectionView> sectionViews;
        public static Questionaire questionaire;
        public static Certification certification;
        public static FieldInspection FieldInspection;
        private SectionView _sectionView;
        private static int index = 0;
        private static SelectPageState selectPageState;
        public static PicturePageState picturePageState;
        public static LocationPageState locationPageState;
        private DatabaseManager _dbManager;
        private SQLiteQuestionaire sQLiteQuestionaire;
        private QuestionairePageState questionairePageState;
        private static PromptPageState promptPageState;
        private DCAnalytics.ObjectType ObjectType;
        private static List<string> dependencies = new List<string>();
        private static List<string> navigatedTargetSections = new List<string>();
        private User user;
        private Configuration configuration;
        private static AIDropdown aIDropdown;
        public static List<Section> Sections = new List<Section>();
        public static string TargetSection;
        private static bool isValid;
        public QSections(DCAnalytics.ObjectType objectType, Questionaire _questionaire, QuestionairePageState questionairePageState = null, Certification _certification = null, FieldInspection _fieldInspection = null)
        {
            InitializeComponent();
            controls = new UIControls(this);
            ObjectType = objectType;
            selectPageState = this;
            promptPageState = this;
            picturePageState = this;
            locationPageState = this;
            questionaire = null;
            questionaire = _questionaire;
            FieldInspection = _fieldInspection;
            certification = _certification;
            Title = questionaire.Name;
            this.questionairePageState = questionairePageState;
            sectionViews = new List<SectionView>();
            _questionaireStatus = string.IsNullOrEmpty(questionaire.Key) ? QuestionaireStatus.Create : QuestionaireStatus.Modify;
            _dbManager = new DatabaseManager();
            user = AiDataStore.GetUser();
            configuration = AiDataStore.GetConfiguration();
            isValid = true;

            Sections.Clear();
            Sections = (FieldInspection != null) ?
                                FieldInspection.Sections:
                                (certification != null) ?
                                certification.Sections:
                                questionaire.Sections;
            dependencies.Clear();
            navigatedTargetSections.Clear();
            controls.targets.Clear();
            Init();
        }

        private void Init()
        {
            try
            {
                index = 0;
                if (certification != null)
                {
                    certificationStatus = string.IsNullOrEmpty(certification.Key) ? QuestionaireStatus.Create : QuestionaireStatus.Modify;
                    if (string.IsNullOrEmpty(certification.Key))
                    {
                        certification.Key = Guid.NewGuid().ToString();
                        certification.DateTime = DateTime.Now;
                        certification.Key = Guid.NewGuid().ToString();
                        certification.FarmerKey = questionaire.Key;
                    }

                    foreach (Section section in Sections)
                    {
                        InitSection(section);
                        index++;
                    }
                }
                else if(FieldInspection != null)
                { 
                    foreach (Section section in Sections)
                    {
                        InitSection(section);
                        index++;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(questionaire.Key))
                    {
                        questionaire.DateTime = DateTime.Now;
                        questionaire.Key = Guid.NewGuid().ToString();
                    }

                    foreach (Section section in Sections)
                    {
                        InitSection(section);
                        index++;
                    }
                }

                if (sectionViews.Count > 0)
                {
                    index = 0;
                    if (user.UserRights.Count > 0)
                    {
                        if (user.UserRights.FirstOrDefault().ObjectType.Equals(DCAnalytics.ObjectType.Section))
                        {
                            var section = questionaire.Sections.Find(x => x.Key == user.UserRights.FirstOrDefault().PrimaryKey);
                            index = questionaire.Sections.IndexOf(section);
                        }
                        else if (user.UserRights.FirstOrDefault().ObjectType.Equals(DCAnalytics.ObjectType.Inspection))
                        {
                            var section = questionaire.Sections.Find(x => x.Key == user.UserRights.FirstOrDefault().PrimaryKey);
                            index = questionaire.Sections.IndexOf(section);
                        }
                        else
                        {
                            index = (ObjectType == DCAnalytics.ObjectType.Inspection) ? 0 : 0;
                        }
                    }

                    questionaireStack.Children.Clear();
                    questionaireStack.Children.Add(sectionViews[index].ContentView);
                    sectionTitle.Text = (FieldInspection != null)? FieldInspection.Sections[index].Name: ((certification != null) ? certification.Sections[index].Name: questionaire.Sections[index].Name);
                    next.IsVisible = true;
                }

                if (ObjectType.Equals(DCAnalytics.ObjectType.Certification)
                    || ObjectType.Equals(DCAnalytics.ObjectType.Section)
                    || ObjectType.Equals(DCAnalytics.ObjectType.Subsection))
                    this.ToolbarItems.Clear();
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
            }
        }

        private void InitSection(Section section)
        {
            try
            {
                _sectionView = new SectionView();
                _sectionView.Key = section.Key;
                _sectionView.ContentView = new ContentView {  };
                var contentStack = new StackLayout
                {
                    Orientation = StackOrientation.Vertical
                };

                sectionStack = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Padding = new Thickness(20, 0, 20, 10)
                };

                if (!string.IsNullOrEmpty(section.Description))
                {
                    var descriptionFrame = new Frame
                    {
                        Padding = new Thickness(10, 10, 10, 10),
                        BackgroundColor = Color.White
                    };
                    var description = new Label
                    {
                        Text = section.Description,
                        FontSize = 16
                    };
                    descriptionFrame.Content = description;
                    var descStack = new StackLayout() { HorizontalOptions = LayoutOptions.Fill };
                    descStack.Children.Add(descriptionFrame);
                    contentStack.Children.Add(descStack);
                }

                sectionViews.Add(_sectionView);

                InitSectionQuestions(section);

                //Goto questions in each sub section
                if (section.SubSections.Count > 0)
                    foreach (SubSection subSection in section.SubSections)
                    {
                        if (!dependencies.Contains(subSection.Key))
                            InitSubSection(subSection, sectionStack);
                    }
                        

                contentStack.Children.Add(sectionStack);
                sectionViews[index].ContentView.Content = contentStack;
            }
            catch (Exception ex)
            {
                Task.Run(async() => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
            }
        }

        public static void InitSubSection(SubSection subSection, StackLayout sectionStack, int Occurance = 0)
        {
            try
            {
                StackLayout subSectionStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.Fill,
                    IsVisible = !controls.targets.Contains(subSection.Key),
                    ClassId = subSection.Key
                };
                StackLayout stackLayout = new StackLayout
                {
                    ClassId = subSection.Key,
                    Padding = new Thickness(0, 10, 0, 10),
                    HorizontalOptions = LayoutOptions.Fill
                };
                Label lbl = new Label
                {
                    Text = subSection.Name + " (SubSection)",
                    FontSize = 18
                };
                stackLayout.Children.Add(lbl);
                stackLayout.Children.Add(new BoxView
                {
                    HeightRequest = 2,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Color = Color.Black
                });
                subSectionStackLayout.Children.Add(stackLayout);

                foreach (Question qn in subSection.Questions)
                    InitQuestion(qn, subSectionStackLayout, Occurance);

                sectionStack.Children.Add(subSectionStackLayout);
            }
            catch(Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        private void InitSectionQuestions(Section section)
        {
            try
            {
                foreach (Question question in section.Questions)
                {
                    InitQuestion(question, sectionStack);
                }
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
            }
        }

        /// <summary>
        /// <param name="question"></param>
        /// <param name="holder"></param>
        /// </summary>
        public static void InitQuestion(Question question, StackLayout holder, int occurance = 0)
        {
            try
            {
                if (question.Conditions != null)
                    foreach (var condition in question.Conditions)
                    {
                        if (condition.Target != null)
                            switch (condition.DataCollectionObectType)
                            {
                                case DCAnalytics.DataCollectionObectTypes.Question:
                                    controls.targets.Add(condition.Target.Question.Key);
                                    break;
                                case DCAnalytics.DataCollectionObectTypes.SubSection:
                                    controls.targets.Add(condition.Target.SubSection.Key);
                                    break;
                                case DCAnalytics.DataCollectionObectTypes.Section:
                                    controls.targets.Add(condition.Target.Section.Key);
                                    break;
                            }
                    }

                if (question.Dependencies != null)
                    if (question.Dependencies.Count > 0)
                        dependencies.AddRange(question.Dependencies.Select(x => x.TargetObjectKey).ToList());

                switch (question.QuestionType)
                {
                    case DCAnalytics.QuestionTypes.Open:
                        if (question.DataType == DCAnalytics.DataTypes.Date)
                            controls.DateTimeControl(question, holder, occurance);
                        else if (question.DataType == DCAnalytics.DataTypes.Image)
                            controls.ImageControl(question, holder, occurance);
                        else if (question.DataType == DCAnalytics.DataTypes.TextBlock)
                            controls.EditorControl(question, holder, occurance);
                        else
                            controls.EntryControl(question, holder, occurance);
                        break;
                    case DCAnalytics.QuestionTypes.Closed:
                        if (question.EnumList.EnumValues.Count == 2)
                            controls.SwitchControl(question, holder, occurance);
                        else if (question.EnumList.EnumValues.Count > 15)
                            controls.DropDownControl(question, holder, occurance);
                        else
                            controls.SingleSelect(question, holder, occurance);
                        break;
                    case DCAnalytics.QuestionTypes.MultipleChoice:
                        controls.MultiSelect(question, holder, occurance);
                        break;
                    case DCAnalytics.QuestionTypes.Map:
                        controls.MapControl(question, holder, occurance);
                        break;
                    case DCAnalytics.QuestionTypes.Location:
                        controls.LocationControl(question, holder, occurance);
                        break;
                    case DCAnalytics.QuestionTypes.Other:
                        controls.DateTimeControl(question, holder, occurance);
                        break;
                }
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        List<SQLiteQuestionaire> sqliteQuestionaires;
        private void OnRemove(object sender, EventArgs args)
        {
            try
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if(!string.IsNullOrEmpty(questionaire.Key))
                        await PopupNavigation.Instance.PushAsync(new MessageBox("Are you sure you would like to delete this questionaire?", MessageType.Warning, this));
                });
            }
            catch(Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
            }
        }

        public void OnConfirm()
        {
            try
            {
                configuration.Questionaires.Remove(configuration.Questionaires.Find(x => x.Key == questionaire.Key));
                AiDataStore.SaveConfiguration(configuration);
                Navigation.RemovePage(this);
            }
            catch(Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
            }
        }

        private void Previous(object sender, EventArgs args)
        {
            try
            {
                if (navigatedTargetSections.Count > 1 && navigatedTargetSections.Contains(sectionViews[index].Key))
                {
                    index = Sections.IndexOf(Sections.Find(s => s.Key == navigatedTargetSections[navigatedTargetSections.Count - 2]));
                    TargetSection = navigatedTargetSections[navigatedTargetSections.Count - 1];
                    navigatedTargetSections.RemoveAt(navigatedTargetSections.Count - 2);//remove current
                    navigatedTargetSections.RemoveAt(navigatedTargetSections.Count - 1);//remove previous 
                }
                else
                    index--;


                questionaireStack.Children.Clear();
                questionaireStack.Children.Add(sectionViews[index].ContentView);
                sectionTitle.Text = (FieldInspection != null) ? FieldInspection.Sections[index].Name : ((certification != null) ? certification.Sections[index].Name : questionaire.Sections[index].Name);

                if (index == 0)
                    previous.IsVisible = false;
            }
            catch(Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
            }
        }

        private async void Next(object sender, EventArgs args)
        {
            try
            {
                next.IsEnabled = false;
                questionaireStack.IsEnabled = false;
                nextIcon.IsVisible = false;
                processIndicatior.IsVisible = true;
                processIndicatior.IsRunning = true;
                if (ValidateSection())
                {
                    SaveQuestionaire();

                    if (ObjectType == DCAnalytics.ObjectType.Section)
                    {
                        await Navigation.PushAsync(new SaveQuestionaire());
                        return;
                    }

                    if (index < (sectionViews.Count - 1))
                    {
                        if (!string.IsNullOrEmpty(TargetSection) && sectionViews[index].Key != TargetSection)
                        {
                            if (!navigatedTargetSections.Contains(sectionViews[index].Key))
                                navigatedTargetSections.Add(sectionViews[index].Key);

                            index = Sections.IndexOf(Sections.Find(s => s.Key == TargetSection));
                            navigatedTargetSections.Add(TargetSection);

                        }
                        else
                            index++;

                        if (controls.targets.Contains(sectionViews[index].Key))
                        {
                            if (index == (sectionViews.Count - 1) && string.IsNullOrEmpty(TargetSection))
                            {
                                await Navigation.PushAsync(new SaveQuestionaire());
                            }
                            else
                            {
                                questionaireStack.Children.Clear();
                                questionaireStack.Children.Add(sectionViews[index].ContentView);
                                sectionTitle.Text = Sections[index].Name;
                            }

                            TargetSection = string.Empty;
                        }
                        else
                        {
                            questionaireStack.Children.Clear();
                            questionaireStack.Children.Add(sectionViews[index].ContentView);
                            sectionTitle.Text = Sections[index].Name;
                        }
                    }
                    else
                    {
                        await Navigation.PushAsync(new SaveQuestionaire());
                    }
                }
                else
                {
                    await PopupNavigation.Instance.PushAsync(new MessageBox("You have incomplete required questions, add answers to them to proceed", MessageType.Regular, this), true);
                }

                next.IsEnabled = true;
                questionaireStack.IsEnabled = true;
                nextIcon.IsVisible = true;
                processIndicatior.IsVisible = false;
                processIndicatior.IsRunning = false;
                previous.IsVisible = true;
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true);
            }
        }

        private bool ValidateSection()
        {
            try
            {
                isValid = true;
                if (index < Sections.Count)
                {
                    Sections[index].Questions.ForEach(q => 
                    {
                        var qn = Sections[index].Questions.SelectMany(x => x.Conditions).Where(c => c.DataCollectionObectType == DCAnalytics.DataCollectionObectTypes.Question)
                                                          .Select(y => y.Target)
                                                          .Select(z => z.Question)
                                                          .Where(w => w.Key == q.Key).DefaultIfEmpty().FirstOrDefault();
                        if (qn != null)
                            if (qn.Answers.Count == 0)
                                return;
                       ValidateQuestion(q);
                    });

                    Sections[index].SubSections.ForEach(s =>    
                    { 
                        s.Questions.ForEach(q =>
                        {
                            var qn = s.Questions.SelectMany(x => x.Conditions).Select(y => y.Target).Select(z => z.Question).FirstOrDefault(w => w.Key == q.Key);
                            if (qn != null)
                                if (qn.Answers.Count == 0)
                                    return;
                            ValidateQuestion(q);
                        });
                    });
                }
            }
            catch(Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
            }

            return isValid;
        }

        void ValidateQuestion(Question question)
        {
            try
            {
                if (question.Dependencies.Count > 0 && question.Answers.Count > 0)
                {
                    var _dependencies = question.Dependencies.Where(x => x.Occurance != 0);
                    foreach (var dependency in _dependencies)
                    {
                        if (dependency.TargetObjectType.Equals(DCAnalytics.DataCollectionObectTypes.Question))
                            ValidateQuestion(dependency.Target.Question);
                        else if (dependency.TargetObjectType.Equals(DCAnalytics.DataCollectionObectTypes.SubSection))
                            dependency.Target.SubSection.Questions.ForEach(q =>
                            {
                                ValidateQuestion(q);
                            });
                    }
                }

                if (question.Conditions.Count > 0 && question.Answers.Count > 0)
                    foreach (var condition in question.Conditions)
                        if (question.Answers.Find(a => a.AnswerText == condition.Answer.Code.ToString()) != null )
                            if (condition.DataCollectionObectType.Equals(DCAnalytics.DataCollectionObectTypes.Question))
                                ValidateQuestion(condition.Target.Question);
                            else if (condition.DataCollectionObectType.Equals(DCAnalytics.DataCollectionObectTypes.SubSection))
                                condition.Target.SubSection.Questions.ForEach(q =>
                                {
                                    ValidateQuestion(q);
                                });

                if (question.Answers.Count == 0 && question.Required) //question shouldn't be a dependency template
                {
                    question.Pending = true;
                    isValid = false;
                }

            }
            catch(Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
            }
        }

        public async static void PromptAIDropdownSelection(string _key, Label l)
        {
            try
            {
                var question = (certification == null) ?  questionaire.Sections[index].Questions.Find(qn => qn.Key == _key) : certification.Sections[index].Questions.Find(qn => qn.Key == _key);
                if (question != null)
                {
                    aIDropdown = new AIDropdown(question.EnumList.EnumValues, selectPageState, l);
                    await PopupNavigation.Instance.PushAsync(aIDropdown, true);
                }
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true);
            }
        }

        public void OnResumePage(bool o)
        {
            
        }

        public void OnSleepPage()
        {

        }

        public void OnRebound()
        {

        }

        public void SaveQuestionaire()
        {
            try
            {
                //var status = -1;
                if (certification != null)
                {
                    certification.Status = DCAnalytics.Statuses.Partial;
                    if (certificationStatus.Equals(QuestionaireStatus.Create))
                    {
                        if (configuration.Certifications.Find(x => x.Key == certification.Key) == null)
                            configuration.Certifications.Add(certification);
                        certificationStatus = QuestionaireStatus.Modify;
                    }
                    else
                    {
                        var certificate = configuration.Certifications.Find(x => x.Key == certification.Key);
                        configuration.Certifications[configuration.Certifications.IndexOf(certificate)] = certification;
                    }
                }
                else if (FieldInspection != null)
                {
                    if (FieldInspection.Status.Equals(DCAnalytics.Statuses.New))
                    {
                        FieldInspection.Status = DCAnalytics.Statuses.Partial;
                        if (configuration.Inspections.Find(x => x.Key == FieldInspection.Key) == null)
                            configuration.Inspections.Add(FieldInspection);
                    }
                    else
                    {
                        var inspection = configuration.Inspections.Find(x => x.Key == FieldInspection.Key);
                        FieldInspection.Status = DCAnalytics.Statuses.Completed;
                        configuration.Inspections[configuration.Inspections.IndexOf(inspection)] = FieldInspection;
                    }
                }
                else
                {
                    questionaire.Status = DCAnalytics.Statuses.Partial;
                    if (_questionaireStatus.Equals(QuestionaireStatus.Create))
                    {
                        //status = _dbManager.SaveSQLiteQuestionaire(new SQLiteQuestionaire { sqliteQuestionaire = JsonConvert.SerializeObject(questionaire) });
                        if(configuration.Questionaires.Find(x => x.Key == questionaire.Key) == null)
                            configuration.Questionaires.Add(questionaire);
                    }
                    else
                    {
                        //status = _dbManager.UpdateReport(questionaire);
                        var qnr = configuration.Questionaires.Find(x => x.Key == questionaire.Key);
                        configuration.Questionaires[configuration.Questionaires.IndexOf(qnr)] = questionaire;
                    }
                }

                AiDataStore.SaveConfiguration(configuration);
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
            }
        }

        protected override bool OnBackButtonPressed()
        {
            ShowWarning();

            return true;
        }

        private void ShowWarning()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox("Save as draft if you want to complete this response later?", MessageType.Discard, this));
            });
        }

        public void OnResumePage(object o)
        {
            try
            {
                /*if (o != null)
                {
                    _dbManager.DeleteQuestionaire(sQLiteQuestionaire);
                    questionairePageState.OnRetrieve();
                    Navigation.RemovePage(this);
                }*/
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
            }
        }

        public async void OnExit()
        {
            try
            {
                await this.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true);
            }
        }

        public void OnPictureSelected(AIImage image, MediaFile mediaFile)
        {
            try
            {
                if (mediaFile != null)
                {
                    image.Source = ImageSource.FromStream(() =>
                    {
                        return mediaFile.GetStream();
                    });

                    Question qn = Sections.SelectMany(l => l.Questions).Where(x => x.Key == (image.Parent as StackLayout).ClassId).FirstOrDefault();
                    //Question being in a depedency subsection
                    if (qn == null)
                    {
                        var dependency = QSections.Sections.SelectMany(s => s.Questions)
                                               .SelectMany(x => x.Dependencies)
                                               .Where(o => o.Occurance == image.Occurance);

                        qn = dependency.Select(v => v.Target)
                                        .Select(x => x.SubSection)
                                        .SelectMany(s => s.Questions)
                                        .Where(q => q.Key == image.ClassId).FirstOrDefault();
                    }

                    //Question being in a subsection
                    if (qn == null)
                        qn = QSections.Sections.SelectMany(s => s.SubSections).SelectMany(l => l.Questions).Where(x => x.Key == image.ClassId).FirstOrDefault();


                    if (qn.Answers == null)
                    {
                        qn.Answers = new List<Answer>();
                        qn.Answers.Add(new Answer()
                        {
                            Key = Guid.NewGuid().ToString(),
                            AnswerText = Convert.ToBase64String(ConvertImageToByte(mediaFile))
                        });
                    }
                    else
                    {
                        qn.Answers.Clear();
                        qn.Answers.Add(new Answer()
                        {
                            Key = Guid.NewGuid().ToString(),
                            AnswerText = Convert.ToBase64String(ConvertImageToByte(mediaFile))
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
            }
        }

        private byte[] ConvertImageToByte(MediaFile mediaFile)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    mediaFile.GetStream().CopyTo(stream);
                    mediaFile.Dispose();
                    return stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
                return null;
            }
        }

        public async void OnDropDownOptionSelected()
        {
            await PopupNavigation.Instance.RemovePageAsync(aIDropdown);
        }

        public async void OnLocationCollected(Location location)
        {
            try
            {
                /*if (location != null)
                { 
                    await PopupNavigation.Instance.RemovePageAsync(controls.LocationDialog);
                    controls.label.Text = location.Latitude + "," + location.Longitude;
                    Question qn = Sections.SelectMany(l => l.Questions).Where(x => x.Key == (controls.label.Parent as StackLayout).ClassId).FirstOrDefault();
                    qn.Answers.Clear();
                    qn.Answers.Add(new Answer { Key = Guid.NewGuid().ToString(), AnswerText = controls.label.Text, Deleted = false });
                }*/            
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.Message, MessageType.Exit, this));
            }
        }

        public void OnEnableLocation()
        {
            
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

        public void OnSaveDraft()
        {
            try
            {
                SaveQuestionaire();
                Navigation.RemovePage(this);
            }
            catch(Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
            }
        }
    }
}