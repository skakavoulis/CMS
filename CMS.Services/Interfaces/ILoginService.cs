using System.Threading.Tasks;

namespace CMS.Services.Interfaces
{
    public interface ILoginService
    {
        Task<string> Authenticate();
    }
}
