using CoreAnimation;
using CoreGraphics;
using System;
using System.ComponentModel;
using UIKit;
using DCAnalyticsMobile.Controls;
using DCAnalyticsMobile.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LeftWhiteButton), typeof(LeftWhiteButtonRenderer))]
namespace DCAnalyticsMobile.iOS.Renderers
{
    public class LeftWhiteButtonRenderer : ButtonRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var maskingShapeLayer = new CAShapeLayer()
            {
                Path = UIBezierPath.FromRoundedRect(Bounds, UIRectCorner.BottomLeft | UIRectCorner.TopLeft, new CGSize(10, 10)).CGPath,
                BackgroundColor = UIColor.White.CGColor
        };
            Layer.Mask = maskingShapeLayer;
        }

        public override void LayoutSubviews()
        {
            var maskingShapeLayer = new CAShapeLayer()
            {
                Path = UIBezierPath.FromRoundedRect(Bounds, UIRectCorner.BottomLeft | UIRectCorner.TopLeft, new CGSize(10, 10)).CGPath,
                BackgroundColor = UIColor.White.CGColor
        };
            Layer.Mask = maskingShapeLayer;
            base.LayoutSubviews();
        }
    }
}
