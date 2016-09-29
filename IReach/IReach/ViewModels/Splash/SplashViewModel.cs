using System.Threading.Tasks;
using IReach.ViewModels.Base;
using Xamarin.Forms;

namespace IReach.ViewModels.Splash
{
    public class SplashViewModel : BaseViewModel
    {
        // TODO: Readonly IConfig : Interface to get configuration here
        public SplashViewModel(INavigation navigation = null) : base(navigation)
        {
            // TODO: Init Configuration here
        }

        bool _IsPresentingLoginUI;

        public bool IsPresentingLoginUI
        {
            get
            {
                return _IsPresentingLoginUI;
            }
            set
            {
                _IsPresentingLoginUI = value;
                OnPropertyChanged("IsPresentingLoginUI");
            }
        }

        string _Username;

        public string Username
        {
            get { return _Username; }
            set
            {
                _Username = value;
                OnPropertyChanged("Username");
            }
        }

        string _Password;

        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged("Password");
            }
        }

        public async Task LoadCredentials()
        {
            Username = $"DemoUser";
            Password = $"DemoPassword";
        }

    }
}
