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
    public partial class AddLocation : PopupPage
    {
        private PromptPageState promptPageState;
        private Models.Training training;
        private MessageType type;
        private Configuration configuration;
        public AddLocation(Models.Training training, PromptPageState promptPageState, Configuration configuration)
        {
            InitializeComponent();
            this.promptPageState = promptPageState;
            this.training = training;
            this.configuration = configuration;
            Init();
        }

        private void Init()
        {
            if (!string.IsNullOrEmpty(training.Location))
                Location.Text = training.Location;
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
                if (string.IsNullOrEmpty(Location.Text))
                {
                    Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("Location cannot be empty", MessageType.Regular, promptPageState)));
                }
                else
                {
                    configuration.Trainings.Find(x => x.Name == training.Name).Location = Location.Text;
                    Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
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