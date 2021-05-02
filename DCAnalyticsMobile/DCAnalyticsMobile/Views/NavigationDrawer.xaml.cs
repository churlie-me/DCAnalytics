using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Views.Popups;
using Newtonsoft.Json;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationDrawer : ContentPage, PromptPageState
    {
        private User user;
        private Client client;
        private Synchronize Synchronize;
        private bool isSynchronized = true;
        private HelpCenter HelpCenter;
        private ProgressDialog progressDialog;
        private Configuration configuration;
        public NavigationDrawer()
        {
            InitializeComponent();
            user = AiDataStore.GetUser();
            client = AiDataStore.Client();
            Init();
        }

        private void Init()
        {
            if (user != null)
                username.Text = user.Firstname + " " + user.Lastname;
            if (client != null)
                _client.Text = client.Name;
        }

        protected override void OnAppearing()
        {
            
        }

        private void OnConfigurationsTapped(object sender, EventArgs args)
        {

        }

        private async void OnSynchronizationTapped(object sender, EventArgs args)
        {
            try
            {
                configuration = AiDataStore.GetConfiguration();
                (Application.Current.MainPage as MasterDetailPage).IsPresented = false;
                Synchronize = new Synchronize(this);
                await PopupNavigation.Instance.PushAsync(Synchronize);
            }
            catch(Exception ex)
            {

            }
        }

        async void StartSynchronization()
        {
            try
            {
                await SynchronizeQuestionaires();
                await SynchronizeInspections();
                await SynchronizeCertifications();
                await SynchronizePurchases();
                await SynchronizeTrainings();

                await PopupNavigation.Instance.RemovePageAsync(progressDialog);
                if(isSynchronized)
                    await PopupNavigation.Instance.PushAsync(new MessageBox("Your configuration has been successfully synchronized", MessageType.Info, this));
                else
                    await PopupNavigation.Instance.PushAsync(new MessageBox("Your configuration has not entirely been synchronized", MessageType.Regular, this));
            }
            catch(Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox("Something went wrong while synchronizing data, please try again", MessageType.Info, this));
            }            
        }

        private async Task SynchronizeQuestionaires()
        {
            try
            {
                var questionaires = configuration.Questionaires.Where(q => q.Status != DCAnalytics.Statuses.Template).ToList();
                for (int q = questionaires.Count - 1; q >= 0; q--)
                {
                    var questionaire = questionaires[q];
                    var result = await Task.Factory.StartNew(async () => {
                        var response = Data.Synchronization.SynchronizeQuestionaire(questionaire).Result;
                        var responseContent = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<bool>(responseContent);
                    });

                    isSynchronized = !isSynchronized ? isSynchronized : result.Result;
                    if (isSynchronized)
                    {
                        configuration.Questionaires.Remove(questionaire);
                    }
                }

                AiDataStore.SaveConfiguration(configuration);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private async Task SynchronizeInspections()
        {
            try
            {
                var inspections = configuration.Inspections.Where(x => !string.IsNullOrEmpty(x.FarmerKey)).ToList();
                for(int i = inspections.Count - 1; i >= 0; i--)
                {
                    var inspection = inspections[i];
                    var result = await Task.Factory.StartNew(async () => {
                        var response = Data.Synchronization.SynchronizeInspection(inspection).Result;
                        var responseContent = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<bool>(responseContent);
                    });

                    isSynchronized = !isSynchronized ? isSynchronized : result.Result;
                    if (isSynchronized)
                    {
                        configuration.Inspections.Remove(inspection);
                    }
                }

                AiDataStore.SaveConfiguration(configuration);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task SynchronizeCertifications()
        {
            try
            {
                var certifications = configuration.Certifications.Where(q => q.Status != DCAnalytics.Statuses.Template).ToList();
                for (int c = certifications.Count - 1; c >= 0; c--)
                {
                    var certification = certifications[c];
                    var result = await Task.Factory.StartNew(async () => {
                        var response = Data.Synchronization.SynchronizeCertification(certification).Result;
                        var responseContent = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<bool>(responseContent);
                    });

                    isSynchronized = !isSynchronized ? isSynchronized : result.Result;
                    if (isSynchronized)
                    {
                        configuration.Certifications.Remove(certification);
                    }
                }

                AiDataStore.SaveConfiguration(configuration);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task SynchronizePurchases()
        {
            try
            {
                for (int p = configuration.Purchases.Count - 1; p >= 0; p--)
                {
                    var purchase = configuration.Purchases[p];
                    var result = await Task.Factory.StartNew(async () => {
                        var response = Data.Synchronization.SynchronizePurchase(purchase).Result;
                        var responseContent = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<bool>(responseContent);
                    });

                    isSynchronized = !isSynchronized ? isSynchronized : result.Result;
                    if (isSynchronized)
                    {
                        configuration.Purchases.Remove(purchase);
                    }
                }

                AiDataStore.SaveConfiguration(configuration);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task SynchronizeTrainings()
        {
            try
            {
                for (int t = configuration.Trainings.Count - 1; t >= 0; t--)
                {
                    var training = configuration.Trainings[t];
                    var result = await Task.Factory.StartNew(async () => {
                        var response = Data.Synchronization.SynchronizeTraining(training).Result;
                        var responseContent = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<bool>(responseContent);
                    });

                    isSynchronized = !isSynchronized ? isSynchronized : result.Result;
                    if (isSynchronized)
                    {
                        training.Trainees.Clear();
                    }
                }

                AiDataStore.SaveConfiguration(configuration);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void OnHelpCenter_Tapped(object sender, EventArgs args)
        {
            try
            {
                (Application.Current.MainPage as MasterDetailPage).IsPresented = false;
                HelpCenter = new HelpCenter(this);
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(HelpCenter));
            }
            catch(Exception ex)
            {

            }
        }

        private void OnProfileTapped(object sender, EventArgs args)
        {
            try
            {
                (Application.Current.MainPage as MasterDetailPage).IsPresented = false;
                (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new Profile());
            }
            catch (Exception ex)
            {

            }
        }

        private void OnSettingsTapped(object sender, EventArgs args)
        {
            try
            {
                (Application.Current.MainPage as MasterDetailPage).IsPresented = false;
                (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new Settings());
            }
            catch (Exception ex)
            {

            }
        }

        private void OnSignOutTapped(object sender, EventArgs args)
        {
            try
            {
                (Application.Current.MainPage as MasterDetailPage).IsPresented = false;
                configuration = AiDataStore.GetConfiguration();
                if (!IsDataExisting())
                    Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("You have unsynchronized data, are you sure you want to logout?", MessageType.Logout, this)));
                else
                    OnExit();
            }
            catch (Exception ex)
            {

            }
        }

        bool IsDataExisting()
        {
            try
            {
                if (configuration.Questionaires.Where(q => q.Status != DCAnalytics.Statuses.Template).Count() > 0)
                    return false;
                if (configuration.Certifications.Where(q => q.Status != DCAnalytics.Statuses.Template).Count() > 0)
                    return false;
                if (configuration.Inspections.Where(q => q.Status != DCAnalytics.Statuses.Template).Count() > 0)
                    return false;
                if (configuration.Purchases.Count > 0)
                    return false;
                if (configuration.Trainings.SelectMany(t => t.Trainees).Count() > 0)
                    return false;
            }
            catch(Exception ex)
            {

            }

            return true;
        }

        public void OnResumePage(object o)
        {

        }

        public void OnSleepPage()
        {
            
        }

        public async void OnRebound()
        {
            try
            {
                if (Synchronize.Sync)
                {
                    progressDialog = new ProgressDialog(this);
                    await PopupNavigation.Instance.PushAsync(progressDialog);
                    StartSynchronization();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public void OnExit()
        {
            try
            {
                AiDataStore.Logout();
                App.Current.MainPage = new NavigationPage(new SignIn());
            }
            catch(Exception ex)
            {

            }
        }

        public void OnConfirm()
        {
            
        }

        public void OnSaveDraft()
        {
            
        }
    }
}