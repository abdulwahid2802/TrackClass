using System;
using Foundation;
using TrackClass.CustomRenderers;
using TrackClass.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomTableView), typeof(CustomTableViewRenderer))]
namespace TrackClass.iOS.CustomRenderers
{
    public class CustomTableViewRenderer : TableViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            var tableView = Control as UITableView;
            var customTableView = Element as CustomTableView;
            tableView.WeakDelegate = new CustomHeaderTableViewModelRenderer(customTableView);
        }
    }

    internal class CustomHeaderTableViewModelRenderer : UnEvenTableViewModelRenderer
    {
        private CustomTableView customTableView;

        public CustomHeaderTableViewModelRenderer(CustomTableView customTableView) : base(customTableView)
        {
            this.customTableView = customTableView;
        }

        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {
            return new UILabel()
            {
                Text = TitleForHeader(tableView, section),
                TextColor = customTableView.GroupHeaderColor.ToUIColor(),
                TextAlignment = UITextAlignment.Left,
                Font = UIFont.BoldSystemFontOfSize(30)
        };
        }
    }
}
