using CMS.Services.Clients;
using CMS.Services.Interfaces;
using Unity;

namespace CMS.Services.Factories
{
    public class ClientFactory : BaseFactory<IClientService>
    {
        internal override void RegisterInterfaces()
        {
            Container.RegisterType<IClientService, TestClientService>();
        }
    }
}
