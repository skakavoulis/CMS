using CMS.Services.Interfaces;
using System.Threading.Tasks;

namespace CMS.Services.Login
{
    public class TestLoginService : ILoginService
    {
        public Task<string> Authenticate()
        {
            return Task.FromResult("Instead of token");
        }
    }
}
