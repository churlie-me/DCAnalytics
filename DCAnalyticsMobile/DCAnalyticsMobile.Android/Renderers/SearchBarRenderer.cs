using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCAnalyticsMobile.Controls;
using DCAnalyticsMobile.Droid.Renderers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(AISearchBar), typeof(AISearchBarRenderer))]
namespace DCAnalyticsMobile.Droid.Renderers
{
    public class AISearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (Control != null)
                {
                    var color = global::Xamarin.Forms.Color.LightGray;
                    var searchView = Control as SearchView;

                    int searchPlateId = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
                    Android.Views.View searchPlateView = searchView.FindViewById(searchPlateId);
                    searchPlateView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}