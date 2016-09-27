using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReach.Services
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync();
        Task<string> GetTokenAsync();
        bool IsAuthenticated { get; } 
        void BypassAuthentication();
    }
}
