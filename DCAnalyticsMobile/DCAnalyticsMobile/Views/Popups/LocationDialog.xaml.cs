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
    public partial class LocationDialog : PopupPage, LocationPageState
    {
        private LocationPageState locationPageState;
        private LocationType locationType;
        private Location location;
        public LocationDialog(LocationPageState locationPageState, LocationType locationType = LocationType.LastKnown)
        {
            InitializeComponent();
            this.locationPageState = locationPageState;
            this.locationType = locationType;
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
            InitCoordinates();
        }

        private async void InitCoordinates()
        {
            try
            {
                /*var service = new LocationService();
                if(locationType == LocationType.Current)
                    location = await service.DeriveCurrentLocation();
                else
                    location = await service.GetDeviceLocation();*/

                results.IsVisible = false;
                btns.IsVisible = false;
                indicator.IsVisible = true;

                latitude.Text = "..........";
                longitude.Text = "..........";
                accuracy.Text = "..........";

                location = await new GeolocationManager(this).GetLocationAsync();
                if(location != null)
                {
                    results.IsVisible = true;
                    btns.IsVisible = true;
                    indicator.IsVisible = false;

                    latitude.Text = location.Latitude.ToString();
                    longitude.Text = location.Longitude.ToString();
                    accuracy.Text = location.Accuracy.ToString();
                }
            } 
            catch (Exception ex)
            {
                Log.Warning("Gps Exception", ex.Message);
            }
        }

        private void OnAttach(object sender, EventArgs args)
        {
            locationPageState.OnLocationCollected(location);
        }
        
        private void OnRetry(object sender, EventArgs args)
        {
            InitCoordinates();
        }

        public void OnLocationCollected(Location location)
        {
            throw new NotImplementedException();
        }

        public void OnEnableLocation()
        {
            throw new NotImplementedException();
        }

        public void OnLocationIgnored()
        {
            throw new NotImplementedException();
        }

        public void OnResumePage(object o)
        {
            throw new NotImplementedException();
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

        public void OnSaveDraft()
        {
            throw new NotImplementedException();
        }
    }
}