using DCAnalytics;
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
    public partial class MainPage : MasterDetailPage, PromptPageState
    {
        ObjectType permission;
        public MainPage(ObjectType permission = ObjectType.Configuration)
        {
            InitializeComponent();
            this.permission = permission;

            Init();
        }

        private void Init()
        {
            try
            {
                switch (permission)
                {
                    case ObjectType.Configuration:
                        Detail = new NavigationPage(new ConfigDashboard());
                        break;
                    case ObjectType.Inspection:
                    case ObjectType.Certification:
                    case ObjectType.Purchase:
                        Detail = new NavigationPage(new Questionaires(ObjectType.None));
                        break;
                    case ObjectType.Training:
                        Detail = new NavigationPage(new Trainings());
                        break;
                    default:
                        Detail = new NavigationPage(new Dashboard());
                        break;
                }
            }
            catch(Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true));
            }
        }

        public async void NavigateApplication(PageNavigation page)
        {
            try
            {
                switch (page)
                {
                    case PageNavigation.Profile:
                        await Navigation.PushAsync(new Profile());
                        break;
                    case PageNavigation.Settings:
                        await Navigation.PushAsync(new Settings());
                        break;
                }
            }
            catch(Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this), true);
            }
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