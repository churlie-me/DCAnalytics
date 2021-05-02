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
    public partial class AddTrainer : PopupPage
    {
        private PromptPageState promptPageState;
        private Models.Training training;
        private MessageType type;
        private Configuration configuration;
        public AddTrainer(Models.Training training, PromptPageState promptPageState, Configuration configuration)
        {
            InitializeComponent();
            this.promptPageState = promptPageState;
            this.training = training;
            this.configuration = configuration;
            Init();
        }

        private void Init()
        {

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
                if (string.IsNullOrEmpty(Name.Text))
                {
                    Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("Name cannot be empty", MessageType.Regular, promptPageState)));
                }
                else
                {
                    configuration.Trainings.Find(x => x.Name == training.Name).Trainers.Add(new Trainer
                    {
                        Key = Guid.NewGuid().ToString(),
                        Name = Name.Text
                    });

                    AiDataStore.SaveConfiguration(configuration);
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