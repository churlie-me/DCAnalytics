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
    public partial class SelectConfiguration : PopupPage
    {
        private PromptPageState promptPageState;
        private FileData filedata;
        public SelectConfiguration(PromptPageState promptPageState)
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

        private async void OnSelect(object sender, EventArgs args)
        {
            try
            {
                filedata = await CrossFilePicker.Current.PickFile();

                if(filedata != null)
                    fileDirectory.Text = filedata.FilePath;
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
                    promptPageState.OnResumePage(filedata);
                    Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
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