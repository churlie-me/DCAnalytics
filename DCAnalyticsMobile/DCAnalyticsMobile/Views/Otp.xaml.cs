using DCAnalyticsMobile.Controls;
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
    public partial class Otp : ContentPage, PromptPageState
    {
        private User user;
        private string code;
        public Otp(User user = null)
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

        private void CodeChanged(object sender, TextChangedEventArgs e)
        {
            code = !string.IsNullOrEmpty((sender as AIEntry).Text)? code + (sender as AIEntry).Text : code.Take(code.Length - 1).ToString();
            switch (code.Length)
            {
                case 0:
                    code1.Focus();
                    break;
                case 1:
                    code1.Focus();
                    break;
                case 2:
                    code2.Focus();
                    break;
                case 3:
                    code3.Focus();
                    break;
                case 4:
                    code4.Focus();
                    break;
                case 5:
                    VerifyUser();
                    break;
            }
        }

        private void SubmitCode(object sender, EventArgs args)
        {
            VerifyUser();
        }

        void VerifyUser()
        {
            try
            {
                if (string.IsNullOrEmpty(code))
                {
                    _error.IsVisible = true;
                    return;
                }

                user.Usercode = code;
                code0.IsEnabled = false;
                code1.IsEnabled = false;
                code2.IsEnabled = false;
                code3.IsEnabled = false;
                code4.IsEnabled = false;
                processInIndicator.IsVisible = true;
                processInIndicator.IsRunning = true;
                submitLbl.Text = "Please wait...";
                submitBtn.IsEnabled = false;
                Task.Factory.StartNew(async () => {
                    // Do some work on a background thread, allowing the UI to remain responsive
                    var response = Synchronization.VerifyUser(user).Result;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(responseContent);
                }).ContinueWith(task => {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        if (user != null)
                        {
                            await Navigation.PushAsync(new ResetPassword(user));
                            Navigation.RemovePage(this);
                        }
                        else
                        {
                            await PopupNavigation.Instance.PushAsync(new MessageBox("The code you enter isn't correct, please enter a correct one and try again", MessageType.Regular, this));
                            _error.IsVisible = true;
                        }

                        submitLbl.Text = "CONTINUE";
                        code0.IsEnabled = true;
                        code1.IsEnabled = true;
                        code2.IsEnabled = true;
                        code3.IsEnabled = true;
                        code4.IsEnabled = true;
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
            try { } catch (Exception ex) { }
        }
    }
}