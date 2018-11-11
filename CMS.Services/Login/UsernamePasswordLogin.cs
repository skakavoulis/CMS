using CMS.Login;
using CMS.Services.Interfaces;
using System.Threading.Tasks;

namespace CMS.Services.Login
{
    public class UsernamePasswordLogin : ILoginService
    {
        public async Task<string> Authenticate()
        {
            var loginForm = new CMS.Login.LoginView();
            var res = loginForm.ShowDialog();
            if (!res.HasValue || !res.Value)
                return null;
            //var loginService = App.LoginFactory.InstatiateService();
            //return loginService.Authenticate("", "");

            var context = loginForm.DataContext as LoginViewModel;
            return $"{context?.Email}|{context?.Password}";
        }
    }
}
