using CMS.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class LoginService : ILoginService
    {
        public Task<string> Authenticate(string email, string password)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "Instead of token";
            });
        }
    }
}
