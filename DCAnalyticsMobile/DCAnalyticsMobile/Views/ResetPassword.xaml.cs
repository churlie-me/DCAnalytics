using DCAnalyticsMobile.Data;
using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Views.Popups;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPassword : ContentPage, PromptPageState
    {
        private User user;
        private bool isPasswordChanged;
        public ResetPassword(User user = null)
        {
            InitializeComponent();
            this.user = user;
        }

        public void OnConfirm()
        {
            throw new NotImplementedException();
        }

        public void OnExit()
        {
            throw new NotImplementedException();
        }

        public void OnRebound()
        {
            throw new NotImplementedException();
        }

        public void OnResumePage(object o)
        {
            throw new NotImplementedException();
        }

        public void OnSleepPage()
        {
            throw new NotImplementedException();
        }

        private async void Reset(object sender, EventArgs args)
        {
            try
            {
                if(string.IsNullOrEmpty(Password.Text) || string.IsNullOrEmpty(CPassword.Text.Trim()))
                {
                    await PopupNavigation.Instance.PushAsync(new MessageBox("Enter both passwords to proceed", MessageType.Regular, this));
                    _error.IsVisible = true;
                    return;
                }

                if(!Password.Text.Trim().Equals(CPassword.Text.Trim()))
                {
                    _error.IsVisible = true;
                    return;
                }

                user.Password = Password.Text.Trim();
                Password.IsEnabled = false;
                CPassword.IsEnabled = false;
                processInIndicator.IsVisible = true;
                processInIndicator.IsRunning = true;
                resetPasswordLbl.Text = "Please wait...";
                resetPasswordBtn.IsEnabled = false;
                Task.Factory.StartNew(async () => {
                    // Do some work on a background thread, allowing the UI to remain responsive
                    var response = Synchronization.ResetPassword(user).Result;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    isPasswordChanged = JsonConvert.DeserializeObject<bool>(responseContent);
                }).ContinueWith(task => {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        if (isPasswordChanged)
                        {
                            await Navigation.PushAsync(new SignIn());
                            Navigation.RemovePage(this);
                        }
                        else
                            await PopupNavigation.Instance.PushAsync(new MessageBox("Something went wrong, please try again", MessageType.Regular, this));

                        resetPasswordLbl.Text = "CONTINUE";
                        Password.IsEnabled = true;
                        CPassword.IsEnabled = true;
                        processInIndicator.IsVisible = false;
                        processInIndicator.IsRunning = false;
                    });
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

        public void OnSaveDraft()
        {
            throw new NotImplementedException();
        }
    }
}