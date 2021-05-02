using Plugin.Geolocator.Abstractions;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DCAnalyticsMobile.Services
{
    interface ILocationService
    {
        Task<Location> GetDeviceLocation();
        Task<Location> GetLastKnownDeviceLocation();
        Task<Location> DeriveCurrentLocation();
    }

    public class LocationService : ILocationService
    {
        Location location;
        Position position;
        public async Task<Location> GetDeviceLocation()
        {
            try
            {
                // Do some work on a background thread, allowing the UI to remain responsive
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium);
                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken cancelToken = source.Token;
                location = await Geolocation.GetLastKnownLocationAsync();

                if(location == null)
                    location = await Geolocation.GetLocationAsync(request, cancelToken);

                //while (location.Accuracy < accuracy)
                //    location = await Geolocation.GetLastKnownLocationAsync();

                return location;
            }
            catch (FeatureNotSupportedException fnsEx)
            {

            }
            catch (FeatureNotEnabledException fneEx)
            {

            }
            catch (PermissionException pEx)
            {

            }
            catch (Exception ex)
            {

            }

            return null;
        }



        public async Task<Location> GetLastKnownDeviceLocation()
        {
            try
            {
                location = await Geolocation.GetLastKnownLocationAsync();
            }
            catch (FeatureNotSupportedException fnsEx)
            {

            }
            catch (FeatureNotEnabledException fneEx)
            {

            }
            catch (PermissionException pEx)
            {

            }
            catch (Exception ex)
            {

            }

            return location;
        }

        double accuracy = 20;
        public async Task<Location> DeriveCurrentLocation()
        {
            try
            {
                /*var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = accuracy;

                if (locator.IsGeolocationAvailable && locator.IsGeolocationEnabled)
                {
                    position = await locator.GetPositionAsync(new TimeSpan(50000));
                    return position;
                }*/

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium);
                CancellationToken cancelToken = new CancellationTokenSource().Token;
                location = await Geolocation.GetLocationAsync(request, cancelToken);

                return location;
            }
            catch (Exception ex)
            {

            }

            return null;
        }
    }
}
