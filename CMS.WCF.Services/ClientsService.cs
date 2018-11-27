using CMS.Models;
using CMS.Repositories.Factories;
using CMS.Repositories.Interfaces;
using CMS.WCF.Services.Exceptions;
using CMS.WCF.Services.Extentions;
using CMS.WCF.Services.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
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

        public async Task<Client[]> GetClients(int limit)
        {
            var clients = _clientsRepo.GetClients(limit).Result;

            return clients
                .Select(x => x.ToModel())
                .ToArray();
        }

        public async Task<Client> AddClient(Client newClient)
        {
            if (!(Thread.CurrentPrincipal?.IsInRole("Administrators") ?? false))
                throw new NotAuthorizedException($"{nameof(AddClient)} can only be used by Administrators");


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
