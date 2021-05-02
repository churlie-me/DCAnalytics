using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Views.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Fields : ContentPage, PromptPageState
	{
        private Questionaire questionaire;
        private Configuration configuration;
        private List<FieldInspection> Inspections;
        private User User;

        public Fields (Questionaire questionaire)
		{
			InitializeComponent ();
            this.questionaire = questionaire;
            User = AiDataStore.GetUser();
		}

        public void OnExit(){}

        public void OnRebound(){}

        public void OnResumePage(object o){}

        public void OnSleepPage(){}
        public void OnConfirm()
        {
            throw new NotImplementedException();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                configuration = AiDataStore.GetConfiguration();
                Inspections = configuration.Inspections.Where(x => x.FarmerKey == questionaire.Key).ToList();

                if (Inspections.Count > 0)
                {
                    fields.IsVisible = true;
                    nofields.IsVisible = false;
                    lfieldStack.IsVisible = true;
                    fields.ItemsSource = Inspections;
                }
                else
                {
                    fields.IsVisible = false;
                    nofields.IsVisible = true;
                    lfieldStack.IsVisible = false;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private async void AddField(object sender, EventArgs args)
        {
            try
            {
                var fi = configuration.Inspections.FirstOrDefault();

                var FieldInspection = new FieldInspection()
                {
                    Template = fi.Key,
                    FieldName = "Field " + (Inspections.Count + 1).ToString(),
                    CreatedBy = User.Key,
                    Key = Guid.NewGuid().ToString(),
                    Status = DCAnalytics.Statuses.New,
                    ConfigurationId = fi.ConfigurationId,
                    DateTime = DateTime.Now,
                    FarmerKey = questionaire.Key,
                    Sections = fi.Sections
                };

                FieldInspection.Sections.SelectMany(s => s.Questions).ForEach(q => q.Answers.Clear());

                if (FieldInspection.Sections.Count > 0 || FieldInspection.Sections.SelectMany(x => x.Questions).Count() > 0)
                    await Navigation.PushAsync(new QSections(DCAnalytics.ObjectType.Inspection, questionaire, null, null, FieldInspection));
                else
                    await PopupNavigation.Instance.PushAsync(new MessageBox("This field inspection is incomplete, please contact admin for more information", MessageType.Exit, this), true);
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Exit, this), true);
            }
        }

        private async void ModifyField(object sender, ItemTappedEventArgs args)
        {
            try
            {
                var FieldInspection = args.Item as FieldInspection;
                await Navigation.PushAsync(new QSections(DCAnalytics.ObjectType.Inspection, questionaire, null, null, FieldInspection));
            }
            catch(Exception ex)
            {

            }
        }

        public void OnSaveDraft()
        {
            throw new NotImplementedException();
        }
    }
}