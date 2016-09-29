using System;
using System.Threading.Tasks;
using IReach.Pages.Base;
using IReach.Services;
using IReach.Statics;
using IReach.ViewModels;
using Xamarin.Forms;

namespace IReach.Pages.Splash
{
    public partial class SplashPage : SplashPageXaml
    {
        private readonly IAuthenticationService _authenticationService;

        public SplashPage()
        {
            InitializeComponent();

            BindingContext = new SplashViewModel();
            _authenticationService = DependencyService.Get<IAuthenticationService>();

            SignInButton.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    NumberOfTapsRequired = 1,
                    Command = new Command(SignInButtonTapped)
                });

            SkipSignInButton.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    NumberOfTapsRequired = 1,
                    Command = new Command(SkipSignInButtonTapped)
                });
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // Get sample credentials
            await ViewModel.LoadCredentials();

            // Simulate login using animation
            await Task.Delay(App.AnimationSpeed);

            // Animate login buttons
            await SignInButton.ScaleTo(1, (uint) App.AnimationSpeed, Easing.SinIn);
            await SkipSignInButton.ScaleTo( 1, (uint)App.AnimationSpeed, Easing.SinIn);

        }

        async Task<bool> Authenticate()
        {
            bool success = false;

            try
            {
                success = await _authenticationService.AuthenticateAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                // Hide LoginUI 
                ViewModel.IsPresentingLoginUI = false;
            }

            return success;
        }
        async void SkipSignInButtonTapped(object obj)
        {
            _authenticationService.BypassAuthentication();

            // Broadcast success message here
            MessagingCenter.Send(this, MessagingServiceConstants.AUTHENTICATED);

            App.GoToRoot();
        }

        async void SignInButtonTapped(object obj)
        {
            await App.ExecuteIfConnected(async () =>
            {
                ViewModel.IsPresentingLoginUI = true;

                if (await Authenticate())
                {
                    App.GoToRoot();

                    // Broadcast success message here
                    MessagingCenter.Send(this, MessagingServiceConstants.AUTHENTICATED);
                }
            });
        } 


        async void LogMeIn(object sender, EventArgs args)
        {
            App.GoToRoot();
        }
    }

    public abstract class SplashPageXaml : ModelBoundContentPage<SplashViewModel>
    { 
    }
}
