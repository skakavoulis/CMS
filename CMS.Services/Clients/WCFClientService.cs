using CMS.Models;
using CMS.Services.ClientsWebService;
using CMS.Services.Interfaces;
using System.Threading.Tasks;

namespace CMS.Services.Clients
{
    public class WCFClientService : IClientService
    {
        private ClientsServiceClient _client;
        public string AuthToken { get; set; }


        public WCFClientService()
        {

            _client = new ClientsServiceClient("WSHttpBinding_IClientsService");
            var client = new ServiceReference1.ClientsServiceClient();
            client.getc
        }

        public Task<Client[]> GetClientsForBranch(string branchId)
        {
            return _client.GetClientsAsync(30);
        }

        public Task<Client> AddNewClient(Client newClient)
        {
            return _client.AddClientAsync(newClient);
        }
    }
}
