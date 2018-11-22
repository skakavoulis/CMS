using CMS.Models;
using CMS.Services.Interfaces;
using CMS.Tools;

namespace CMS.Clients
{
    public class ClientsViewModel : BaseViewModel
    {
        private IClientService _clientService;

        public ClientsViewModel(IClientService clientService)
        {
            _clientService = clientService;
            LoadClients = new RelayCommand(OnLoadClients, CanLoadClients);
            AddClient = new RelayCommand(AddNewClient);
        }

        public string BranchId { get; set; } = "br-145";

        private bool _busy;

        public bool Busy
        {
            get => _busy;
            set
            {
                SetPropertyValue(ref _busy, value);
                LoadClients.OnCanExecuteChanged();
            }
        }


        private string[] _customerTypes = { "Όλοι", "Εταιρικοί", "Ιδιώτες" };

        public string[] CustomerTypes
        {
            get => _customerTypes;
            set => SetPropertyValue(ref _customerTypes, value);
        }

        private string _selectedCustomerType = "Όλοι";

        public string SelectedCustomerType
        {
            get => _selectedCustomerType;
            set => SetPropertyValue(ref _selectedCustomerType, value);
        }

        #region commands

        #region Clients

        private Client[] _clients;

        public Client[] Clients
        {
            get => _clients;
            set => SetPropertyValue(ref _clients, value);
        }

        public RelayCommand LoadClients { get; set; }

        public async void OnLoadClients(object parameter)
        {
            if (Busy)
                return;

            Busy = true;
            Clients = new Client[0];
            Clients = await _clientService.GetClientsForBranch(BranchId);
            Busy = false;

        }

        public bool CanLoadClients(object parameter)
        {
            return !Busy;
        }


        public event OnAddNewClient OnAddNewClient;

        public RelayCommand AddClient { get; set; }

        public void AddNewClient(object parameter)
        {
            OnAddNewClient?.Invoke(this);
        }



        #endregion

        #endregion


    }

    public delegate void OnAddNewClient(BaseViewModel sender);
}
