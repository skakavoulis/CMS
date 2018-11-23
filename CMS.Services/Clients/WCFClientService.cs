using CMS.Models;
using CMS.Services.Interfaces;
using System.Threading.Tasks;

namespace CMS.Services.Clients
{
    public class WCFClientService : IClientService
    {
        public string AuthToken { get; set; }


        public WCFClientService()
        {
        }

        public Task<Client[]> GetClientsForBranch(string branchId)
        {
            return null;
        }

        public Task<Client> AddNewClient(Client newClient)
        {
            return null;
        }
    }
}
