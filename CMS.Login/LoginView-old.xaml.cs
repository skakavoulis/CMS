﻿//using System;
//using System.Globalization;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using CMS.LoginView.Interfaces;

//namespace CMS.Login
//{
//    /// <summary>
//    /// Interaction logic for LoginView.xaml
//    /// </summary>
//    public partial class LoginViewOld : Window, IDialogResult
//    {
//        public LoginView()
//        {
//            InitializeComponent();
//        }


//        private void CancelButton_Click(object sender, RoutedEventArgs e)
//        {
//            DialogResult = false;
//        }

//        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
//        {
//            if (!(DataContext is LoginViewModel viewModel))
//                return;

//            viewModel.Password = (sender as PasswordBox)?.SecurePassword;
//        }
//    }

//    //internal class BooleanToVisibilityConverter : IValueConverter
//    //{
//    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//    //    {
//    //        var trueValue = (bool)value;
//    //        return (trueValue)
//    //            ? Visibility.Visible
//    //            : Visibility.Hidden;
//    //    }

//    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//    //    {
//    //        var trueValue = (Visibility)value;
//    //        return (trueValue == Visibility.Visible);
//    //    }
//    //}
//}
