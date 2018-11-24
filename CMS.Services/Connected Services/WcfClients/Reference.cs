﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMS.Services.WcfClients {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WcfClients.IClientsService")]
    public interface IClientsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientsService/GetClients", ReplyAction="http://tempuri.org/IClientsService/GetClientsResponse")]
        CMS.Models.Client[] GetClients(int limit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientsService/GetClients", ReplyAction="http://tempuri.org/IClientsService/GetClientsResponse")]
        System.Threading.Tasks.Task<CMS.Models.Client[]> GetClientsAsync(int limit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientsService/AddClient", ReplyAction="http://tempuri.org/IClientsService/AddClientResponse")]
        CMS.Models.Client AddClient(CMS.Models.Client newClient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientsService/AddClient", ReplyAction="http://tempuri.org/IClientsService/AddClientResponse")]
        System.Threading.Tasks.Task<CMS.Models.Client> AddClientAsync(CMS.Models.Client newClient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientsService/RemoveClient", ReplyAction="http://tempuri.org/IClientsService/RemoveClientResponse")]
        bool RemoveClient(System.Guid clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientsService/RemoveClient", ReplyAction="http://tempuri.org/IClientsService/RemoveClientResponse")]
        System.Threading.Tasks.Task<bool> RemoveClientAsync(System.Guid clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientsService/UpdateClient", ReplyAction="http://tempuri.org/IClientsService/UpdateClientResponse")]
        CMS.Models.Client UpdateClient(CMS.Models.Client newClient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientsService/UpdateClient", ReplyAction="http://tempuri.org/IClientsService/UpdateClientResponse")]
        System.Threading.Tasks.Task<CMS.Models.Client> UpdateClientAsync(CMS.Models.Client newClient);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IClientsServiceChannel : CMS.Services.WcfClients.IClientsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ClientsServiceClient : System.ServiceModel.ClientBase<CMS.Services.WcfClients.IClientsService>, CMS.Services.WcfClients.IClientsService {
        
        public ClientsServiceClient() {
        }
        
        public ClientsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ClientsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClientsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClientsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public CMS.Models.Client[] GetClients(int limit) {
            return base.Channel.GetClients(limit);
        }
        
        public System.Threading.Tasks.Task<CMS.Models.Client[]> GetClientsAsync(int limit) {
            return base.Channel.GetClientsAsync(limit);
        }
        
        public CMS.Models.Client AddClient(CMS.Models.Client newClient) {
            return base.Channel.AddClient(newClient);
        }
        
        public System.Threading.Tasks.Task<CMS.Models.Client> AddClientAsync(CMS.Models.Client newClient) {
            return base.Channel.AddClientAsync(newClient);
        }
        
        public bool RemoveClient(System.Guid clientId) {
            return base.Channel.RemoveClient(clientId);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveClientAsync(System.Guid clientId) {
            return base.Channel.RemoveClientAsync(clientId);
        }
        
        public CMS.Models.Client UpdateClient(CMS.Models.Client newClient) {
            return base.Channel.UpdateClient(newClient);
        }
        
        public System.Threading.Tasks.Task<CMS.Models.Client> UpdateClientAsync(CMS.Models.Client newClient) {
            return base.Channel.UpdateClientAsync(newClient);
        }
    }
}
