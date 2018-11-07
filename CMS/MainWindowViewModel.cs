using CMS.LoginServices;

namespace CMS
{
    public class MainWindowViewModel
    {
        public string AuthToken { get; private set; }

        public MainWindowViewModel()
        {
           
        }

        public async void LoadAuthToken()
        {
            var service = new UsernamePasswordLogin();
            AuthToken = await service.GetAuthToken();
        }

    }
}
