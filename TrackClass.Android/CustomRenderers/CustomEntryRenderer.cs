using System;
using Android.Graphics.Drawables;
using TrackClass.CustomRenderers;
using TrackClass.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace TrackClass.Droid.CustomRenderers
{
	public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return; 

            GradientDrawable gd = new GradientDrawable();
            gd.SetStroke(0, Color.White.ToAndroid());
            gd.SetCornerRadius(30);
            gd.SetColor(Color.FromHex("75ffffff").ToAndroid());

            this.Control.SetBackgroundDrawable(gd);
            this.Control.Gravity = Android.Views.GravityFlags.CenterVertical;
            this.Control.SetHintTextColor(Color.FromHex("75ffffff").ToAndroid());
        }
    }
}
