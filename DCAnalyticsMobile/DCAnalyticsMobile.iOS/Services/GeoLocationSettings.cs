using System;
using System.IO;
using Foundation;
using SQLite;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.iOS.Services;
using Xamarin.Forms;
using UIKit;
using System.Threading.Tasks;

[assembly: Dependency(typeof(GeoLocationSettings))]
namespace DCAnalyticsMobile.iOS.Services
{
    public class GeoLocationSettings : IGeoLocationSettings
    {
        //public void OpenSettings()
        //{
        //    try
        //    {
        //        if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
        //        {
        //            // For iOS 8 and 9, we can navigate automatically to the settings
        //            NSUrl url = new NSUrl(UIKit.UIApplication.OpenSettingsUrlString);
        //            bool result = UIApplication.SharedApplication.OpenUrl(url);
        //        }
        //        else
        //        {
        //            // Below iOS 8, the user has to navigate manually to the settings
        //            UIAlertView uiAlert = new UIAlertView(
        //                "Location Services Required",
        //                "Authorisation to use your location is required to use this feature of the app. To use this feature please go to the settings app and enable location services",
        //                null,
        //                "Ok");
        //            uiAlert.Show();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //Task<bool> IGeoLocationSettings.OpenSettings()
        //{
        //    throw new NotImplementedException();
        //}

        Task IsGpsEnabled()
        {
            return Task.FromResult(true);
        }

        Task OpenSettings()
        {
            try
            {
                if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
                {
                    // For iOS 8 and 9, we can navigate automatically to the settings
                    NSUrl url = new NSUrl(UIKit.UIApplication.OpenSettingsUrlString);
                    bool result = UIApplication.SharedApplication.OpenUrl(url);
                }
                else
                {
                    // Below iOS 8, the user has to navigate manually to the settings
                    UIAlertView uiAlert = new UIAlertView(
                        "Location Services Required",
                        "Authorisation to use your location is required to use this feature of the app. To use this feature please go to the settings app and enable location services",
                        null,
                        "Ok");
                    uiAlert.Show();
                }
            }
            catch (Exception ex)
            {

            }

            return Task.FromResult(true);
        }
    }
}
