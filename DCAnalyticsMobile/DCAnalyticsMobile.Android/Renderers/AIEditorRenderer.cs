using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using DCAnalyticsMobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DCAnalyticsMobile.Controls;

[assembly: ExportRenderer(typeof(AIEditor), typeof(AIEditorRenderer))]
namespace DCAnalyticsMobile.Droid.Renderers
{
    public class AIEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            try
            {
                if (Control != null)
                {
                    GradientDrawable gd = new GradientDrawable();
                    gd.SetColor(global::Android.Graphics.Color.Transparent);
                    this.Control.SetBackground(gd);

                    this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                    Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.LightSlateGray));
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}