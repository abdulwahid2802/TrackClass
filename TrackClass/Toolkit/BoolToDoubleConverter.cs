using System;
using System.Globalization;
using Xamarin.Forms;

namespace TrackClass.Toolkit
{
    public class BoolToDoubleConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 0.0 : 1.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
