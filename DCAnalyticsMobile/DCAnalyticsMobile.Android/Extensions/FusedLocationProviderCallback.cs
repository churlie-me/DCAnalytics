using Android.App;
using Android.Content;
using Android.Gms.Location;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCAnalyticsMobile.Droid.Extensions
{
    public class FusedLocationProviderCallback : LocationCallback
    {
        readonly MainActivity activity;

        public FusedLocationProviderCallback(MainActivity activity = null)
        {
            this.activity = activity;
        }

        public override void OnLocationAvailability(LocationAvailability locationAvailability)
        {
            Log.Debug("FusedLocationProviderSample", "IsLocationAvailable: {0}", locationAvailability.IsLocationAvailable);
        }

        public override void OnLocationResult(LocationResult result)
        {
            try
            {
                if (result.Locations.Any())
                {
                    var location = result.Locations.First();
                    Log.Debug("Sample", "The latitude is :" + location.Latitude);
                }
                else
                {
                    // No locations to work with.
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}