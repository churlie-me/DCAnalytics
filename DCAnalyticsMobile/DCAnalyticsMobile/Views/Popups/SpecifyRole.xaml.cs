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
    public partial class SpecifyRole : PopupPage
    {
        private ConfigurationPageState cps;
        private MessageType type;
        public SpecifyRole(ConfigurationPageState cps)
        {
            InitializeComponent();
            this.cps = cps;
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

        private void OnTrainingSelected(object sender, EventArgs args)
        {
            try
            {
                cps.OnTrainingRoleSeleted();
            }
            catch (Exception ex)
            {
                //DisplayAlert("Error", ex.Message);
                Debug.WriteLine($"Exception after Selection Complete:  {ex}");
            }
        }

        private void OnPurchaseSeleted(object sender, EventArgs args)
        {
            try
            {
                cps.OnPurchaseRoleSeleted();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception after Selection Complete:  {ex}");
            }
        }
    }
}