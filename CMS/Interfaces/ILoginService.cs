using System.Threading.Tasks;

namespace CMS.Interfaces
{
    public interface ILoginService
    {
        Task<string> GetAuthToken();
    }
}
