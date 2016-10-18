using System;
using System.Threading.Tasks;
using IReach.Pages.Base;
using IReach.Services;
using IReach.Statics;
using IReach.ViewModels;
using IReach.ViewModels.Splash;
using Xamarin.Forms;

namespace IReach.Pages.Splash
{
    /// <summary>
    /// This page is shown to the User if User is not authenticated.
    /// </summary>
    public partial class SplashPage : SplashPageXaml
    {

        /// <summary>
        /// Gives us a service which we can use to authenticate a user
        /// </summary>
        private readonly IAuthenticationService _authenticationService;

        public SplashPage()
        {
            InitializeComponent();

            // BindingContext is set to the SplashViewModel where the properties for our Page is located.
            BindingContext = new SplashViewModel();

            // Use dependency service to request a service.
            _authenticationService = DependencyService.Get<IAuthenticationService>();

            XamarinLogo.Source = "epsl.png";
            // Assign Gestures and Commands to Buttons. This is just another way to Do OnClickedListener Operations by using Command
            SignInButton.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    NumberOfTapsRequired = 1,
                    Command = new Command(SignInButtonTapped)
                });
            // Assign Gestures and Commands to Buttons. This is just another way to Do OnClickedListener Operations by using Command 
            SkipSignInButton.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    NumberOfTapsRequired = 1,
                    Command = new Command(SkipSignInButtonTapped)
                });
        }

        /// <summary>
        /// When App first appears We use the ViewModel property Located in ModelBoundContentPage<SplashViewModel>
        /// This SplashPage inherits from an abstract class SplashPageXaml : ModelBoundContentPage<SplashViewModel>
        /// on the bottom of this file. It is declared as SplashPage : SplashPageXaml
        /// </summary>
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // Get sample credentials from SplashViewModel
            await ViewModel.LoadCredentials();

            // Simulate login using animation
            await Task.Delay(App.AnimationSpeed);

            // Animate login buttons
            await SignInButton.ScaleTo(1, (uint) App.AnimationSpeed, Easing.SinIn);
            await SkipSignInButton.ScaleTo( 1, (uint)App.AnimationSpeed, Easing.SinIn);

        }


        // Attemps to authenticate a User.
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

        // Skip Signin: TODO: Implement App Security dont display sensitive information if any
        async void SkipSignInButtonTapped(object obj)
        {
           _authenticationService.BypassAuthentication();

            // Broadcast success message here
            MessagingCenter.Send(this, MessagingServiceConstants.AUTHENTICATED);

             App.GoToRoot(); 
        }

        // Calls the ExecuteIfConnected(Command) Static function to Take the user to the RootPage 
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
         
    }

    public abstract class SplashPageXaml : ModelBoundContentPage<SplashViewModel>
    { 
    }
}
