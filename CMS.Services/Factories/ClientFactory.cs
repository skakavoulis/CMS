using CMS.Services.Clients;
using CMS.Services.Interfaces;
using CMS.Tools;
using Unity;
using Unity.Lifetime;

namespace CMS.Services.Factories
{
    public class ClientFactory : BaseFactory<IClientService>
    {
        public override void RegisterInterfaces()
        {
            Container.RegisterType<IClientService, WCFClientService>(new TransientLifetimeManager());
        }
    }
}
