using CMS.Services.Interfaces;
using CMS.Services.Login;
using CMS.Tools;
using Unity;

namespace CMS.Services.Factories
{
    public class LoginFactory : BaseFactory<ILoginService>
    {
        public override void RegisterInterfaces()
        {
            Container.RegisterType<ILoginService, UsernamePasswordLogin>();
        }
    }
}
