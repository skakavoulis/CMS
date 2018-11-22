using CMS.Repositories.Models;
using System;
using System.Threading.Tasks;

namespace CMS.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<ClientRepo[]> GetClients(int limit);

        Task<ClientRepo> AddClient(ClientRepo newClient);

        Task<bool> RemoveClient(Guid clientId);

        Task<ClientRepo> UpdateClient(ClientRepo newClient);
    }
}
