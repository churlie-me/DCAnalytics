using DCAnalyticsMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Configuration = DCAnalyticsMobile.Models.Configuration;

namespace DCAnalyticsMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Trainings : ContentPage
	{
        private Configuration configuration;
		public Trainings (string Title = null)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Title))
                this.Title = Title;

            this.configuration = AiDataStore.GetConfiguration();
            Init();
		}

        private void Init()
        {
            if (configuration.Trainings.Count > 0)
            {
                trainings.IsVisible = true;
                notrainings.IsVisible = false;
                trainings.ItemsSource = configuration.Trainings;
            }
            else
            {
                trainings.IsVisible = false;
                notrainings.IsVisible = true;
            }
        }

        private async void OnTrainingTapped(object sender, ItemTappedEventArgs args)
        {
            await Navigation.PushAsync(new Training(args.Item as Models.Training, configuration));
        }

        private void AiSearchTextChanged(object sender, EventArgs args)
        {

        }
    }
}