using System;
using TrackClass.CustomRenderers;
using TrackClass.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ColoredTableView), typeof(ColoredTableViewRenderer))]
namespace TrackClass.Droid.CustomRenderers
{
    public class ColoredTableViewRenderer : TableViewRenderer
    {
        public ColoredTableViewRenderer()
        {
        }
    }
}
