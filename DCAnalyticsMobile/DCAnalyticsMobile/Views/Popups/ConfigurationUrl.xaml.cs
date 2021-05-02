using DCAnalyticsMobile.Services;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigurationUrl : PopupPage
    {
        private PromptPageState promptPageState;
        private FileData filedata;
        public ConfigurationUrl(PromptPageState promptPageState)
        {
            InitializeComponent();
            this.promptPageState = promptPageState;
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        private void OnSelect(object sender, EventArgs args)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception after Selection Complete:  {ex}");
            }
        }

        private void OnProceed(object sender, EventArgs args)
        {
            try
            {
                if (filedata != null)
                {
                    Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
                    promptPageState.OnResumePage(filedata);
                }
                else
                    DisplayAlert(null, "Please select a configuration file to proceed", "Ok");
            }
            catch (Exception ex)
            {
                //DisplayAlert("Error", ex.Message);
                Debug.WriteLine($"Exception after Selection Complete:  {ex}");
            }
        }

        private void OnCancel(object sender, EventArgs args)
        {
            try
            {
                Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
            }
            catch (Exception ex)
            {
                //DisplayAlert("Error", ex.Message);
                Debug.WriteLine($"Exception after Selection Complete:  {ex}");
            }
        }
    }
}