using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCAnalyticsMobile.Services;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using System.IO;
using DCAnalyticsMobile.Droid.Services;
using System.Threading.Tasks;
using Android.Support.V4.App;
using Android;
using Android.Content.PM;
using Android.Gms.Common.Apis;
using Android.Gms.Location;
using Android.Gms.Common;
using Plugin.CurrentActivity;
using static Android.Gms.Common.Apis.GoogleApiClient;
using Java.Interop;
using Android.Support.V4.Content;
using Android.Util;
using DCAnalyticsMobile.Droid.Extensions;
using Android.Support.Design.Widget;

[assembly: Dependency(typeof(GeoLocationSettings))]
namespace DCAnalyticsMobile.Droid.Services
{
    public class GeoLocationSettings : IGeoLocationSettings, Android.Locations.ILocationListener
    { 
        private Xamarin.Essentials.Location location;
        private FusedLocationProviderClient fusedLocationProviderClient;
        private bool isRequestingLocationUpdates;
        private LocationManager locationManager;

        private LocationRequest locationRequest;
        private LocationCallback locationCallback;

        public GeoLocationSettings()
        {
            InitLocation();
        }

        private Context ctx;

        bool OpenSettings()
        {
            Console.WriteLine("Got here");

            return false;
        }

        private Intent intent;

        public IntPtr Handle => throw new NotImplementedException();

        public int JniIdentityHashCode => throw new NotImplementedException();

        public JniObjectReference PeerReference => throw new NotImplementedException();

        public JniPeerMembers JniPeerMembers => throw new NotImplementedException();

        public JniManagedPeerStates JniManagedPeerState => throw new NotImplementedException();

        Task<bool> IGeoLocationSettings.OpenSettings()
        {
            try
            {
                LocationManager LM = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);

                if (LM.IsProviderEnabled(LocationManager.GpsProvider) == false)
                {
                    ctx = Android.App.Application.Context;
                    intent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
                    intent.AddFlags(ActivityFlags.NewTask);
                    ctx.StartActivity(intent);
                }

                return Task.FromResult(true);
            }
            catch(Exception ex)
            {
                Log.Error("GPS EXCEPTION", ex.StackTrace);
                return Task.FromResult(false);
            }
        }

        Task<bool> IGeoLocationSettings.IsGpsEnabled()
        {
            try
            {
                LocationManager LM = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);

                return Task.FromResult(LM.IsProviderEnabled(LocationManager.GpsProvider));
            }
            catch(Exception ex)
            {
                Log.Error("GPS EXCEPTION", ex.StackTrace);
                return Task.FromResult(false);
            }
        }

        public async Task<Xamarin.Essentials.Location> GetLocation()
        {
            try
            {
                if (IsGooglePlayServicesInstalled())
                {
                    if (ContextCompat.CheckSelfPermission(CrossCurrentActivity.Current.Activity, Manifest.Permission.AccessFineLocation) == Permission.Granted)
                        return await GetLastLocation();
                    else
                        RequestLocationPermission(2444);

                    //List<string> _providers = locationManager.GetProviders(true).ToList();

                    /*Location bestLocation = null;
                    foreach (var _provider in _providers)
                    {
                        Location location = locationManager.GetLastKnownLocation(_provider);
                        if (location == null)
                            continue;
                        if (bestLocation == null || location.Accuracy < bestLocation.Accuracy)
                            bestLocation = location;
                    }*/
                    /*var location = locationManager.GetLastKnownLocation(LocationManager.GpsProvider);
                    if (location != null)
                    {
                        return new Xamarin.Essentials.Location
                        {
                            Accuracy = location.Accuracy,
                            Altitude = location.Altitude,
                            Latitude = location.Latitude,
                            Longitude = location.Longitude,
                            Speed = location.Speed
                        };
                    }*/
                }

                return null;
            }
            catch(Exception ex)
            {
                Log.Error("GPS EXCEPTION", ex.StackTrace);
            }

            return null;
        }

        async Task<Xamarin.Essentials.Location> GetLastLocation()
        {
            try
            {
                //var location = locationManager.GetLastKnownLocation(LocationManager.GpsProvider);

                var location = await fusedLocationProviderClient.GetLastLocationAsync();

                if (location != null)
                {
                    Toast.MakeText(CrossCurrentActivity.Current.Activity, "Accuracy => " + location.Accuracy, ToastLength.Long);
                    return new Xamarin.Essentials.Location
                    {
                        Accuracy = location.Accuracy,
                        Altitude = location.Altitude,
                        Latitude = location.Latitude,
                        Longitude = location.Longitude,
                        Speed = location.Speed
                    };
                }
                else
                    Log.Info("GPS STATUS", "Trouble retrieving location");
            }
            catch(Exception ex)
            {
                Log.Error("GPS EXCEPTION", ex.StackTrace);
            }

            return null;
        }

        void RequestLocationPermission(int requestCode)
        {
            try
            {
                if (ActivityCompat.ShouldShowRequestPermissionRationale(CrossCurrentActivity.Current.Activity, Manifest.Permission.AccessFineLocation))
                {
                    ActivityCompat.RequestPermissions(CrossCurrentActivity.Current.Activity, new[] { Manifest.Permission.AccessFineLocation }, requestCode);
                }
                else
                {
                    ActivityCompat.RequestPermissions(CrossCurrentActivity.Current.Activity, new[] { Manifest.Permission.AccessFineLocation }, requestCode);
                }
            }
            catch(Exception ex)
            {
                Log.Error("GPS EXCEPTION", ex.StackTrace);
            }
        }


        async Task StartRequestingLocationUpdates()
        {
            try
            {
                await fusedLocationProviderClient.RequestLocationUpdatesAsync(locationRequest, locationCallback);
            }
            catch(Exception ex)
            {
                Log.Error("GPS EXCEPTION", ex.StackTrace);
            }
        }

        public async void InitLocation()
        {
            try
            {
                if (ContextCompat.CheckSelfPermission(CrossCurrentActivity.Current.AppContext, Manifest.Permission.AccessFineLocation) == Permission.Granted)
                {
                    //locationManager = (LocationManager)CrossCurrentActivity.Current.AppContext.GetSystemService(Context.LocationService);

                    InitLocationRequest();
                    await StartRequestingLocationUpdates();
                    isRequestingLocationUpdates = true;
                }
                else
                {
                    // The app does not have permission ACCESS_FINE_LOCATION 
                    RequestLocationPermission(2444);
                }
            }
            catch(Exception ex)
            {
                Log.Error("GPS EXCEPTION", ex.StackTrace);
            }
        }

        private void InitLocationRequest()
        {
            try
            {
                locationRequest = new LocationRequest()
                                      .SetPriority(LocationRequest.PriorityHighAccuracy)
                                      .SetInterval(6 * 1000 * 2)
                                      .SetFastestInterval(6 * 1000);

                locationCallback = new FusedLocationProviderCallback((MainActivity) CrossCurrentActivity.Current.Activity);
                fusedLocationProviderClient = LocationServices.GetFusedLocationProviderClient(CrossCurrentActivity.Current.Activity);

                /*Criteria locationCriteria = new Criteria();
                //locationCriteria.Accuracy = Accuracy.High;
                locationCriteria.PowerRequirement = Power.High;

                var locationProvider = locationManager.GetBestProvider(locationCriteria, true);

                var intent = new Intent(CrossCurrentActivity.Current.Activity, typeof(MainActivity));
                var resultPendingIntent = PendingIntent.GetActivity(Forms.Context, 0, intent, PendingIntentFlags.OneShot);

                locationManager.RequestLocationUpdates(locationProvider, 2000, 1, resultPendingIntent);*/
            }
            catch(Exception ex)
            {
                Log.Error("GPS EXCEPTION", ex.StackTrace);
            }
        }

        bool IsGooglePlayServicesInstalled()
        {
            try
            {
                var queryResult = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(CrossCurrentActivity.Current.AppContext);
                if (queryResult == ConnectionResult.Success)
                {
                    Log.Info("MainActivity", "Google Play Services is installed on this device.");
                    return true;
                }

                if (GoogleApiAvailability.Instance.IsUserResolvableError(queryResult))
                {
                    // Check if there is a way the user can resolve the issue
                    var errorString = GoogleApiAvailability.Instance.GetErrorString(queryResult);
                    Log.Error("MainActivity", "There is a problem with Google Play Services on this device: {0} - {1}",
                              queryResult, errorString);

                    // Alternately, display the error to the user.
                }
            }
            catch(Exception ex)
            {
                Log.Error("GPS EXCEPTION", ex.StackTrace);
            }


            return false;
        }

        public void OnLocationChanged(Location location)
        {
            Log.Info("NEW GPS", location.Latitude + ", " + location.Longitude);
        }

        public void OnProviderDisabled(string provider)
        {
            Log.Info("GPS STATUS", provider + " has been disabled");
        }

        public void OnProviderEnabled(string provider)
        {
            Log.Info("GPS STATUS", provider + " has been enabled");
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            
        }

        public void SetJniIdentityHashCode(int value)
        {
            
        }

        public void SetPeerReference(JniObjectReference reference)
        {
            
        }

        public void SetJniManagedPeerState(JniManagedPeerStates value)
        {
            
        }

        public void UnregisterFromRuntime()
        {
            
        }

        public void DisposeUnlessReferenced()
        {
            
        }

        public void Disposed()
        {
            
        }

        public void Finalized()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}