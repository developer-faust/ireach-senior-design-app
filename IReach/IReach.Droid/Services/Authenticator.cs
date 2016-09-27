using System.Threading.Tasks;
using IReach.Droid.Services;
using IReach.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Authenticator))]
namespace IReach.Droid.Services
{
    public class Authenticator : IAuthenticator
    {
        public async Task<bool> Authenticate(string clientId)
        { 
            // TODO: implement authentication for now return true 

            await Task.Delay(App.AnimationSpeed);
            return true;

        }

        public async Task<bool> DeAuthenticate(string authority)
        {
            await Task.Delay(App.AnimationSpeed);
            return true;
        }

        public async Task<string> FetchToken(string authority)
        {

            await Task.Delay(App.AnimationSpeed);
            return $"123456789";
        }
    }
}