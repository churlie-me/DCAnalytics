using DCAnalyticsMobile.Services;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using DCAnalyticsMobile.Controls;

namespace DCAnalyticsMobile.Views.Popups
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PhotoUploadOptions : PopupPage
    {
        private PicturePageState _pageState;
        private AIImage Image;
		public PhotoUploadOptions(AIImage image, PicturePageState pageState)
		{
            this._pageState = pageState;
			InitializeComponent ();
            this.Image = image;
		}

        private async void OpenCamera(object sender, EventArgs args)
        {
            try
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsTakePhotoSupported && CrossMedia.Current.IsPickPhotoSupported)
                    return;
                else
                {
                    MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        SaveToAlbum = true,
                        Directory = "DCAnalytics",
                        CompressionQuality = 40,
                        CustomPhotoSize = 35,
                        PhotoSize = PhotoSize.MaxWidthHeight,
                        MaxWidthHeight = 2000,
                        Name = "DCAnalytics" + DateTime.Now.ToString("yyyymmdd_hhmmss") + ".jpg"
                    }).ConfigureAwait(true);

                    if (file == null)
                        return;
                    await PopupNavigation.Instance.RemovePageAsync(this);
                    _pageState.OnPictureSelected(Image, file);
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        private async void OpenGallery(object sender, EventArgs args)
        {
            try
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsPickPhotoSupported)
                    return;

                var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    CompressionQuality = 40,
                    CustomPhotoSize = 35,
                    PhotoSize = PhotoSize.MaxWidthHeight,
                    MaxWidthHeight = 2000
                }).ConfigureAwait(true);

                if (file == null)
                    return;

                await PopupNavigation.Instance.RemovePageAsync(this);
                _pageState.OnPictureSelected(Image, file);
            }
            catch(Exception ex)
            {

            }
        }
    }
}