using System.Threading.Tasks;

namespace IReach.Interfaces
{
    public interface IAuthenticator
    {
        Task<bool> Authenticate(string clientId);
        Task<bool> DeAuthenticate(string authority);
        Task<string> FetchToken(string authority);
    }
}
