using System;
using System.Diagnostics;
using System.Threading.Tasks;
using IReach.Data;
using IReach.Localization;
using IReach.Pages;
using IReach.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using IReach.Pages.Splash;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace IReach
{

    /// <summary>
    /// Our Application Entry point:
    /// 
    /// This class is responsible for setting up the app startup. 
    /// </summary>
    public partial class App: Application
    {
        public static bool IsWindows10 { get; set; }

        
        // app: this application is a static App instance Only created once 
        private static Application app;

        // CurrentApp: Returns an instance of this App class to any place in the app that needs it. It
        // Is used as a Context Object by many android specific activities or Views
        public static Application CurrentApp
        {
            get { return app; }
        }

        private readonly IAuthenticationService _authenticationService;

        /// <summary>
        /// Constructor initializes the services we will use throughout the app.
        /// Some of the services are defined as static objects to allow one instance access throughout the app (optional).
        /// You can also use DependencyService.Get<InterfaceForService>(); To get any service in the app.
        /// 
        /// </summary>
        public App ( )
        {
            InitializeComponent ( );
              
            app = this;
            _authenticationService = DependencyService.Get<IAuthenticationService> ( );

            // Many of the Labels used for the app are stored in a .resx Resource File located in Localization directory.
            // This allows us to not hard code strings such as titles and labels to Views.
            TextResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        

            // TODO: Implement more features to the AuthenticationService. Such as:
            // 1. Save user to shared preference
            // 2. Token authentication etc..
            if ( !_authenticationService.IsAuthenticated )
            {
                Debug.WriteLine("Not authenticated! Show Login Page");

                // Display the login SplashPage to authenticate current user. Later on the splash page will be able to save user in shared
                // pref. instead of having to login everytime the app starts.
                MainPage = new SplashPage ( );
            }
            else
            {

                // The User is authenticated. We Navigated to the RootPage.
                GoToRoot ( ); 
            }
        } 


        public static void GoToRoot()
        {
            if (Device.OS == TargetPlatform.Android)
            {
                CurrentApp.MainPage = new RootPage();  
            }
        }

        public static string Description { get; set; }
        public int ResumeAtFoodID { get; set; }

        private static FoodItemDatabase database;

        public static FoodItemDatabase Database
        {
            get
            {
                if ( database == null )
                {
                    database = new FoodItemDatabase ( );
                }
                return database;
            }
        }

        /// <summary>
        /// A Singleton UserFood Database:
        /// Allows for a single instance of the database for the entire app. 
        /// Use this instead of DependencyService.Get<>
        /// Usage: var DBInstance = App.CurrentApp.UserAsyncDataService;
        /// </summary>
        private static FoodAsyncDataService _userFoodDataService;

        public static FoodAsyncDataService UserAsyncDataService
        {
            get
            {
                if (_userFoodDataService == null)
                {
                    _userFoodDataService = new FoodAsyncDataService();
                }

                return _userFoodDataService;
            }
        }

        /// <summary>
        /// Singleton USDA Nutrition Database
        /// </summary>
        private static USDAFoodService _nutritionDataService;
        public static USDAFoodService NutritionDataService
        {
            get
            {
                if (_nutritionDataService == null)
                {
                    _nutritionDataService = new USDAFoodService();
                }

                return _nutritionDataService;
            }
        }

    
        /// <summary>
        /// TODO: Not yet implemented. This will be used later to Acess rest services.
        /// </summary>
        /// <param name="actionToExecuteIfConnected"></param>
        /// <returns></returns>
        public static async Task ExecuteIfConnected ( Func<Task> actionToExecuteIfConnected )
        {
            if ( IsConnected )
            {
                await actionToExecuteIfConnected ( );
            }
        }

        /// <summary>
        /// TODO: this always returns true. Fix later when implementing rest services.
        /// </summary>
        public static bool IsConnected
        {
            get { return true; }
        }


        /// <summary>
        /// Animation speed for views and pages. Used in SplashPage to animate Login and Skip Signin Buttons
        /// </summary>
        public static int AnimationSpeed { get; } = 250; 
        protected override void OnStart ( )
        {
            // Handle when your app starts
        }

        protected override void OnSleep ( )
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ( )
        {
            // Handle when your app resumes
        }
    }
}
