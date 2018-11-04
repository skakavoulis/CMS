using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CMS.Login
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void PasswordBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            (DataContext as LoginViewModel).Password = (sender as PasswordBox).SecurePassword.ToString();
        }
    }

    internal class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var trueValue = (bool)value;
            return (trueValue)
                ? Visibility.Visible
                : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var trueValue = (Visibility)value;
            return (trueValue == Visibility.Visible);
        }
    }
}
