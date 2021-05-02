using DCAnalyticsMobile.Controls;
using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Views;
using DCAnalyticsMobile.Views.Popups;
using Naxam.Controls.Forms;
using Naxam.Mapbox;
using Plugin.InputKit.Shared.Controls;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using CheckBox = Plugin.InputKit.Shared.Controls.CheckBox;

namespace DCAnalyticsMobile.Utils
{
    public class UIControls
    {
        private AIStackLayout stackLayout, dropStackLayout, switchStackLayout;
        public AILabel label;
        private AIEntry entry;
        private Frame frame;
        private AIImage image;
        private Image dropDownImage;
        private AIButton button, buttonx, buttony;
        private AIMapView mapView;
        private AIEditor editor;
        public List<string> targets = new List<string>();
        private ContentPage contentPage;
        private Color Warning = Color.FromHex("#FF0000");
        private Color Normal = Color.FromHex("#00314b");
        private static PromptPageState promptPageState;

        public UIControls(ContentPage contentPage = null, PromptPageState _promptPageState = null)
        {
            this.contentPage = contentPage;
            promptPageState = _promptPageState;
        }
        /// <summary>
        /// DateTime Control
        /// </summary>
        public void DateTimeControl(Question question, StackLayout holder, int Occurance)
        {
            try
            {
                StackLayout stackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Margin = new Thickness(0, 0, 0, 10),
                    ClassId = question.Key,
                    IsVisible = targets.Contains(question.Key) ? (question.Answers.Count == 0) ? false : true : true
                };

                //Create a stacklayout to hold control label
                var headerStack = new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Fill };

                //Control Lable/Title
                Label label = new Label
                {
                    Text = question.QuestionText,
                    TextColor = question.Pending? Warning :  Normal,
                    FontSize = 17,
                    Margin = new Thickness(0, 0, 0, 3)
                };
                headerStack.Children.Add(label);

                if(question.Required)
                    headerStack.Children.Add(new Label
                    {
                        Text = " *",
                        TextColor = Warning,
                        FontSize = 17,
                        Margin = new Thickness(0, 0, 0, 3)
                    });

                //Control Entry
                var datePicker = new AIDatePicker
                {
                    BackgroundColor = Color.White,
                    FontSize = 17,
                    Margin = new Thickness(2.5, 0, 2.5, 0),
                    HeightRequest = 38,
                    ClassId = question.Key,
                    Occurance = Occurance
                };
                datePicker.Unfocused += DatePicker_Unfocused;

                //For existing answers
                if (question.Answers.Count > 0)
                    datePicker.Date = Convert.ToDateTime(question.Answers.FirstOrDefault().AnswerText).Date;
                else
                {
                    datePicker.Date = DateTime.Now;
                    question.Answers.Add(new Answer { Key = Guid.NewGuid().ToString(), AnswerText = datePicker.Date.ToShortDateString(), Occurance = Occurance });
                }

                //Frame to give the Entry control shape and border color
                Frame frame = new Frame
                {
                    CornerRadius = 8,
                    HasShadow = false,
                    BorderColor = Color.LightSlateGray,
                    Margin = new Thickness(0, 0, 0, 10),
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Padding = new Thickness(2, 2, 2, 2)
                };
                frame.Content = datePicker; //Enclose the entry control within the frame

                stackLayout.Children.Add(headerStack);
                stackLayout.Children.Add(frame);

                //Add stacklayout to the page
                holder.Children.Add(stackLayout);
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        private void DatePicker_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                Question qn = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Key == (sender as AIDatePicker).ClassId).FirstOrDefault();

                if (qn == null)
                {
                    var dependency = QSections.Sections.SelectMany(s => s.Questions)
                                           .SelectMany(x => x.Dependencies)
                                           .Where(o => o.Occurance == (sender as AIDatePicker).Occurance);

                    qn = dependency.Select(v => v.Target)
                                    .Select(x => x.SubSection)
                                    .SelectMany(s => s.Questions)
                                    .Where(q => q.Key == (sender as AIDatePicker).ClassId).FirstOrDefault();
                }

                //Question being in a subsection
                if (qn == null)
                    qn = QSections.Sections.SelectMany(s => s.SubSections).SelectMany(l => l.Questions).Where(x => x.Key == (sender as AIDatePicker).ClassId).FirstOrDefault();

                //Collect answer
                qn.Answers.Clear();
                qn.Answers.Add(new Answer()
                {
                    Key = Guid.NewGuid().ToString(),
                    AnswerText = (sender as AIDatePicker).Date.ToShortDateString(),
                    Occurance = (sender as AIDatePicker).Occurance
                });
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        /// <summary>
        /// Text Control
        /// </summary>
        public void EntryControl(Question question, StackLayout holder, int occurance = 0)
        {
            try
            {
                stackLayout = new AIStackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Margin = new Thickness(0, 0, 0, 0),
                    ClassId = question.Key,
                    Occurance = occurance,
                    IsVisible = targets.Contains(question.Key) ? (question.Answers.Count == 0) ? false : true : true
                };

                //Create a stacklayout to hold control label
                var headerStack = new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Fill };

                //Control Lable/Title
                Label label = new Label
                {
                    Text = question.QuestionText,
                    TextColor = question.Pending ? Warning : Normal,
                    FontSize = 17,
                    Margin = new Thickness(0, 0, 0, 1)
                };
                headerStack.Children.Add(label);

                if (question.Required)
                    headerStack.Children.Add(new Label
                    {
                        Text = " *",
                        TextColor = Warning,
                        FontSize = 17,
                        Margin = new Thickness(0, 0, 0, 1)
                    });

                //Control Entry
                entry = new AIEntry
                {
                    BackgroundColor = Color.White,
                    Margin = new Thickness(5, 2, 5, 2),
                    FontSize = 17,
                    HeightRequest = 42,
                    ClassId = question.Key,
                    Occurance = occurance
                };

                entry.Unfocused += Entry_Unfocused;

                //For existing answers
                if (question.Answers.Count > 0)
                    entry.Text = question.Answers.FirstOrDefault().AnswerText;

                //Choose what keyboard to pull up for the user
                switch (question.DataType)
                {
                    case DCAnalytics.DataTypes.Telephone:
                        entry.Keyboard = Keyboard.Telephone;
                        break;
                    case DCAnalytics.DataTypes.Alphanumeric:
                        entry.Keyboard = Keyboard.Text;
                        break;
                    case DCAnalytics.DataTypes.Numeric:
                        entry.Keyboard = Keyboard.Numeric;
                        break;
                }

                //Frame to give the Entry control shape and border color
                frame = new Frame
                {
                    IsClippedToBounds = true,
                    HasShadow = false,
                    BorderColor = Color.LightSlateGray,
                    Margin = new Thickness(0, 0, 0, 5),
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Padding = new Thickness(0),
                    CornerRadius = 8
                };
                frame.Content = entry; //Enclose the entry control within the frame

                stackLayout.Children.Add(headerStack);
                stackLayout.Children.Add(frame);

                //Add stacklayout to the page
                holder.Children.Add(stackLayout);

                //Dependencies
                if (question.Answers.Count > 0)
                {
                    question.Pending = false;
                    if (question.Dependencies.Count > 0)
                        AddFieldSubSection(question, 0, int.Parse(question.Answers.FirstOrDefault().AnswerText), stackLayout);
                }
                else if (question.Answers.Count == 0 && question.Required)
                    question.Pending = true;
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        internal void EditorControl(Question question, StackLayout holder, int occurance = 0)
        {
            try
            {
                stackLayout = new AIStackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Margin = new Thickness(0, 0, 0, 0),
                    ClassId = question.Key,
                    Occurance = occurance,
                    IsVisible = targets.Contains(question.Key) ? (question.Answers.Count == 0) ? false : true : true
                };

                //Create a stacklayout to hold control label
                var headerStack = new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Fill };

                //Control Lable/Title
                Label label = new Label
                {
                    Text = question.QuestionText,
                    TextColor = question.Pending ? Warning : Normal,
                    FontSize = 17,
                    Margin = new Thickness(0, 0, 0, 3)
                };
                headerStack.Children.Add(label);

                if (question.Required)
                    headerStack.Children.Add(new Label
                    {
                        Text = " *",
                        TextColor = Warning,
                        FontSize = 17,
                        Margin = new Thickness(0, 0, 0, 3)
                    });

                //Control Editor
                editor = new AIEditor
                {
                    BackgroundColor = Color.White,
                    Margin = new Thickness(5, 2, 5, 2),
                    AutoSize = EditorAutoSizeOption.TextChanges,
                    
                    FontSize = 17,
                    HeightRequest = 80,
                    IsReadOnly = false,
                    ClassId = question.Key,
                    Occurance = occurance
                };

                editor.Unfocused += Editor_Unfocused;

                //For existing answers
                if (question.Answers.Count > 0)
                    entry.Text = question.Answers.FirstOrDefault().AnswerText;

                //Frame to give the Entry control shape and border color
                frame = new Frame
                {
                    IsClippedToBounds = true,
                    HasShadow = false,
                    BorderColor = Color.LightSlateGray,
                    Margin = new Thickness(0, 0, 0, 5),
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Padding = new Thickness(0),
                    CornerRadius = 8
                };
                frame.Content = editor; //Enclose the entry control within the frame

                stackLayout.Children.Add(headerStack);
                stackLayout.Children.Add(frame);

                //Add stacklayout to the page
                holder.Children.Add(stackLayout);

                //Dependencies
                if (question.Answers.Count > 0)
                    question.Pending = false;
                else if (question.Answers.Count == 0 && question.Required)
                    question.Pending = true;
            }
            catch(Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        internal void MapControl(Question question, StackLayout holder, int occurance)
        {
            try
            {
                stackLayout = new AIStackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Margin = new Thickness(0, 0, 0, 10),
                    ClassId = question.Key,
                    Occurance = occurance,
                    IsVisible = targets.Contains(question.Key) ? (question.Answers.Count == 0) ? false : true : true
                };

                //Create a stacklayout to hold control label
                var headerStack = new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Fill };

                //Control Lable/Title
                Label label = new Label
                {
                    Text = question.QuestionText,
                    TextColor = question.Pending ? Warning : Normal,
                    FontSize = 17,
                    Margin = new Thickness(0, 0, 0, 3)
                };
                headerStack.Children.Add(label);

                if (question.Required)
                    headerStack.Children.Add(new Label
                    {
                        Text = " *",
                        TextColor = Warning,
                        FontSize = 17,
                        Margin = new Thickness(0, 0, 0, 3)
                    });

                stackLayout.Children.Add(headerStack);

                var mapStack = new AIStackLayout { Orientation = StackOrientation.Horizontal, ClassId = question.Key };
                mapView = new AIMapView()
                {
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    HeightRequest = 100,
                    WidthRequest = 180,
                    BackgroundColor = Color.AliceBlue,
                    Margin = new Thickness(0, 0, 0, 10),
                    Center = new LatLng(0.331470, 32.569902),
                    ZoomLevel = (Device.RuntimePlatform == Device.Android) ? 10 : 17,
                    Occurance = occurance
                };

                TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) =>
                {
                    ShowMapping((AIMapView)s);
                };

                mapView.GestureRecognizers.Add(tapGestureRecognizer);
                button = new AIButton
                {
                    Text = "Mapping",
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    HeightRequest = 40,
                    Padding = new Thickness(30, 5, 30, 5),
                    BackgroundColor = Color.FromHex("#1976d3"),
                    TextColor = Color.FromHex("#FFFFFF"),
                    VerticalOptions = LayoutOptions.Center
                };
                button.Clicked += MapView_Clicked;
                mapStack.Children.Add(mapView);
                mapStack.Children.Add(button);
                stackLayout.Children.Add(mapStack);
                holder.Children.Add(stackLayout);
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        private void MapView_Clicked(object sender, EventArgs e)
        {
            AIMapView map = ((sender as Button).Parent as StackLayout).Children[0] as AIMapView;
            ShowMapping(map);
        }

        private void ShowMapping(MapView sender)
        {
            try
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Question qn = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Key == (sender.Parent as AIStackLayout).ClassId).FirstOrDefault();

                    //Question being in a depedency subsection
                    //if (qn == null)
                    //    qn = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Dependencies.Count > (sender.Parent as AIStackLayout).Occurance).Select(d => d.Dependencies[(sender.Parent as AIStackLayout).Occurance].Target).Select(x => x.SubSection).SelectMany(s => s.Questions).Where(q => q.Key == (sender.Parent as AIStackLayout).ClassId).FirstOrDefault();

                    if(qn == null)
                        qn = QSections.Sections.SelectMany(s => s.Questions)
                                           .SelectMany(x => x.Dependencies)
                                           .Where(o => o.Occurance == (sender.Parent as AIStackLayout).Occurance)
                                           .Select(v => v.Target)
                                           .Select(x => x.SubSection)
                                           .SelectMany(s => s.Questions)
                                           .Where(q => q.Key == (sender.Parent as AIStackLayout).ClassId).FirstOrDefault();

                    //Question being in a subsection
                    if (qn == null)
                        qn = QSections.Sections.SelectMany(y => y.SubSections).SelectMany(l => l.Questions).Where(x => x.Key == (sender.Parent as AIStackLayout).ClassId).FirstOrDefault();

                    await contentPage.Navigation.PushAsync(new Mapping(qn));
                });
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        internal void LocationControl(Question question, StackLayout holder, int occurance)
        {
            try
            {
                stackLayout = new AIStackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Margin = new Thickness(0, 0, 0, 10),
                    ClassId = question.Key,
                    Occurance = occurance,
                    IsVisible = targets.Contains(question.Key) ? (question.Answers.Count == 0) ? false : true : true
                };

                //Create a stacklayout to hold control label
                var headerStack = new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Fill };

                //Control Lable/Title
                Label label = new Label
                {
                    Text = question.QuestionText,
                    TextColor = question.Pending ? Warning : Normal,
                    FontSize = 17,
                    Margin = new Thickness(0, 0, 0, 3)
                };
                headerStack.Children.Add(label);

                if (question.Required)
                    headerStack.Children.Add(new Label
                    {
                        Text = " *",
                        TextColor = Warning,
                        FontSize = 17,
                        Margin = new Thickness(0, 0, 0, 3)
                    });

                stackLayout.Children.Add(headerStack);

                var locationStack = new StackLayout { Orientation = StackOrientation.Horizontal, ClassId = question.Key };
                label = new AILabel()
                {
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Margin = new Thickness(0, 0, 0, 10),
                    Occurance = occurance,
                    ClassId = question.Key,
                    Text = (question.Answers.Count > 0) ? question.Answers.FirstOrDefault().AnswerText : "x,y"
                };

                button = new AIButton
                {
                    Text = "Change",
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    HeightRequest = 40,
                    Padding = new Thickness(30, 5, 30, 5),
                    BackgroundColor = Color.FromHex("#1976d3"),
                    TextColor = Color.FromHex("#FFFFFF"),
                    VerticalOptions = LayoutOptions.Center
                };
                button.Clicked += Location_Clicked;
                locationStack.Children.Add(label);
                locationStack.Children.Add(button);
                stackLayout.Children.Add(locationStack);
                holder.Children.Add(stackLayout);
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        private void Location_Clicked(object sender, EventArgs e)
        {
            try
            {
                var label = (((sender as Button).Parent as StackLayout).Children[0] as AILabel);
                CollectQuestionLocation(label);
            }
            catch(Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        public LocationDialog LocationDialog;
        public async void CollectQuestionLocation(AILabel _label)
        {
            try
            {
                label = _label;

                var location = await new GeolocationManager().GetLocationAsync();
                if(location != null)
                _label.Text = location.Latitude + "," + location.Longitude;

                Question qn = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Key == (_label.Parent as StackLayout).ClassId).FirstOrDefault();
                if (qn == null)
                {
                    var dependency = QSections.Sections.SelectMany(s => s.Questions)
                                           .SelectMany(x => x.Dependencies)
                                           .Where(o => o.Occurance == _label.Occurance);

                    qn = dependency.Select(v => v.Target)
                                    .Select(x => x.SubSection)
                                    .SelectMany(s => s.Questions)
                                    .Where(q => q.Key == _label.ClassId).FirstOrDefault();
                }

                //Question being in a subsection
                if (qn == null)
                    qn = QSections.Sections.SelectMany(s => s.SubSections).SelectMany(l => l.Questions).Where(x => x.Key == _label.ClassId).FirstOrDefault();

                qn.Answers.Clear();
                qn.Answers.Add(new Answer { Key = Guid.NewGuid().ToString(), AnswerText = _label.Text, Deleted = false });
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                StackLayout container = ((sender as AIEntry).Parent as Frame).Parent as StackLayout;
                if (((sender as Entry).Parent as Frame).BorderColor.Equals(Color.Red))
                    ((sender as Entry).Parent as Frame).BorderColor = Color.FromHex("#00314b");

                //Question being in a section
                Question qn = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Key == (sender as AIEntry).ClassId).FirstOrDefault();

                //Question being in a depedency subsection
                //if (qn == null)
                //    qn = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Dependencies.Count > (sender as AIEntry).Occurance).Select(d => d.Dependencies[(sender as AIEntry).Occurance].Target).Select(x => x.SubSection).SelectMany(s => s.Questions).Where(q => q.Key == (sender as Entry).ClassId).FirstOrDefault();
                if (qn == null)
                {
                    var dependency = QSections.Sections.SelectMany(s => s.Questions)
                                           .SelectMany(x => x.Dependencies)
                                           .Where(o => o.Occurance == (sender as AIEntry).Occurance);

                    qn = dependency.Select(v => v.Target)
                                    .Select(x => x.SubSection)
                                    .SelectMany(s => s.Questions)
                                    .Where(q => q.Key == (sender as Entry).ClassId).FirstOrDefault();
                }

                //Question being in a subsection
                if (qn == null)
                    qn = QSections.Sections.SelectMany(s => s.SubSections).SelectMany(l => l.Questions).Where(x => x.Key == (sender as AIEntry).ClassId).FirstOrDefault();

                //Hnadling Depencies
                if (qn.Dependencies.Count > 0)
                {
                    if (qn.Answers.Count != 0 && Convert.ToInt16((sender as AIEntry).Text) > Convert.ToInt16(qn.Answers.FirstOrDefault().AnswerText))
                        AddFieldSubSection(qn, Convert.ToInt16(qn.Answers.FirstOrDefault().AnswerText), Convert.ToInt16((sender as AIEntry).Text), container);
                    else if (qn.Answers.Count != 0 && Convert.ToInt16(qn.Answers.FirstOrDefault().AnswerText) > Convert.ToInt16((sender as AIEntry).Text))
                        RemoveFieldSubSection((Convert.ToInt16(qn.Answers.FirstOrDefault().AnswerText) - Convert.ToInt16((sender as AIEntry).Text)), container);
                    else if (qn.Answers.Count > 0 && string.IsNullOrEmpty((sender as AIEntry).Text))
                        RemoveFieldSubSection((Convert.ToInt16(qn.Answers.FirstOrDefault().AnswerText) - 0), container);
                    else
                        AddFieldSubSection(qn, 0, Convert.ToInt16((sender as AIEntry).Text), container);
                }

                //Collect answer
                qn.Answers.Clear();
                qn.Answers.Add(new Answer()
                {
                    Key = Guid.NewGuid().ToString(),
                    AnswerText = (sender as AIEntry).Text,
                    Occurance = (sender as AIEntry).Occurance
                });
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        private void Editor_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                StackLayout container = ((sender as AIEditor).Parent as Frame).Parent as StackLayout;
                if (((sender as AIEditor).Parent as Frame).BorderColor.Equals(Color.Red))
                    ((sender as AIEditor).Parent as Frame).BorderColor = Color.FromHex("#00314b");

                //Question being in a section
                Question qn = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Key == (sender as AIEditor).ClassId).FirstOrDefault();

                //Question being in a depedency subsection
                if (qn == null)
                {
                    var dependency = QSections.Sections.SelectMany(s => s.Questions)
                                           .SelectMany(x => x.Dependencies)
                                           .Where(o => o.Occurance == (sender as AIEditor).Occurance);

                    qn = dependency.Select(v => v.Target)
                                    .Select(x => x.SubSection)
                                    .SelectMany(s => s.Questions)
                                    .Where(q => q.Key == (sender as AIEditor).ClassId).FirstOrDefault();
                }

                //Question being in a subsection
                if (qn == null)
                    qn = QSections.Sections.SelectMany(s => s.SubSections).SelectMany(l => l.Questions).Where(x => x.Key == (sender as AIEditor).ClassId).FirstOrDefault();

                //Collect answer
                qn.Answers.Clear();
                qn.Answers.Add(new Answer()
                {
                    Key = Guid.NewGuid().ToString(),
                    AnswerText = (sender as AIEditor).Text,
                    Occurance = (sender as AIEditor).Occurance
                });
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        //public static IEnumerable<Dependency> Filter(this IEnumerable<Dependency> dependencies, Func<Dependency, int> index)
        //{
        //    return dependencies[index];
        //}

        private void RemoveFieldSubSection(int iterations, StackLayout qnStackLayout)
        {
            for (int i = 0; i < iterations; i++)
                qnStackLayout.Children.RemoveAt(qnStackLayout.Children.Count - 1);

            /*if (qnStackLayout.Children.Count > 2)
                qnStackLayout.Children.Add(new BoxView
                {
                    ClassId = "dboundary",
                    HeightRequest = 2,
                    Margin = new Thickness(0, 0, 0, 20),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Color = Color.Gray
                });*/
        }

        void AddFieldSubSection(Question qn, int initial, int iterations, StackLayout qnStackLayout)
        {
            try
            {
                var dependencies = qn.Dependencies.Where(d => !string.IsNullOrEmpty(d.Template)).ToList();
                for (int i = initial; i < iterations; i++)
                {

                    var template = qn.Dependencies.Where(d => string.IsNullOrEmpty(d.Template)).FirstOrDefault();
                    var dependency = new Dependency
                    {
                        Key = Guid.NewGuid().ToString(),
                        Target = template.Target,
                        TargetObjectKey = template.TargetObjectKey,
                        TargetObjectType = template.TargetObjectType,
                        Template = template.Key,
                        Deleted = false,
                        Occurance = i
                    };

                    var _questions = new List<Question>();
                    template.Target.SubSection.Questions.ForEach(question =>
                    {
                        Question _qn = new Question()
                        {
                            Key = question.Key,
                            OID = question.OID,
                            Dependencies = question.Dependencies,
                            Required = question.Required,
                            Name = question.Name,
                            QuestionText = question.QuestionText,
                            QuestionType = question.QuestionType,
                            Conditions = question.Conditions,
                            DataType = question.DataType,
                            EnumList = question.EnumList,
                            Answers = new List<Answer>(),
                            Occurance = i
                        };

                        _questions.Add(_qn);
                    });
                    /*foreach (Question q in template.Target.SubSection.Questions)
                    {
                        Question _qn = new Question()
                        {
                            Key = q.Key,
                            OID = q.OID,
                            Dependencies = q.Dependencies,
                            Required = q.Required,
                            Name = q.Name,
                            QuestionText = q.QuestionText,
                            QuestionType = q.QuestionType,
                            Conditions = q.Conditions,
                            DataType = q.DataType,
                            EnumList = q.EnumList,
                            Answers = new List<Answer>(),
                            Occurance = i
                        };
                        _questions.Add(_qn);
                    }*/

                    dependency.Target = new Target
                    {
                        SubSection = new SubSection
                        {
                            Key = template.Target.SubSection.Key,
                            OID = template.Target.SubSection.OID,
                            CollectionObjectType = template.Target.SubSection.CollectionObjectType,
                            CreatedBy = template.Target.SubSection.CreatedBy,
                            Name = template.Target.SubSection.Name
                        }
                    };
                    dependency.Target.SubSection.Questions = _questions;

                    qn.Dependencies.Add(dependency);

                    //if (qnStackLayout.Children[qnStackLayout.Children.Count - 1].ClassId == "dboundary")
                    //    qnStackLayout.Children.RemoveAt(qnStackLayout.Children.Count - 1);

                    //if (i == (iterations - 1))
                    //    qnStackLayout.Children.Add(new BoxView
                    //    {
                    //        ClassId = "dboundary",
                    //        HeightRequest = 2,
                    //        Margin = new Thickness(0, 0, 0, 20),
                    //        HorizontalOptions = LayoutOptions.FillAndExpand,
                    //        Color = Color.Gray
                    //    });
                }

                var _dependencies = qn.Dependencies.Where(d => !dependencies.Any(_d => _d.Key == d.Key) && !string.IsNullOrEmpty(d.Template)).ToList();
                if (_dependencies.Count == 0)
                    _dependencies = dependencies;

                foreach (Dependency dependency in _dependencies)
                {
                    var targetStackLayout = CreateSubSection(qn, dependency.Occurance);
                    if (targetStackLayout != null)
                        qnStackLayout.Children.Add(targetStackLayout);
                }
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        private StackLayout CreateSubSection(Question qn, int o)
        {
            try
            {
                var dependencies = qn.Dependencies.Where(d => !string.IsNullOrEmpty(d.Template)).ToList();
                var subSection = (dependencies.Where(d => d.Occurance == o).FirstOrDefault().Target.SubSection as SubSection);
                StackLayout subSectionStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.Fill
                };

                QSections.InitSubSection(subSection, subSectionStackLayout, o);

                return subSectionStackLayout;
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
                return null;
            }
        }

        /// <summary>
        /// Multi Select Control
        /// </summary>
        public void MultiSelect(Question question, StackLayout holder, int occurance)
        {
            try
            {
                //feature stack
                AIStackLayout stackLayout = new AIStackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Margin = new Thickness(0, 0, 0, 10),
                    ClassId = question.Key,
                    Occurance = occurance,
                    IsVisible = targets.Contains(question.Key) ? (question.Answers.Count == 0) ? false : true : true
                };

                //Create a stacklayout to hold control label
                var headerStack = new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Fill };

                //Control Lable/Title
                Label label = new Label
                {
                    Text = question.QuestionText,
                    TextColor = question.Pending ? Warning : Normal,
                    FontSize = 17,
                    Margin = new Thickness(0, 0, 0, 3)
                };

                headerStack.Children.Add(label);

                if (question.Required)
                    headerStack.Children.Add(new Label
                    {
                        Text = " *",
                        TextColor = Warning,
                        FontSize = 17,
                        Margin = new Thickness(0, 0, 0, 3)
                    });


                int i = 1, gridRow = 0;
                //checkboxes are arranged in a grid
                AIGrid grid = new AIGrid
                {
                    VerticalOptions = LayoutOptions.Center,
                    ColumnDefinitions =
                    {
                        new ColumnDefinition {Width = new GridLength(.5, GridUnitType.Star)},
                        new ColumnDefinition {Width = new GridLength(.5, GridUnitType.Star)}
                    },
                    ClassId = question.Key,
                    Occurance = occurance
                }; ;

                //create checkboxes for each feature item
                foreach (var value in question.EnumList.EnumValues)
                {
                    AICheckBox checkBox = new AICheckBox
                    {
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Center,
                        Text = value.Description,
                        TextFontSize = 15,
                        ClassId = value.Code.ToString(),
                        Occurance = occurance,
                        IsChecked = (question.Answers.Count > 0) ? (question.Answers.Find(x => int.Parse(x.AnswerText) == value.Code) != null) ? true : false : false
                    };

                    checkBox.CheckChanged += (sender, args) =>
                    {
                        //Changing the Permitted Category Label
                        if ((((((sender as AICheckBox).Parent as AIGrid).Parent as AIStackLayout).Children[0] as StackLayout).Children[0] as Label).TextColor.Equals(Color.FromHex("#FF0000")))
                            (((((sender as AICheckBox).Parent as AIGrid).Parent as AIStackLayout).Children[0] as StackLayout).Children[0] as Label).TextColor = Normal;

                        Question qn = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Key == ((sender as CheckBox).Parent as AIGrid).ClassId).FirstOrDefault();

                        //Question being in a depedency subsection
                        //if (qn == null)
                        //    qn = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Dependencies.Count > ((sender as AICheckBox).Parent as AIGrid).Occurance).Select(d => d.Dependencies[((sender as AICheckBox).Parent as AIGrid).Occurance].Target).Select(x => x.SubSection).SelectMany(s => s.Questions).Where(q => q.Key == ((sender as AICheckBox).Parent as AIGrid).ClassId).FirstOrDefault();

                        if(qn == null)
                            qn = QSections.Sections.SelectMany(s => s.Questions)
                                                    .SelectMany(x => x.Dependencies)
                                                    .Where(o => o.Occurance == ((sender as AICheckBox).Parent as AIGrid).Occurance)
                                                    .Select(v => v.Target)
                                                    .Select(x => x.SubSection)
                                                    .SelectMany(s => s.Questions)
                                                    .Where(q => q.Key == ((sender as AICheckBox).Parent as AIGrid).ClassId).FirstOrDefault();

                        //Question being part of a subsection
                        if (qn == null)
                            qn = QSections.Sections.SelectMany(s => s.SubSections).SelectMany(l => l.Questions).Where(x => x.Key == ((sender as AICheckBox).Parent as AIGrid).ClassId).FirstOrDefault();

                        //Collect answer
                        Answer answer = qn.Answers.Find(x => x.AnswerText == (sender as AICheckBox).ClassId);
                        if (checkBox.IsChecked)
                        {
                            if (answer == null)
                            {
                                qn.Answers.Add(new Answer()
                                {
                                    Key = Guid.NewGuid().ToString(),
                                    AnswerText = (sender as CheckBox).ClassId,
                                    Occurance = ((sender as AICheckBox).Parent as AIGrid).Occurance,
                                    Deleted = false
                                });
                            }
                        }
                        else
                            qn.Answers.Remove(answer);
                    };

                    if ((i % 2).Equals(1))
                    {
                        grid.Children.Add(checkBox, 0, gridRow);
                    }
                    else
                    {
                        grid.Children.Add(checkBox, 1, gridRow);
                        gridRow++;
                    }

                    i++;
                }

                stackLayout.Children.Add(headerStack);
                stackLayout.Children.Add(grid);

                //Add stacklayout to accident page
                holder.Children.Add(stackLayout);
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        /// <summary>
        /// Single Select Control
        /// </summary>
        public void SingleSelect(Question question, StackLayout holder, int occurance)
        {
            try
            {
                //control stacklayout
                StackLayout stackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Margin = new Thickness(0, 0, 0, 10),
                    ClassId = question.Key,
                    IsVisible = targets.Contains(question.Key) ? (question.Answers.Count == 0) ? false : true : true
                };

                //Create a stacklayout to hold control label
                var headerStack = new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Fill };

                //Control Lable/Title
                Label label = new Label
                {
                    Text = question.QuestionText,
                    TextColor = question.Pending ? Warning : Normal,
                    FontSize = 17,
                    Margin = new Thickness(0, 0, 0, 3)
                };
                headerStack.Children.Add(label);

                if (question.Required)
                    headerStack.Children.Add(new Label
                    {
                        Text = " *",
                        TextColor = Warning,
                        FontSize = 17,
                        Margin = new Thickness(0, 0, 0, 3)
                    });

                //GroupButtonView in a grid
                int i = 1, gridRow = 0;
                var grid = new Grid
                {
                    VerticalOptions = LayoutOptions.Center,
                    ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(.5, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(.5, GridUnitType.Star)}
                }
                };

                foreach (EnumValue value in question.EnumList.EnumValues)
                {
                    AIRadioButton radioButton = new AIRadioButton();
                    radioButton.Color = Color.Blue;
                    radioButton.HorizontalOptions = LayoutOptions.Start;
                    radioButton.VerticalOptions = LayoutOptions.Center;
                    radioButton.TextFontSize = 15;
                    radioButton.Text = value.Description;
                    radioButton.Value = value.Code;
                    radioButton.IsChecked = (question.Answers.Count > 0) ? (Convert.ToInt16(question.Answers.FirstOrDefault().AnswerText) == value.Code) ? true : false : false;

                    if ((i % 2).Equals(1))
                    {
                        grid.Children.Add(radioButton, 0, gridRow);
                    }
                    else
                    {
                        grid.Children.Add(radioButton, 1, gridRow);

                        gridRow++;
                    }
                    i++;
                }

                AIRadioButtonGroupView groupRadioButton = new AIRadioButtonGroupView();
                groupRadioButton.ClassId = question.Key;
                groupRadioButton.Occurance = occurance;
                groupRadioButton.Children.Add(grid);

                groupRadioButton.SelectedItemChanged += (sender, args) =>
                {
                    try
                    {
                        ((((sender as AIRadioButtonGroupView).Parent as StackLayout).Children[0] as StackLayout).Children[0] as Label).TextColor = Color.FromHex("#00314b");
                        Question qn = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Key == (sender as AIRadioButtonGroupView).ClassId).FirstOrDefault();

                        //Question being in a depedency subsection
                        //if (qn == null)
                        //    qn = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Dependencies.Count > (sender as AIRadioButtonGroupView).Occurance).Select(d => d.Dependencies[(sender as AIRadioButtonGroupView).Occurance].Target).Select(x => x.SubSection).SelectMany(s => s.Questions).Where(q => q.Key == (sender as AIRadioButtonGroupView).ClassId).FirstOrDefault();

                        if(qn == null)
                            qn = QSections.Sections.SelectMany(s => s.Questions)
                                           .SelectMany(x => x.Dependencies)
                                           .Where(o => o.Occurance == (sender as AIRadioButtonGroupView).Occurance)
                                           .Select(v => v.Target)
                                           .Select(x => x.SubSection)
                                           .SelectMany(s => s.Questions)
                                           .Where(q => q.Key == (sender as AIRadioButtonGroupView).ClassId).FirstOrDefault();

                        //Question being part of subsection
                        if (qn == null)
                            qn = QSections.Sections.SelectMany(s => s.SubSections).SelectMany(l => l.Questions).Where(x => x.Key == (sender as AIRadioButtonGroupView).ClassId).FirstOrDefault();

                        if (qn != null && question.Conditions.Count > 0)
                        {
                            if (question.Conditions.FirstOrDefault().DataCollectionObectType == DCAnalytics.DataCollectionObectTypes.SubSection)
                            {
                                var _parent = (sender as AIRadioButtonGroupView).Parent as StackLayout;
                                ToggleConditionalTarget(qn, (int)qn.EnumList.EnumValues[(sender as AIRadioButtonGroupView).SelectedIndex].Code, occurance ,_parent.Children[_parent.Children.Count - 1] as StackLayout);
                            }
                            else
                                ToggleConditionalTarget(qn, (int)qn.EnumList.EnumValues[(sender as AIRadioButtonGroupView).SelectedIndex].Code, occurance);
                        }


                        //Collect answer
                        qn.Answers.Clear();
                        qn.Answers.Add(new Answer()
                        {
                            Key = Guid.NewGuid().ToString(),
                            AnswerText = qn.EnumList.EnumValues[(sender as RadioButtonGroupView).SelectedIndex].Code.ToString(),
                            Occurance = (sender as AIRadioButtonGroupView).Occurance
                        });
                    }
                    catch (Exception ex)
                    {
                        Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
                    }
                };

                stackLayout.Children.Add(headerStack);
                stackLayout.Children.Add(groupRadioButton);

                //Add stacklayout to the page
                holder.Children.Add(stackLayout);
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        /// <summary>
        /// Dropdown Control
        /// </summary>
        public void DropDownControl(Question question, StackLayout holder, int occurance)
        {
            try
            {
                stackLayout = new AIStackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Margin = new Thickness(0, 0, 0, 10),
                    ClassId = question.Key,
                    Occurance = occurance,
                    IsVisible = targets.Contains(question.Key) ? (question.Answers.Count == 0) ? false : true : true
                };

                //Create a stacklayout to hold control label
                var headerStack = new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Fill };

                //Control Lable/Title
                Label label = new Label
                {
                    Text = question.QuestionText,
                    TextColor = question.Pending ? Warning : Normal,
                    FontSize = 17,
                    Margin = new Thickness(0, 0, 0, 3)
                };
                headerStack.Children.Add(label);

                if (question.Required)
                    headerStack.Children.Add(new Label
                    {
                        Text = " *",
                        TextColor = Warning,
                        FontSize = 17,
                        Margin = new Thickness(0, 0, 0, 3)
                    });

                stackLayout.Children.Add(headerStack);

                dropStackLayout = new AIStackLayout
                {
                    HeightRequest = 38,
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(10, 0, 10, 0),
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    ClassId = question.Key,
                    Occurance = occurance
                };

                label = new AILabel { Text = "Select " + question.EnumList.Name, FontSize = 16, VerticalOptions = LayoutOptions.CenterAndExpand };
                label.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == "Text" && !string.IsNullOrEmpty((sender as Label).Text))
                    {
                        Question qn = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Key == ((sender as AILabel).Parent as AIStackLayout).ClassId).FirstOrDefault();

                        //Question being in a depedency subsection
                        if (qn == null)
                            qn = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Dependencies.Count > (sender as AILabel).Occurance).Select(d => d.Dependencies[(sender as AILabel).Occurance].Target).Select(x => x.SubSection).SelectMany(s => s.Questions).Where(q => q.Key == (sender as Entry).ClassId).FirstOrDefault();

                        //Question being in a subsection
                        if (qn == null)
                            qn = QSections.Sections.SelectMany(s => s.SubSections).SelectMany(l => l.Questions).Where(x => x.Key == ((sender as AILabel).Parent as AIStackLayout).ClassId).FirstOrDefault();

                        if (qn != null && question.Conditions.Count > 0)
                        {
                            if (qn.Conditions.FirstOrDefault().DataCollectionObectType == DCAnalytics.DataCollectionObectTypes.Question)
                            {
                                var _parent = (((sender as Button).Parent as StackLayout).Parent as Frame).Parent as StackLayout; //parent stack holding question and dependent subsection stack
                                ToggleConditionalTarget(qn, Convert.ToInt16((sender as AIButton).ClassId), (sender as AIButton).Occurance, _parent.Children[_parent.Children.Count - 1] as AIStackLayout);
                            }
                            else
                                ToggleConditionalTarget(qn, Convert.ToInt16(((sender as Label).Parent as AIStackLayout).ClassId), Convert.ToInt16(((sender as Label).Parent as AIStackLayout).ClassId));
                        }                            

                        //Collect answer
                        qn.Answers.Clear();
                        qn.Answers.Add(new Answer()
                        {
                            Key = Guid.NewGuid().ToString(),
                            AnswerText = (sender as Label).ClassId
                        });
                    }
                };

                if (question.Answers.Count > 0)
                    label.Text = question.Answers.FirstOrDefault().AnswerText;

                dropStackLayout.Children.Add(label);

                dropDownImage = new Image
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Source = "ic_dropdown",
                    HeightRequest = 16,
                    WidthRequest = 16,
                    HorizontalOptions = LayoutOptions.EndAndExpand
                };
                dropStackLayout.Children.Add(dropDownImage);

                frame = new Frame
                {
                    HasShadow = false,
                    CornerRadius = 8,
                    Padding = 2,
                    BorderColor = Color.LightSlateGray
                };
                frame.Content = dropStackLayout;

                var _tapGestureRecognizer = new TapGestureRecognizer();
                _tapGestureRecognizer.Tapped += (s, e) =>
                {
                    var _id = ((s as Frame).Parent as StackLayout).ClassId;
                    Label l = (((s as Frame).Content as StackLayout).Children[0] as Label);
                    QSections.PromptAIDropdownSelection(_id, l);
                };

                frame.GestureRecognizers.Add(_tapGestureRecognizer);
                stackLayout.Children.Add(frame);

                holder.Children.Add(stackLayout);
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        /// <summary>
        /// Switch Control
        /// </summary>
        public void SwitchControl(Question question, StackLayout holder, int occurance)
        {
            try
            {
                stackLayout = new AIStackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Margin = new Thickness(0, 0, 0, 10),
                    ClassId = question.Key,
                    Occurance = occurance,
                    IsVisible = targets.Contains(question.Key) ? (question.Answers.Count == 0) ? false : true : true
                };

                //Create a stacklayout to hold control label
                var headerStack = new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Fill };

                //Control Lable/Title
                Label label = new Label
                {
                    Text = question.QuestionText,
                    TextColor = question.Pending ? Warning : Normal,
                    FontSize = 17,
                    Margin = new Thickness(0, 0, 0, 3)
                };
                headerStack.Children.Add(label);

                if (question.Required)
                    headerStack.Children.Add(new Label
                    {
                        Text = " *",
                        TextColor = Warning,
                        FontSize = 17,
                        Margin = new Thickness(0, 0, 0, 3)
                    });

                switchStackLayout = new AIStackLayout
                {
                    ClassId = question.Key,
                    Orientation = StackOrientation.Horizontal,
                    Occurance = occurance
                };

                buttonx = new AIButton
                {
                    Text = question.EnumList.EnumValues[0].Description,
                    HeightRequest = 30,
                    CornerRadius = 30,
                    Margin = new Thickness(0, 0, 0, 0),
                    WidthRequest = 120,
                    Padding = 1,
                    ClassId = question.EnumList.EnumValues[0].Code.ToString(),
                    Occurance = occurance,
                    BackgroundColor = (question.Answers.Count > 0) ? (Convert.ToInt16(question.Answers.FirstOrDefault().AnswerText) != question.EnumList.EnumValues[0].Code) ? Color.FromHex("#1E88E5") : Color.White : Color.White,
                    TextColor = (question.Answers.Count > 0) ? (Convert.ToInt16(question.Answers.FirstOrDefault().AnswerText) != question.EnumList.EnumValues[0].Code) ? Color.White : Color.Default : Color.Default
                };

                buttonx.Clicked += (sender, args) =>
                {
                    (sender as Button).BackgroundColor = Color.White;
                    (sender as Button).TextColor = Color.Default;
                    (((sender as Button).Parent as StackLayout).Children[1] as Button).BackgroundColor = Color.FromHex("#1E88E5");
                    (((sender as Button).Parent as StackLayout).Children[1] as Button).TextColor = Color.White;

                    ToggleSwitch(sender);
                };

                switchStackLayout.Children.Add(buttonx);

                buttony = new AIButton
                {
                    Text = question.EnumList.EnumValues[1].Description,
                    HeightRequest = 30,
                    CornerRadius = 30,
                    Margin = new Thickness(-5, 0, 0, 0),
                    WidthRequest = 120,
                    Padding = 1,
                    ClassId = question.EnumList.EnumValues[1].Code.ToString(),
                    Occurance = occurance,
                    BackgroundColor = (question.Answers.Count > 0) ? (Convert.ToInt16(question.Answers.FirstOrDefault().AnswerText) != question.EnumList.EnumValues[1].Code) ? Color.FromHex("#1E88E5") : Color.White : Color.White,
                    TextColor = (question.Answers.Count > 0) ? (Convert.ToInt16(question.Answers.FirstOrDefault().AnswerText) != question.EnumList.EnumValues[1].Code) ? Color.White : Color.Default : Color.Default
                };

                buttony.Clicked += (sender, args) =>
                {
                    (sender as Button).BackgroundColor = Color.White;
                    (sender as Button).TextColor = Color.Default;
                    (((sender as Button).Parent as StackLayout).Children[0] as Button).BackgroundColor = Color.FromHex("#1E88E5");
                    (((sender as Button).Parent as StackLayout).Children[0] as Button).TextColor = Color.White;

                    ToggleSwitch(sender);
                };

                switchStackLayout.Children.Add(buttony);

                var switchFrame = new Frame { BackgroundColor = Color.FromHex("#1E88E5"), Padding = 2, HasShadow = false, CornerRadius = 30, IsClippedToBounds = true, HorizontalOptions = LayoutOptions.Start };
                switchFrame.Content = switchStackLayout;

                stackLayout.Children.Add(headerStack);
                stackLayout.Children.Add(switchFrame);

                //Add stacklayout to the page
                holder.Children.Add(stackLayout);
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        /*
        * StackLayout containing the switch buttons has the question key in its classid while the button classid is the enum code value
        */
        private void ToggleSwitch(object sender)
        {
            try
            {
                //Change text color of question label incase it is red
                ((((((sender as Button).Parent as StackLayout).Parent as Frame).Parent as StackLayout)
                                                 .Children[0] as StackLayout).Children[0] as Label).TextColor = Normal;

                Question qn = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Key == ((sender as AIButton).Parent as StackLayout).ClassId).FirstOrDefault();

                //Question being in a depedency subsection
                //if (qn == null)
                //    qn = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Dependencies.Count > (sender as AIButton).Occurance).Select(d => d.Dependencies[(sender as AIButton).Occurance].Target).Select(x => x.SubSection).SelectMany(s => s.Questions).Where(q => q.Key == ((sender as AIButton).Parent as StackLayout).ClassId).FirstOrDefault();
                if(qn == null)
                    qn = QSections.Sections.SelectMany(s => s.Questions)
                                           .SelectMany(x => x.Dependencies)
                                           .Where(o => o.Occurance == (sender as AIButton).Occurance)
                                           .Select(v => v.Target)
                                           .Select(x => x.SubSection)
                                           .SelectMany(s => s.Questions)
                                           .Where(q => q.Key == ((sender as AIButton).Parent as StackLayout).ClassId).FirstOrDefault();

                //Question being in a subsection
                if (qn == null)
                    qn = QSections.Sections.SelectMany(s => s.SubSections).SelectMany(l => l.Questions).Where(x => x.Key == ((sender as AIButton).Parent as StackLayout).ClassId).FirstOrDefault();

                if (qn != null && qn.Conditions.Count > 0)
                {
                    if (qn.Conditions.FirstOrDefault().DataCollectionObectType == DCAnalytics.DataCollectionObectTypes.Question)
                    {
                        var _parent = (((sender as Button).Parent as StackLayout).Parent as Frame).Parent as StackLayout; //parent stack holding question and dependent subsection stack
                        ToggleConditionalTarget(qn, Convert.ToInt16((sender as AIButton).ClassId), (sender as AIButton).Occurance, (_parent.Parent as StackLayout));
                    }
                    else
                        ToggleConditionalTarget(qn, Convert.ToInt16((sender as AIButton).ClassId), (sender as AIButton).Occurance);
                }

                //Collect answer
                qn.Answers.Clear();
                qn.Answers.Add(new Answer()
                {
                    Key = Guid.NewGuid().ToString(),
                    AnswerText = (sender as Button).ClassId,
                    Occurance = (sender as AIButton).Occurance
                });
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        /// <summary>
        /// Image Control
        /// </summary>
        public void ImageControl(Question question, StackLayout holder, int occurance)
        {
            try
            {
                stackLayout = new AIStackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Margin = new Thickness(0, 0, 0, 10),
                    ClassId = question.Key,
                    Occurance = occurance,
                    IsVisible = targets.Contains(question.Key) ? (question.Answers.Count == 0) ? false : true : true
                };

                //Create a stacklayout to hold control label
                var headerStack = new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Fill };

                //Control Lable/Title
                Label label = new Label
                {
                    Text = question.QuestionText,
                    TextColor = question.Pending ? Warning : Normal,
                    FontSize = 17,
                    Margin = new Thickness(0, 0, 0, 3)
                };
                headerStack.Children.Add(label);

                if (question.Required)
                    headerStack.Children.Add(new Label
                    {
                        Text = " *",
                        TextColor = Warning,
                        FontSize = 17,
                        Margin = new Thickness(0, 0, 0, 3)
                    });

                stackLayout.Children.Add(headerStack);

                var imageStack = new StackLayout { Orientation = StackOrientation.Horizontal, ClassId = question.Key };
                image = new AIImage()
                {
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    HeightRequest = 100,
                    ClassId = question.Key,
                    BackgroundColor = Color.AliceBlue,
                    Margin = new Thickness(0, 0, 0, 10),
                    Occurance = occurance
                };

                image.Source = (question.Answers.Count > 0) ? ImageSource.FromStream(() => { return new MemoryStream(Convert.FromBase64String(question.Answers.FirstOrDefault().AnswerText)); }) : "ic_ImagePlaceholder.png";
                TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) =>
                {
                    ShowImageOptions(s as AIImage);
                };

                image.GestureRecognizers.Add(tapGestureRecognizer);
                var imgButton = new Button
                {
                    Text = "Change Picture",
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    HeightRequest = 40,
                    BackgroundColor = Color.FromHex("#1976d3"),
                    TextColor = Color.White,
                    VerticalOptions = LayoutOptions.Center
                };
                imgButton.Clicked += SelectImage;
                imageStack.Children.Add(image);
                imageStack.Children.Add(imgButton);
                stackLayout.Children.Add(imageStack);
                holder.Children.Add(stackLayout);
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }

        private void SelectImage(object sender, EventArgs e)
        {
            var image = (((sender as Button).Parent as StackLayout).Children[0] as AIImage);
            ShowImageOptions(image);
        }

        public bool ToggleConditionalTarget(Question question, int enumValue, int occurance = 0, StackLayout dependentStack = null)
        {
            try
            {
                if (question.Conditions.Count > 0)
                {
                    var condition = question.Conditions.Where(x => x.Answer.Code == enumValue).FirstOrDefault();
                    if (condition != null)
                    {
                        //Target Section Position
                        Section section = QSections.Sections.Find(x => x.Key == condition.AttributeKey.ToLower());

                        /*
                        //Target Question
                        Question tQuestion = section.Questions.Find(y => y.Key == condition.Target.Key);

                        //Question being in a depedency subsection
                        if (tQuestion == null && occurance > 0)
                            tQuestion = QSections.Sections.SelectMany(l => l.Questions).Where(x => x.Dependencies.Count > occurance).Select(d => d.Dependencies[occurance].Target).Select(x => x.SubSection).SelectMany(s => s.Questions).Where(q => q.Key == condition.Target.Key).FirstOrDefault();

                        if (tQuestion == null)
                            tQuestion = QSections.Sections.SelectMany(s => s.SubSections).SelectMany(l => l.Questions).Where(x => x.Key == condition.Target.Key).FirstOrDefault();
                        */
                        var key = condition.AttributeKey;
                        if (condition.Target != null)
                            if (condition.Target.Section != null)
                            {
                                key = condition.Target.Section.Key;
                                QSections.TargetSection = condition.Target.Section.Key;
                            }
                            else if (condition.Target.SubSection != null)
                                key = condition.Target.SubSection.Key;
                            else if (condition.Target.Question != null)
                                key = condition.Target.Question.Key;

                        var stacks = QSections.sectionViews.SelectMany(sv => (sv.ContentView.Content as StackLayout).Children).SelectMany(y => (y as StackLayout).Children).Where(view => view.ClassId == key).ToList();

                        if (stacks.Count() == 0)
                        {
                            var subSection = QSections.Sections.SelectMany(s => s.SubSections).Where(r => r.Questions.Select(a => a.Key).Contains(question.Key)).FirstOrDefault();

                            if (subSection != null)
                            {
                                var subSectionViews = QSections.sectionViews.SelectMany(sv => (sv.ContentView.Content as StackLayout).Children).SelectMany(y => (y as StackLayout).Children).Where(v => v.ClassId == subSection.Key).ToList();

                                if (subSectionViews.Count() > 0)
                                    stacks = (subSectionViews.FirstOrDefault() as StackLayout).Children.Where(view => view.ClassId == key).ToList();
                            }
                        }

                        if (stacks.Count() == 0 && dependentStack != null)
                        {
                            stacks = dependentStack.Children.Where(view => view.ClassId == key).ToList();
                        }

                        if (stacks.Count() > 0)
                        {
                            StackLayout holder = stacks.FirstOrDefault() as StackLayout;
                            if (holder != null)
                            {
                                holder.IsVisible = true;
                                return true;
                            }
                        }
                    }
                    else
                    {
                        question.Conditions.ForEach(x =>
                        {
                            var key = x.AttributeKey;
                            if (x.Target != null)
                                if (x.Target.Section != null)
                                    key = x.Target.Section.Key;
                                else if (x.Target.SubSection != null)
                                    key = x.Target.SubSection.Key;
                                else if (x.Target.Question != null)
                                    key = x.Target.Question.Key;


                            var stacks = QSections.sectionViews.SelectMany(sv => (sv.ContentView.Content as StackLayout).Children).SelectMany(y => (y as StackLayout).Children).Where(view => view.ClassId == key).ToList();

                            if (stacks.Count() == 0)
                            {
                                var subSection = QSections.Sections.SelectMany(s => s.SubSections).Where(r => r.Questions.Select(a => a.Key).Contains(question.Key)).FirstOrDefault();

                                if (subSection != null)
                                {
                                    var subSectionViews = QSections.sectionViews.SelectMany(sv => (sv.ContentView.Content as StackLayout).Children).SelectMany(y => (y as StackLayout).Children).Where(v => v.ClassId == subSection.Key).ToList();

                                    if (subSectionViews.Count() > 0)
                                        stacks = (subSectionViews.FirstOrDefault() as StackLayout).Children.Where(view => view.ClassId == key).ToList();
                                }
                            }

                            if (stacks.Count() == 0 && dependentStack != null)
                            {
                                stacks = dependentStack.Children.Where(view => view.ClassId == key).ToList();
                            }

                            if (stacks.Count() > 0)
                                stacks.FirstOrDefault().IsVisible = false;
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }

            return false;
        }

        public static void ShowImageOptions(AIImage image)
        {
            try
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await PopupNavigation.Instance.PushAsync(new PhotoUploadOptions(image, QSections.picturePageState));
                });
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, promptPageState), true));
            }
        }
    }
}
