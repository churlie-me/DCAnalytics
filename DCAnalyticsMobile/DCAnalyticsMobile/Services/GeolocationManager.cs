using DCAnalyticsMobile.Views.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace DCAnalyticsMobile.Services
{
    public class GeolocationManager
    {
        private LocationPageState lps;
        private PromptPageState promptPageState;
        public GeolocationManager(LocationPageState lps = null, PromptPageState promptPageState = null)
        {
            this.lps = lps;
            this.promptPageState = promptPageState;
        }

        public async void TurnOnLocation()
        {
            bool _enabled = false;
            try
            {
                _enabled = DependencyService.Get<IGeoLocationSettings>().OpenSettings().Result;
            }
            catch(Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, Models.MessageType.Regular, lps), true);
            }
        }

        public Task<Location> GetLocationAsync()
        {
            try
            {
                return DependencyService.Get<IGeoLocationSettings>().GetLocation();
            }
            catch(Exception ex)
            {
                Task.Run(async () =>await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, Models.MessageType.Regular, promptPageState), true));
                return null;
            }
        }

        public Task<bool> IsGpsEnabledAsync()
        {
            try
            {
                var _enabled = DependencyService.Get<IGeoLocationSettings>().IsGpsEnabled();
                return _enabled;
            }
            catch(Exception ex)
            {
                Log.Warning("GPS STATUS", ex.Message);
                Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox(ex.StackTrace, Models.MessageType.Regular, lps), true));
                return Task.FromResult(false);
            }
        }
    }
}