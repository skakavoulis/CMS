using CMS.Services.Interfaces;
using System.Threading.Tasks;
using CMS.Login;

namespace CMS.Services.Login
{
    public class UsernamePasswordLogin : ILoginService
    {
        public Task<string> Authenticate()
        {
            var loginForm = new CMS.Login.LoginView();
            var res = loginForm.ShowDialog();
            if (!res.HasValue || !res.Value)
                return null;

            var context = loginForm.DataContext as LoginViewModel;
            return Task.FromResult($"{context?.Email}|{context?.Password}");
        }
    }
}
