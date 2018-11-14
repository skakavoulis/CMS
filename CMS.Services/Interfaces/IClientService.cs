using CMS.Services.Models;
using System.Threading.Tasks;

namespace CMS.Services.Interfaces
{
    public interface IClientService
    {
        string AuthToken { get; set; }

        Task<Client[]> GetClientsForBranch(string branchId);
        Task<Client> AddNewClient(Client newClient);
    }
}
