using DCAnalyticsMobile.Models;
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
    public partial class AddTrainingLocation : PopupPage
    {
        private PromptPageState promptPageState;
        private Models.Training training;
        private MessageType type;
        public AddTrainingLocation(Models.Training training, PromptPageState promptPageState)
        {
            InitializeComponent();
            this.promptPageState = promptPageState;
            this.training = training;
            Init();
        }

        private void Init()
        {
            Loc.Text = string.IsNullOrEmpty(training.Location) ? "" : training.Location;
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        private void OnTrainerAdded(object sender, EventArgs args)
        {
            try
            {
                if (string.IsNullOrEmpty(Loc.Text))
                {
                    Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("Location cannot be empty", MessageType.Regular, promptPageState)));
                }
                else
                {
                    Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
                    training.Location = Loc.Text;

                    promptPageState.OnResumePage(null);
                }
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