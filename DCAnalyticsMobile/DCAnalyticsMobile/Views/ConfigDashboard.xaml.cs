using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Views.Popups;
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
    public partial class ConfigDashboard : ContentPage, PromptPageState
    {
        public ConfigDashboard()
        {
            InitializeComponent();
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

        private async void OnSurveyTapped(object sender, EventArgs args)
        {
            try
            {
                await Navigation.PushAsync(new Dashboard("Get Started"));
            }
            catch(Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.Message, Models.MessageType.Regular, this));
            }
        }

        private async void OnSettingsTapped(object sender, EventArgs args)
        {
            try
            {
                PromptConfigurationSelection();
            }
            catch(Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.Message, Models.MessageType.Regular, this));
            }
        }

        private async void OnCertificationTapped(object sender, EventArgs args)
        {
            try
            {
                await Navigation.PushAsync(new Questionaires(DCAnalytics.ObjectType.Certification, null, "Registrees"));
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.Message, Models.MessageType.Regular, this));
            }
        }

        private async void OnTrainingsTapped(object sender, EventArgs args)
        {
            try
            {
                await Navigation.PushAsync(new Trainings("Trainings"));
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.Message, Models.MessageType.Regular, this));
            }
        }

        private async void OnPurchasesTapped(object sender, EventArgs args)
        {
            try
            {
                await Navigation.PushAsync(new Questionaires(DCAnalytics.ObjectType.Purchase, null, "Registrees"));
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.Message, Models.MessageType.Regular, this));
            }
        }

        private async void OnInspectionTapped(object sender, EventArgs args)
        {
            try
            {
                await Navigation.PushAsync(new Questionaires(DCAnalytics.ObjectType.Inspection, null, "Registrees"));
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.Message, Models.MessageType.Regular, this));
            }
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

        public void OnSaveDraft()
        {
            throw new NotImplementedException();
        }
    }
}