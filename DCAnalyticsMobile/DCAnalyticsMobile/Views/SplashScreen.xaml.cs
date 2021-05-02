using DCAnalyticsMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreen : ContentPage
    {
        public SplashScreen()
        {
            InitializeComponent();
            SplashNavigation();
        }

        private async void SplashNavigation()
        {
            try
            {
                //Delay by 5 seconds
                await Task.Delay(5000);
                new Services.Routing().Init();
                //App.Current.MainPage = new NavigationPage(new Demo());
            }
            catch (Exception ex)
            {

            }
        }
    }
}