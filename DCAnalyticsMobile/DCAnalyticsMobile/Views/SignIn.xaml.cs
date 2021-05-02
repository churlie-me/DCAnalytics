using DCAnalyticsMobile.Data;
using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Views.Popups;
using Newtonsoft.Json;
using Plugin.FilePicker.Abstractions;
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
	public partial class SignIn : ContentPage, PromptPageState
    {
        private User user;
        private Configuration configuration;
        private Command ShowHidePasswordCommand = new Command(ShowHidePassword);

        private static void ShowHidePassword(object obj)
        {
            IsHidePassword = !IsHidePassword;
        }

        private static bool IsHidePassword = true;

        public SignIn ()
		{
			InitializeComponent ();
            configuration = AiDataStore.GetConfiguration();
            Password.IsPassword = true;
        }

        private void ShowHidePassword(object sender, TappedEventArgs args)
        {
            IsHidePassword = !IsHidePassword;
            Password.IsPassword = IsHidePassword;
        }

        private void AuthorizeUser(object sender, EventArgs args)
        {
            try
            {
                if (configuration != null)
                    Authorize();
                else
                    Authentication();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

        private void Authentication()
        {
            try
            {
                Password.IsEnabled = false;
                Username.IsEnabled = false;
                processInIndicator.IsVisible = true;
                processInIndicator.IsRunning = true;
                signInLbl.Text = "Please wait...";
                signInBtn.IsEnabled = false;
                Task.Factory.StartNew(async () => {
                    // Do some work on a background thread, allowing the UI to remain responsive
                    var response = Synchronization.SignInAsync(Username.Text, Password.Text).Result;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(responseContent);
                }).ContinueWith(task => {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (user != null)
                        {
                            if (string.IsNullOrEmpty(user.UserName))
                            {
                                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("Wrong username or password", MessageType.Regular, this)));
                                (Username.Parent as Frame).BorderColor = Color.Red;
                                ((Password.Parent as Grid).Parent as Frame).BorderColor = Color.Red;
                            }
                            else if(!user.Enabled)
                            {
                                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("Your acccount has beeen disabled, please contact your administrator for a possible solution", MessageType.Regular, this)));
                            }
                            else
                            {
                                AiDataStore.SaveUser(user);
               //                 if (user.UserRights != null)
               //                {
               //                     var userRights = user.UserRights.Where(x => x.Configuration.OID > 0).ToList();
                                
               //                     if (userRights.Count > 0)
               //                     {
                                        App.Current.MainPage = new NavigationPage(new Configurations(user, this));
               //                     }
               //                     else
               //                    {
               //                         Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("You have no affiliated permissions to use this application, please contact your administrator for a solution", MessageType.Regular, this)));
               //                         AiDataStore.Logout();

               //                     }
               //                 }
               //                 else
               //                     Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("You have no affiliated permissions to use this application, please contact your administrator for a solution", MessageType.Regular, this)));
                            }
                        }
                        else
                            Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("Something went wrong, please try again", MessageType.Regular, this)));

                        signInLbl.Text = "SIGN IN";
                        Password.IsEnabled = true;
                        Username.IsEnabled = true;
                        signInBtn.IsEnabled = true;
                        processInIndicator.IsRunning = false;
                        processInIndicator.IsVisible = false;
                    });
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch(Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

        public void Authorize()
        {
            //Show progress indicator
            processInIndicator.IsVisible = true;
            processInIndicator.IsRunning = true;
            signInLbl.Text = "Please wait...";

            Task.Factory.StartNew(async () =>
            {
                // Do some work on a background thread, allowing the UI to remain responsive
                user = configuration.Users.Find(x => x.UserName == Username.Text && x.Password == Password.Text);
            }).ContinueWith(task =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        Task.Run(async () => await Task.Delay(5000));
                        //Hide progress indicator
                        processInIndicator.IsRunning = false;
                        processInIndicator.IsVisible = false;

                        if (user != null)
                        {
                            AiDataStore.SaveUser(user);
                            StartApplication(user.UserRights.FirstOrDefault().ObjectType);
                        }
                        else
                        {
                            Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("Wrong username or password", MessageType.Regular, this)));
                            signInLbl.Text = "SIGN IN";
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void StartApplication(DCAnalytics.ObjectType objectType)
        {
            try
            {
                var configUser = configuration.Users.Find(u => u.OID == user.OID);
                if(configUser != null)
                    App.Current.MainPage = new MainPage(configUser.UserRights.FirstOrDefault().ObjectType);
            }
            catch (Exception ex)
            {

            }
        }

        private async void ForgotPassword(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ForgotPassword());
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

        public void ShowHidePassword(object sender, EventArgs args)
        {
            try
            {
                Password.IsPassword = false;
                _showhidePassword.Source = Password.IsPassword ? "ic_eye_hide" : "ic_eye";
            }
            catch(Exception ex)
            {

            }
        }
    }
}