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
	public partial class Configurations : ContentPage
	{
        private PromptPageState PromptPageState;
        private List<Configuration> configurations;
        private User user;
        private Client client;
        public Configurations (User user, PromptPageState promptPageState)
		{
			InitializeComponent ();
            this.PromptPageState = promptPageState;
            this.user = user;
        }

        protected override void OnAppearing()
        {
            _configurations.IsVisible = false;
            noconfigurations.IsVisible = false;
            progressIndicator.IsVisible = true;
            InitClient();
        }

        public void InitConfigurations()
        {
            try
            {
                Task.Factory.StartNew(async () => {
                    // Do some work on a background thread, allowing the UI to remain responsive
                    var response = Synchronization.Configurations(user).Result;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    configurations = JsonConvert.DeserializeObject<List<Configuration>>(responseContent);
                }).ContinueWith(task => {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        progressIndicator.IsVisible = false;
                        if (configurations == null)
                        {   
                            Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("Unfortunately, you have not been attached to any configuration, please get in touch with your team lead to attach you to one", MessageType.Regular, PromptPageState)));
                            AiDataStore.Logout();
                            App.Current.MainPage = new NavigationPage(new SignIn());
                        }
                        else
                        {
                            Init();
                            AiDataStore.SaveConfigurations(configurations);
                        }
                    });
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

        private void InitClient()
        {
            try
            {
                Task.Factory.StartNew(async () => {
                    // Do some work on a background thread, allowing the UI to remain responsive
                    var response = Synchronization.Client(user.ClientId).Result;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    client = JsonConvert.DeserializeObject<Client>(responseContent);
                }).ContinueWith(task => {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (client != null)
                        {
                            AiDataStore.SaveClient(client);
                            InitConfigurations();
                        }
                        else
                        {
                            Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("Unfortunately, your account has no affiliation to any client, please contact your admin for a possible solution", MessageType.Regular, PromptPageState)));
                            AiDataStore.Logout();
                        }
                    });
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

        private void Init()
        {
            try
            {
                foreach (Configuration configuration in configurations)
                    configuration.Sequence = (configurations.IndexOf(configuration) % 2 == 0) ? 0 : 1;

                if (configurations.Count == 0)
                {
                    noconfigurations.IsVisible = true;
                    _configurations.IsVisible = false;
                }
                else
                {
                    noconfigurations.IsVisible = false;
                    _configurations.IsVisible = true;
                    _configurations.ItemsSource = null;
                    _configurations.ItemsSource = configurations;
                }
            }
            catch (Exception)
            {

            }
        }

        private void OnConfigurationTapped(object sender, ItemTappedEventArgs args)
        {
            try
            {
                var configuration = args.Item as Configuration;
                AiDataStore.SaveConfiguration(configuration);

                var configUser = configuration.Users.Find(u => u.OID == user.OID);
                
                //App.Current.MainPage = new MainPage(configUser.UserRights.FirstOrDefault().ObjectType);
                App.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {

            }
        }

        private void SearchConfiguration(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                _configurations.ItemsSource = configurations;
            }
            else
            {
                _configurations.ItemsSource = configurations.Where(s => s.Name.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }
    }
}