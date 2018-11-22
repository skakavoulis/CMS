using CMS.Models;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CMS.WCF.Services.Interfaces
{
    [ServiceContract]
    public interface IClientsService
    {
        [OperationContract]
        Task<Client[]> GetClients(int limit);

        [OperationContract]
        Task<Client> AddClient(Client newClient);

        [OperationContract]
        Task<bool> RemoveClient(Guid clientId);

        [OperationContract]
        Task<Client> UpdateClient(Client newClient);
    }
}
