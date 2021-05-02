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
	public partial class ForgotPassword : ContentPage, PromptPageState
    {
        private bool exists;

        public ForgotPassword ()
		{
			InitializeComponent ();
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

        private void SubmitEmail(object sender, EventArgs args)
        {
			var user = new User
			{
				Email = mail.Text
			};

			try
			{
                mail.IsEnabled = false;
                processInIndicator.IsVisible = true;
                processInIndicator.IsRunning = true;
                forgotPasswordLbl.Text = "Please wait...";
                forgotPasswordBtn.IsEnabled = false;
                Task.Factory.StartNew(async () => {
                    // Do some work on a background thread, allowing the UI to remain responsive
                    var response = Synchronization.ForgotAsync(user).Result;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    exists = JsonConvert.DeserializeObject<bool>(responseContent);
                }).ContinueWith(task => {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        if (exists)
                        {
                            await Navigation.PushAsync(new Otp(user));
                            Navigation.RemovePage(this);
                        }
                        else
                        {
                            await PopupNavigation.Instance.PushAsync(new MessageBox("No account affiliated to this email exists on our platform", MessageType.Regular, this));
                            (mail.Parent as Frame).BorderColor = Color.Red;
                        }

                        mail.IsEnabled = true;
                        forgotPasswordLbl.Text = "CONTINUE";
                        forgotPasswordBtn.IsEnabled = true;
                        processInIndicator.IsRunning = false;
                        processInIndicator.IsVisible = false;
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