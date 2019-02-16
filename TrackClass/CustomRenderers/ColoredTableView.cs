using System;
using Xamarin.Forms;

namespace TrackClass.CustomRenderers
{
    public class ColoredTableView : TableView
    {
        public static BindableProperty GroupHeaderColorProperty =
            BindableProperty.Create("GroupHeaderColor", 
                                    typeof(Color), 
                                    typeof(ColoredTableView), 
                                    Color.WhiteSmoke);

        public Color GroupHeaderColor
        {
            get
            {
                return (Color)GetValue(GroupHeaderColorProperty);
            }
            set
            {
                SetValue(GroupHeaderColorProperty, value);
            }
        }

        public ColoredTableView()
        {
        }
    }
}
