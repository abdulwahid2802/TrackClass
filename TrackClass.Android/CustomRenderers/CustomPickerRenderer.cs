using System;
using Android.Graphics.Drawables;
using TrackClass.CustomRenderers;
using TrackClass.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace TrackClass.Droid.CustomRenderers
{
	public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);


            if (Control == null)
                return;

            GradientDrawable gd = new GradientDrawable();
            gd.SetStroke(0, Color.White.ToAndroid());
            gd.SetCornerRadius(20);
            gd.SetColor(Color.FromHex("75ffffff").ToAndroid());

            this.Control.SetBackgroundDrawable(gd);
            this.Control.Gravity = Android.Views.GravityFlags.CenterVertical;
            this.Control.SetHintTextColor(Color.FromHex("75ffffff").ToAndroid());
            this.Control.SetPadding(20, 10, 20, 10);
        }
    }
}
