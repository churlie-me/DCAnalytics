using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using Xamarin.Essentials;
using Xamarin.Forms.Internals;

namespace DCAnalyticsMobile.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressDialog : PopupPage
    {
        private PromptPageState promptPageState;
        public ProgressDialog(PromptPageState promptPageState)
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

        protected override void OnAppearing()
        {
            
        }
    }
}