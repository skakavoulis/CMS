
using System;
using System.Windows;

namespace CMS
{
    public class MainWindowViewModel
    {
        public string AuthToken { get; private set; }

        public MainWindowViewModel()
        {

        }

        public async void LoadAuthToken()
        {
            var service = App.LoginFactory.InstatiateService();
            var token = await service.Authenticate();
            if (string.IsNullOrWhiteSpace(token))
                Environment.Exit(0);
            else
                MessageBox.Show(token);
        }

    }
}
