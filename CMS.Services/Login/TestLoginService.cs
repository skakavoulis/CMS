using CMS.Services.Interfaces;
using System.Threading.Tasks;

namespace CMS.Services.Login
{
    public class TestLoginService : ILoginService
    {
        public async Task<string> Authenticate()
        {
            return "Instead of token";
        }
    }
}
