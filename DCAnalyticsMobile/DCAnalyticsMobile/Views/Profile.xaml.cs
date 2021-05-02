using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Views.Popups;
using Plugin.FilePicker.Abstractions;
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
	public partial class Profile : ContentPage, PromptPageState
	{
        private Configuration configuration;
        private User user;
		public Profile ()
		{
			InitializeComponent ();

            (Application.Current.MainPage as MasterDetailPage).IsPresented = false;
        }

        private void OnEditUserName(object sender, EventArgs e)
        {
            try
            {
                var username = new ChangeUsername(this);
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(username));
            }
            catch(Exception ex)
            {

            }
        }

        private void OnEditEmailAddress(object sender, EventArgs e)
        {
            try
            {
                var changeMailAddress = new ChangeEmailAddress(this);
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(changeMailAddress));
            }
            catch(Exception ex)
            {

            }
        }

        private ChangePassword changePassword;
        private void OnEditPassword(object sender, EventArgs e)
        {
            try
            {
                changePassword = new ChangePassword(this);
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(changePassword));
            }
            catch(Exception ex)
            {

            }
        }

        protected override void OnAppearing()
        {
            Init();
        }

        private void Init()
        {
            try
            {
                configuration = AiDataStore.GetConfiguration();
                user = AiDataStore.GetUser();

                names.Text = user.Firstname + " " + user.Lastname;
                username.Text = user.UserName;
                mail.Text = user.Email;
            }
            catch(Exception ex)
            {

            }
        }

        public void OnResumePage(object o)
        {
            Init();
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