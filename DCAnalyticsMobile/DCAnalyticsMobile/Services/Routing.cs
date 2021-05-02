using System;
using System.Collections.Generic;
using System.Text;
using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using DCAnalyticsMobile.Views.Popups;
using Plugin.FilePicker.Abstractions;

namespace DCAnalyticsMobile.Services
{
    public class Routing : PromptPageState
    {
        private User user;
        private Configuration configuration;

        public Routing()
        {

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

        public void OnConfirm()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            try
            {
                user = AiDataStore.GetUser();
                configuration = AiDataStore.GetConfiguration();
                if (configuration != null && user != null)
                {
                    StartApplication();
                }
                else
                    App.Current.MainPage = new NavigationPage(new Init());
            }
            catch(Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this)));
            }
        }

        private void StartApplication()
        {
            try
            {
                var configUser = configuration.Users.Find(u => u.OID == user.OID);
                if (configUser != null)
                    App.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, MessageType.Regular, this)));
            }
        }

        public void OnSaveDraft()
        {
            throw new NotImplementedException();
        }
    }
}
