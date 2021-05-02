using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Views.Popups;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Training = DCAnalyticsMobile.Models.Training;

namespace DCAnalyticsMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Training : ContentPage, PromptPageState
	{
        private Models.Training training;
        private Configuration configuration;

        public Training (Models.Training training, Configuration configuration)
		{
			InitializeComponent ();
            this.training = training;
            this.configuration = configuration;
            Init();
        }

        private void Init()
        {
            trainers.ItemsSource = training.Trainers;
            topics.ItemsSource = training.Topics;
        }

        AddTrainer addTrainer;
        private async void AddTrainer(object sender, EventArgs args)
        {
            addTrainer = new AddTrainer(training, this, configuration);
            await PopupNavigation.Instance.PushAsync(addTrainer, true);
        }

        public void OnResumePage(object o)
        {
            Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(addTrainer));

            trainers.ItemsSource = null;
            trainers.ItemsSource = training.Trainers;
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

        private async void AddLocation(object sender, EventArgs args)
        {
            await PopupNavigation.Instance.PushAsync(new AddLocation(training, this, configuration), true);
        }

        private Trainees trainees;
        private async void AddTrainees(object sender, EventArgs args)
        {
            trainees = new Trainees(configuration, training,null);
            await Navigation.PushAsync(trainees);
        }

        public void OnSaveDraft()
        {
            throw new NotImplementedException();
        }
    }
}