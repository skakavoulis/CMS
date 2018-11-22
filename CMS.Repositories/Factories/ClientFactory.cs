using CMS.Repositories.Interfaces;
using CMS.Tools;
using Unity;

namespace CMS.Repositories.Factories
{
    public class ClientFactory : BaseFactory<IClientRepository>
    {
        public override void RegisterInterfaces()
        {
            Container.RegisterType<IClientRepository, TestClientsRepository>();
        }
    }
}
