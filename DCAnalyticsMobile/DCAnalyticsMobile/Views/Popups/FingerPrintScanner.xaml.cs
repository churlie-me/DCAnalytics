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
using System.Threading;
using System.Threading.Tasks;
using Plugin.Fingerprint.Abstractions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FingerPrintScanner : PopupPage
    {
        private PromptPageState promptPageState;
        private CancellationTokenSource _cancel;
        private bool _initialized;
        public FingerPrintScanner(PromptPageState promptPageState)
        {
            InitializeComponent();
            this.promptPageState = promptPageState;

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

        private async void OnAuthenticate(object sender, EventArgs e)
        {
            await AuthenticationAsync("Put your finger!");

        }
        private async Task AuthenticationAsync(string reason, string cancel = null, string fallback = null, string tooFast = null)
        {
            _cancel = swAutoCancel.IsToggled ? new CancellationTokenSource(TimeSpan.FromSeconds(10)) : new CancellationTokenSource();
            lblStatus.Text = "";

            var dialogConfig = new AuthenticationRequestConfiguration(reason)
            { // all optional
                CancelTitle = cancel,
                FallbackTitle = fallback,
                AllowAlternativeAuthentication = swAllowAlternative.IsToggled
            };

            // optional

            var result = await Plugin.Fingerprint.CrossFingerprint.Current.AuthenticateAsync(dialogConfig, _cancel.Token);

            await SetResultAsync(result);
        }

        private async Task SetResultAsync(FingerprintAuthenticationResult result)
        {
            if (result.Authenticated)
            {
                await DisplayAlert("FingerPrint Sample", "Success", "Ok");
            }
            else
            {
                await DisplayAlert("FingerPrint Sample", result.ErrorMessage, "Ok");
            }
        }

        private void OnProceed(object sender, EventArgs args)
        {
            try
            {
                Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));

                promptPageState.OnResumePage(null);
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