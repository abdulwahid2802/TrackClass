using System;

using Xamarin.Forms;

namespace TrackClass.CustomRenderers
{
    public class CustomTableView : TableView
    {
        public static BindableProperty GroupHeaderColorProperty = 
            BindableProperty.Create("GroupHeaderColor", 
                                    typeof(Color), 
                                    typeof(CustomTableView), 
                                    Color.White);

        public CustomTableView()
        {
        }

        public Color GroupHeaderColor
        {
            get { return (Color)GetValue(GroupHeaderColorProperty); }
            set { SetValue(GroupHeaderColorProperty, value); }
        }
    }
}

