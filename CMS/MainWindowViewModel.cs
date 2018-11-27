using CMS.Interfaces;
using CMS.Tools;
using System.Windows;
using CMS.Clients;
using CMS.Models;
using CMS.NewClient;
using CMS.Services.Interfaces;

namespace CMS
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IClientService _clientService;

        private ClientsViewModel _clientsViewModel;
        private NewClientViewModel _newClientViewModel;

        public string AuthToken { get; private set; }

        private BaseViewModel _activeView;
        public BaseViewModel ActiveView
        {
            get => _activeView;
            set => SetPropertyValue(ref _activeView, value);
        }

        public MainWindowViewModel()
        {
            _clientService = App.ClientFactory.InstatiateService();
            _clientsViewModel = new ClientsViewModel(_clientService);
            _clientsViewModel.OnAddNewClient += ClientsViewModelOnAddNewClient;
            _newClientViewModel = new NewClientViewModel();
            _newClientViewModel.NewClientCreated += _newClientViewModel_NewClientCreated;
            _newClientViewModel.NewClientCancelled += _newClientViewModel_NewClientCancelled;
        }

        private void _newClientViewModel_NewClientCancelled(object sender)
        {
            ActiveView = _clientsViewModel;
        }

        private async void _newClientViewModel_NewClientCreated(object sender, Client args)
        {
            await _clientService.AddNewClient(args);
            ActiveView = _clientsViewModel;
        }

        private void ClientsViewModelOnAddNewClient(BaseViewModel sender)
        {
            ActiveView = _newClientViewModel;
        }

        public async void LoadAuthToken(IClosable owner)
        {
            //ActiveView = _clientsViewModel;

            var service = App.LoginFactory.InstatiateService();
            var token = await service.Authenticate();
            if (string.IsNullOrWhiteSpace(token))
            {
                owner.Close();
            }
            else
            {
                MessageBox.Show(token);
                _clientService.AuthToken = token;
                ActiveView = new ClientsViewModel(_clientService);
            }

        }

    }
}
