using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CMS.Tools
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var input = value != null && (bool)value;
            return input
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;
            var input = (Visibility)value;
            return input == Visibility.Visible;
        }
    }
}
