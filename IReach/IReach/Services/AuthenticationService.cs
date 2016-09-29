using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Interfaces;
using IReach.Services;
using Xamarin.Forms;

[assembly:Dependency(typeof(AuthenticationService))]
namespace IReach.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private string _AuthenticationClientId;
        private string _AuthenticationClientID;
        private string _Authority;
        // Authenticator interface (Device specific)
        readonly IAuthenticator _authenticator;
        private bool _authenticationResult = false;

        // TODO: configuration fecter interface


        public AuthenticationService()
        {
            _authenticator = DependencyService.Get<IAuthenticator>();  
        }
       
        public bool IsAuthenticated
        {
            get
            {
                if (_AuthenticationBypassed)
                    return true;
                else
                {
                    return _authenticationResult;
                }

            } 
        }

        bool _AuthenticationBypassed;
        public void BypassAuthentication()
        {
            _AuthenticationBypassed = true;
        }

        // Change this to Async Function
        public async Task<bool> AuthenticateAsync ( )
        {
            _authenticationResult = await _authenticator.Authenticate(_AuthenticationClientID);

            var accessToken = await GetTokenAsync();

            return true;
        }
  
        public async Task<string> GetTokenAsync()
        {
            // TODO: Hardcoded for now
            _Authority = "iReach";
            return await _authenticator.FetchToken(_Authority);
        }
        async Task GetConfig()
        {
            if (_AuthenticationClientID == null)
            {
                _AuthenticationClientID = $"IREACHDEMOID";
            }
        }
    }
}
