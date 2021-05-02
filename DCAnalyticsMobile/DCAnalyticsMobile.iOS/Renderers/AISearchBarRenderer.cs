using System;
using System.ComponentModel;
using UIKit;
using DCAnalyticsMobile.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using DCAnalyticsMobile.Controls;

[assembly: ExportRenderer(typeof(AISearchBar), typeof(AISearchBarRenderer))]
namespace DCAnalyticsMobile.iOS.Renderers
{
    public class AISearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (Control != null)
            {
                Control.ShowsCancelButton = false;

                UITextField txSearchField = (UITextField)Control.ValueForKey(new Foundation.NSString("searchField"));
                txSearchField.BackgroundColor = UIColor.White;
                txSearchField.BorderStyle = UITextBorderStyle.None;
                txSearchField.Layer.BorderWidth = 1.0f;
                txSearchField.Layer.CornerRadius = 2.0f;
                txSearchField.Layer.BorderColor = UIColor.LightGray.CGColor;

            }
        }
    }
}
