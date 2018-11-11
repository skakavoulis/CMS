using CMS.Repositories;
using CMS.Repositories.Interfaces;
using CMS.Services.Interfaces;
using CMS.Services.Login;
using Unity;

namespace CMS.Services.Factories
{
    public class LoginFactory : BaseFactory<ILoginService>
    {
        internal override void RegisterInterfaces()
        {
            Container.RegisterType<ILoginRepository, LoginRepository>();
            Container.RegisterType<ILoginService, UsernamePasswordLogin>();
        }
    }
}
