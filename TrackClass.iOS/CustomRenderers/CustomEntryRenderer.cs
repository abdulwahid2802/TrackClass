using System;
using TrackClass.CustomRenderers;
using TrackClass.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace TrackClass.iOS.CustomRenderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            this.Control.Layer.BorderColor = Color.FromHex("75ffffff").ToCGColor();
            this.Control.TintColor = UIColor.White;
        }
    }
}
