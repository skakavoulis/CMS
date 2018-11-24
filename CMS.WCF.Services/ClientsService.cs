using CMS.Models;
using CMS.Repositories.Factories;
using CMS.Repositories.Interfaces;
using CMS.WCF.Services.Extentions;
using CMS.WCF.Services.Interfaces;
using System;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.WCF.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ClientsService : IClientsService
    {
        internal static ClientFactory ClientFactory { get; } = new ClientFactory();

        private IClientRepository _clientsRepo;

        public ClientsService()
        {
            _clientsRepo = ClientFactory.InstatiateService();
        }

        public Task<Client[]> GetClients(int limit)
        {
            //Thread.CurrentPrincipal.Identity.Name.ToString();
            //var clients = _clientsRepo.GetClients(limit).Result;

            //return clients
            //    .Select(x => x.ToModel())
            //    .ToArray();
            return Task.FromResult<Client[]>(null);
        }

        public async Task<Client> AddClient(Client newClient)
        {
            var model = newClient.ToRepoModel();
            var addedClient = await _clientsRepo.AddClient(model);
            return addedClient.ToModel();
        }

        public Task<bool> RemoveClient(Guid clientId)
        {
            return _clientsRepo.RemoveClient(clientId);
        }

        public async Task<Client> UpdateClient(Client newClient)
        {
            var repoModel = newClient.ToRepoModel();
            var model = await _clientsRepo.UpdateClient(repoModel);
            return model.ToModel();
        }
    }
}
