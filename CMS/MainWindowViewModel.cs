using CMS.Interfaces;
using CMS.Tools;
using System.Windows;
using CMS.Clients;

namespace CMS
{
    public class MainWindowViewModel : BaseViewModel
    {
        public string AuthToken { get; private set; }

        private BaseViewModel _activeView;
        public BaseViewModel ActiveView
        {
            get => _activeView;
            set
            {
                _activeView = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {

        }

        public async void LoadAuthToken(IClosable owner)
        {
            var service = App.LoginFactory.InstatiateService();
            var token = await service.Authenticate();
            if (string.IsNullOrWhiteSpace(token))
            {
                owner.Close();
            }
            else
            {
                MessageBox.Show(token);
                ActiveView = new ClientsViewModel();
            }

        }

    }
}
