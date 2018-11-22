using CMS.Models;
using CMS.Repositories.Factories;
using CMS.Repositories.Interfaces;
using CMS.WCF.Services.Interfaces;
using System;
using System.Linq;
using System.ServiceModel;
using System.Threading;

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

        public Client[] GetClients(int limit)
        {
            Thread.CurrentPrincipal.Identity.Name.ToString();
            var clients = _clientsRepo.GetClients(limit).Result;

            return clients
                .Select(x => new Client
                {
                    ClientId = x.ClientId,
                    Address = new Address
                    {
                        City = x.Address.City,
                        Country = x.Address.Country,
                        PostCode = x.Address.PostCode,
                        StreetName = x.Address.StreetName,
                        StreetNumber = x.Address.StreetNumber
                    },
                    Name = x.Name,
                    Birthday = x.Birthday,
                    ClientSince = x.ClientSince,
                    Lastname = x.Lastname,
                    TACAccepted = x.TACAccepted,
                    Type = (ClientTypeEnum)Enum.Parse(typeof(ClientTypeEnum), x.Type.ToString())
                })
                .ToArray();
        }

        public Client AddClient(Client newClient)
        {
            
            return _clientsRepo.AddClient(newClient);
        }

        public bool RemoveClient(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public Client UpdateClient(Client newClient)
        {
            throw new NotImplementedException();
        }
    }
}
