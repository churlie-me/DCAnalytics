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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Init : ContentPage, PromptPageState
    {
        public static Configuration configuration;
        public Init ()
		{
			InitializeComponent ();
        }

        private void Sync(object sender, EventArgs args)
        {
            try
            {
                //PromptConfigurationUrl();
                App.Current.MainPage = new NavigationPage(new SignIn());
            }
            catch(Exception ex)
            {

            }
        }

        private ConfigurationUrl ConfigurationUrl;
        private void PromptConfigurationUrl()
        {
            try
            {
                ConfigurationUrl = new ConfigurationUrl(this);
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(ConfigurationUrl, true));
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

        private void Attach(object sender, EventArgs args)
        {
            PromptConfigurationSelection();
        }

        private SelectConfiguration selectConfiguration;
        private void PromptConfigurationSelection()
        {
            try
            {
                selectConfiguration = new SelectConfiguration(this);
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(selectConfiguration, true));
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
        }

        public void OnResumePage(object o)
        {
            try
            {
                if((FileData)o != null)
                    ExtensionMethods.DeserializeConfiguration((FileData)o, this);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void OnSleepPage()
        {
            throw new NotImplementedException();
        }

        public void OnRebound()
        {
            try
            {
                PromptConfigurationSelection();
            }
            catch(Exception ex)
            {

            }
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