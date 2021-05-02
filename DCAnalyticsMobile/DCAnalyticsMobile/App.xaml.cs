using DCAnalyticsMobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DCAnalyticsMobile
{
    public partial class App : Application
    {
        public static NavigationPage NavigationPage { get; private set; }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new SplashScreen());
        }
    }
}
