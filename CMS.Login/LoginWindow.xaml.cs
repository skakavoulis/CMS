using CMS.LoginView.Interfaces;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CMS.Login
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, IDialogResult
    {

        public LoginWindow()
        {
            InitializeComponent();
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!(DataContext is LoginViewModel viewModel))
                return;

            viewModel.Password = (sender as PasswordBox)?.SecurePassword;
        }
    }

    public class BooleanToVisibilityConverter : IValueConverter
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

