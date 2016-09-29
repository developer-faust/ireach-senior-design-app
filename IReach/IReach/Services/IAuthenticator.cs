using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  

namespace IReach.Services
{
    public interface IAuthenticator
    {
        Task<bool> Authenticate(string clientId);
        Task<bool> DeAuthenticate(string authority);
        Task<string> FetchToken(string authority);
    }
}
