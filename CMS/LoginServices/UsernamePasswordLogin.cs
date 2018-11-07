using CMS.Interfaces;
using CMS.Login;
using System.Threading.Tasks;

namespace CMS.LoginServices
{
    public class UsernamePasswordLogin : ILoginService
    {
        public Task<string> GetAuthToken()
        {
            var loginForm = new LoginView();
            loginForm.ShowDialog();
            var loginService = App.LoginFactory.InstatiateService();
            return loginService.Authenticate("", "");
        }
    }
}
