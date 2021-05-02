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

namespace DCAnalyticsMobile.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpCenter : PopupPage
    {
        private PromptPageState promptPageState;
        public HelpCenter(PromptPageState promptPageState)
        {
            InitializeComponent();
            this.promptPageState = promptPageState;
        }

        private void OnCancel(object sender, EventArgs args)
        {
            Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
        }

        private void OnProceed(object sender, EventArgs args)
        {
            try
            {
                PlacePhoneCall("0414672152");
                Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
            }
            catch (Exception ex)
            {
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.Message, MessageType.Regular, promptPageState), true));
            }
        }

        public void PlacePhoneCall(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}