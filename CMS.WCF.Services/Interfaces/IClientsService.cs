using CMS.Models;
using System;
using System.ServiceModel;

namespace CMS.WCF.Services.Interfaces
{
    [ServiceContract]
    public interface IClientsService
    {
        [OperationContract]
        Client[] GetClients(int limit);

        [OperationContract]
        Client AddClient(Client newClient);

        [OperationContract]
        bool RemoveClient(Guid clientId);

        [OperationContract]
        Client UpdateClient(Client newClient);
    }
}
