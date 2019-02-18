using System;
using Android.Content;
using Android.Widget;
using TrackClass.CustomRenderers;
using TrackClass.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomTableView), typeof(CustomTableViewRenderer))]
namespace TrackClass.Droid.CustomRenderers
{
    public class CustomTableViewRenderer : TableViewRenderer
    {
        protected override TableViewModelRenderer GetModelRenderer(Android.Widget.ListView listView, TableView view)
        {
            return new CustomHeaderTableViewModelRenderer(Context, listView, view);
        }
    }
}
