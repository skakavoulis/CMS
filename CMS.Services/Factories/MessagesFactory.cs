using CMS.Services.Interfaces;
using CMS.Services.Messages;
using CMS.Tools;
using Unity;
using Unity.Lifetime;

namespace CMS.Services.Factories
{
    public class MessagesFactory : BaseFactory<IMessagesService>
    {
        public override void RegisterInterfaces()
        {
            Container.RegisterType<IMessagesService, MessagesService>(new SingletonLifetimeManager());
        }
    }
}
