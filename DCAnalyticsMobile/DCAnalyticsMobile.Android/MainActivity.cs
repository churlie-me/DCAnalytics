using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Com.Mapbox.Mapboxsdk;
using Rg.Plugins.Popup;
using DCAnalyticsMobile.Utils;
using Plugin.CurrentActivity;
using Com.Mapbox.Mapboxsdk.Maps;
using Com.Mapbox.Mapboxsdk.Annotations;
using Com.Mapbox.Mapboxsdk.Geometry;
using static Com.Mapbox.Mapboxsdk.Maps.MapboxMap;
using Android.Content;
using Android.Support.V4.Content;
using Android.Graphics;
using Android;
using Android.Util;

[assembly: UsesFeature("android.hardware.camera", Required = true)]
[assembly: UsesFeature("android.hardware.camera.autofocus", Required = true)]

namespace DCAnalyticsMobile.Droid
{
    [Activity(Label = "DCAnalytics", Icon = "@drawable/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(savedInstanceState);

                //Initialize Popup 
                Rg.Plugins.Popup.Popup.Init(this);

                //Initialize mapbox in Android.
                Mapbox.GetInstance(this, MapBoxCredentials.AccessToken);

                //Initialize Plugin.InputKit
                Plugin.InputKit.Platforms.Droid.Config.Init(this, savedInstanceState);

                // Initailize the camera plugin.
                CrossCurrentActivity.Current.Init(this, savedInstanceState);

                //Initialize Xamarin Essentials
                Xamarin.Essentials.Platform.Init(this, savedInstanceState);

                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

                LoadApplication(new App());
            }
            catch(Exception ex)
            {

            }
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
        }

        protected override void OnStart()
        {
            base.OnStart();
            try
            {
                if (CheckSelfPermission(Manifest.Permission.AccessCoarseLocation) != (int)Permission.Granted)
                {
                    RequestPermissions(new string[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation }, 0);
                }
            }
            catch(Exception ex)
            {

            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            try
            {
                Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

                Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
            catch(Exception ex)
            {

            }
        }

        /*public override void OnBackPressed()
        {
            try
            {
                if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
                {
                    Log.Debug("", "Android back button: There are some pages in the PopupStack");
                }
                else
                {
                    Log.Debug("", "Android back button: There are not any pages in the PopupStack");
                }
            }
            catch(Exception ex)
            {

            }
        }*/
    }
}