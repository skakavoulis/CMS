using CMS.Login.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace CMS.Login
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window, IDialogResult
    {
        public LoginView()
        {
            InitializeComponent();
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!(DataContext is LoginViewModel viewModel))
                return;

            viewModel.Password = (sender as PasswordBox)?.SecurePassword;
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}

