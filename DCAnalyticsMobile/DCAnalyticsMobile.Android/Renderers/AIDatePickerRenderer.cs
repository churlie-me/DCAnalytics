using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Graphics.Drawables;
using Android.Widget;
using DCAnalyticsMobile.Controls;
using DCAnalyticsMobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DatePicker = Xamarin.Forms.DatePicker;

[assembly: ExportRenderer(typeof(AIDatePicker), typeof(AIDatePickerRenderer))]
namespace DCAnalyticsMobile.Droid.Renderers
{
    public class AIDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            try
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetCornerRadius(25); //increase or decrease to changes the corner look
                gd.SetColor(Android.Graphics.Color.Transparent);
                gd.SetStroke(3, Android.Graphics.Color.ParseColor("#FFFFFF"));

                Control.SetTextColor(Android.Graphics.Color.ParseColor("#000000"));
                this.Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                this.Control.SetPadding(20, 0, 0, 0);
                this.Control.SetBackgroundDrawable(gd);

                AIDatePicker element = Element as AIDatePicker;
                if (!string.IsNullOrWhiteSpace(element.Placeholder))
                {
                    Control.Text = element.Placeholder;
                }
                this.Control.TextChanged += (sender, arg) =>
                {
                    var selectedDate = arg.Text.ToString();
                    if (selectedDate == element.Placeholder)
                    {
                        Control.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    }
                };
            }
            catch(Exception ex)
            {

            }
        }
    }
}