using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Purchases : ContentPage
    {
        private Configuration configuration;
        private Questionaire questionaire;

        public Purchases(Questionaire questionaire)
        {
            InitializeComponent();
            
            this.questionaire = questionaire;
        }

        private void Init()
        {
            configuration = AiDataStore.GetConfiguration();
            var _purchases = configuration.Purchases.Where(x => x.Farmer == questionaire.Key).ToList();
            if (_purchases.Count > 0)
            {
                purchases.IsVisible = true;
                nextPageFAB.IsVisible = true;
                nopurchases.IsVisible = false;
                purchases.ItemsSource = _purchases;
            }
            else
            {
                purchases.IsVisible = false;
                nextPageFAB.IsVisible = false;
                nopurchases.IsVisible = true;
            }
        }

        protected override void OnAppearing()
        {
            Init();
        }

        private async void Purchase(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Purchase(null, questionaire));
        }

        private async void OnPurchaseTapped(object sender, ItemTappedEventArgs args)
        {
            await Navigation.PushAsync(new Purchase( args.Item as Models.Purchase, questionaire));
        }
    }
}