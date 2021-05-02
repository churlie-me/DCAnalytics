using System;
using System.ComponentModel;
using UIKit;
using DCAnalyticsMobile.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using DCAnalyticsMobile.Controls;

[assembly: ExportRenderer(typeof(AIDatePicker), typeof(AIDatePickerRenderer))]
namespace DCAnalyticsMobile.iOS.Renderers
{
    public class AIDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            try
            {
                if (this.Control == null)
                    return;
                var element = e.NewElement as AIDatePicker;
                //if (!string.IsNullOrWhiteSpace(element.Placeholder))
                //{
                //    Control.Text = element.Placeholder;
                //}
                if (element == null) return;

                Console.WriteLine($"Element Value: {element.WidthRequest}");
                Control.BorderStyle = UITextBorderStyle.RoundedRect;
                Control.Layer.BorderColor = Color.FromHex("#FFFFFF").ToCGColor();
                Control.Layer.CornerRadius = 10;
                Control.Layer.BorderWidth = 1f;
                Control.AdjustsFontSizeToFitWidth = true;
                Control.TextColor = Color.FromHex("#000000").ToUIColor();

                Control.ShouldEndEditing += (textField) =>
                {
                    var seletedDate = (UITextField)textField;
                    var text = seletedDate.Text;
                    Console.WriteLine($"Selected Date {text}");
                    if (!string.IsNullOrWhiteSpace(text) && text == element.Placeholder)
                    {
                        Control.Text = DateTime.Now.ToString("DD/MM/YYYY");
                    }
                    return true;
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatePicker Renderer Exception : " + ex.Message);
            }
        }
        private void OnCanceled(object sender, EventArgs e)
        {
            Control.ResignFirstResponder();
        }
        private void OnDone(object sender, EventArgs e)
        {
            Control.ResignFirstResponder();
        }
    }
}
