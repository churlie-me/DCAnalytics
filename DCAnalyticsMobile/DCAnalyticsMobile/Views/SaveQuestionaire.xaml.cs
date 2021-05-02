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
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SaveQuestionaire : ContentPage, PromptPageState
	{
        User user;
		public SaveQuestionaire()
		{
			InitializeComponent ();

            try
            {
                user = AiDataStore.GetUser();
                if (user.UserRights.Where(x => x.ObjectType == DCAnalytics.ObjectType.Certification).ToList().Count() > 0)
                {
                    returnLbl.Text = "RETURN TO CERTIFICATE";
                    reportStatus.Text = "Submit Certification";
                }
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
            }
        }

        private void OnSubmit(object sender, EventArgs args)
        {

        }

        private void OnReturn(object sender, EventArgs args)
        {
            Navigation.RemovePage(this);
        }

        private void OnExit(object sender, EventArgs args)
        {
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            Navigation.RemovePage(this);
        }

        public void OnResumePage(object o)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void OnConfirm()
        {
            throw new NotImplementedException();
        }

        public void OnSaveDraft()
        {
            throw new NotImplementedException();
        }
    }
}