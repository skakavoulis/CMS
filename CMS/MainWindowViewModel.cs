using CMS.Clients;
using CMS.Interfaces;
using CMS.MessageManager;
using CMS.Models;
using CMS.NewClient;
using CMS.Services.Interfaces;
using CMS.Tools;
using System.Windows;

namespace CMS
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IClientService _clientService;
        private IMessagesService _msg;

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

            _msg = App.MessagesFactory.InstatiateService();
            _msg.MessageReceived += _msg_MessageReceived;
        }

        private void _msg_MessageReceived(object sender, MessageReceivedDelegateArgs args)
        {
            MessageBox.Show(args.Message);
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
            var service = App.LoginFactory.InstatiateService();
            var token = await service.Authenticate();
            //if (string.IsNullOrWhiteSpace(token))
            //{
            //    owner.Close();
            //}
            //else
            //{
            _clientService.AuthToken = token;
            ActiveView = _clientsViewModel;

            var messageManager = new MessagesManagerView();
            messageManager.Show();
            //}

        }

    }
}
