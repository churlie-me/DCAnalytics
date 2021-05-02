using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DCAnalyticsMobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Button = Xamarin.Forms.Button;
using DCAnalyticsMobile.Controls;

[assembly: ExportRenderer(typeof(LeftWhiteButton), typeof(LeftWhiteButtonRenderer))]
namespace DCAnalyticsMobile.Droid.Renderers
{
    class LeftWhiteButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            try
            {
                if (Control != null)
                {
                    Control.SetBackgroundResource(Resource.Drawable.LeftWhiteButton);
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}