using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using TrackClass.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace TrackClass.Droid.CustomRenderers
{
    public class CustomHeaderTableViewModelRenderer : TableViewModelRenderer
    {
        CustomTableView _customTableView;

        public CustomHeaderTableViewModelRenderer(Context context, Android.Widget.ListView listView, TableView view) 
            : base(context, listView, view)
        {
            _customTableView = view as CustomTableView;
        }

        public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
        {
            var view = base.GetView(position, convertView, parent);
            var element = base.GetCellForPosition(position);

            if(element.GetType() == typeof(TextCell))
            {
                try
                {
                    var layout = view as LinearLayout;

                    var textView = (((layout.GetChildAt(0) as LinearLayout).GetChildAt(1) as LinearLayout).GetChildAt(0) as TextView);
                    textView.SetTextColor(_customTableView.GroupHeaderColor.ToAndroid());
                    textView.SetTextSize(Android.Util.ComplexUnitType.Dip, 25);

                    var divider = layout.GetChildAt(1);
                    divider.SetBackgroundColor(Color.FromHex("a5ffffff").ToAndroid());
                }
                catch(Exception e)
                {}
            }


            return view;
        }
    }
}