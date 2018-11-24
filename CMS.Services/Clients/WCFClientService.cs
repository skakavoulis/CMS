using CMS.Models;
using CMS.Services.ClientsWebService;
using CMS.Services.Interfaces;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;

namespace CMS.Services.Clients
{
    public class WCFClientService : IClientService
    {
        //private ClientsServiceClient _client;
        public string AuthToken { get; set; }


        public WCFClientService()
        {
            //_client = new ClientsServiceClient("WSHttpBinding_IClientsService");
        }

        public Task<Client[]> GetClientsForBranch(string branchId)
        {
            var client = new ClientsServiceClient("WSHttpBinding_IClientsService");
            return client.GetClientsAsync(30);
        }

        public async Task<Client> AddNewClient(Client newClient)
        {
            var client = new ClientsServiceClient("WSHttpBinding_IClientsService");
            try
            {
                return await client.AddClientAsync(newClient);
            }
            catch (FaultException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }
    }
}
