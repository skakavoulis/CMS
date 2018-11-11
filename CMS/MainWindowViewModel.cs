
using System;
using System.Windows;
using CMS.Interfaces;

namespace CMS
{
    public class MainWindowViewModel
    {
        public string AuthToken { get; private set; }

        public MainWindowViewModel()
        {

        }

        public async void LoadAuthToken(IClosable owner)
        {
            var service = App.LoginFactory.InstatiateService();
            var token = await service.Authenticate();
            if (string.IsNullOrWhiteSpace(token))
                owner.Close();
            else
                MessageBox.Show(token);
        }

    }
}
