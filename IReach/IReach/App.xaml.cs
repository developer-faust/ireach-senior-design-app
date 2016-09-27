using System;
using System.Diagnostics;
using System.Threading.Tasks;
using IReach.Data;
using IReach.Localization;
using IReach.Services;
using IReach.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using IReach.Service;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace IReach
{
    public partial class App: Application
    {
        public static bool IsWindows10 { get; set; }

        private static Application app;
        public static Application CurrentApp
        {
            get { return app; }
        }

        private readonly IAuthenticationService _authenticationService;
        public App ( )
        {
            InitializeComponent ( );

            app = this;
            _authenticationService = DependencyService.Get<IAuthenticationService> ( );
            TextResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();


            if ( !_authenticationService.IsAuthenticated )
            {
                Debug.WriteLine("Not authenticated! Show Login Page");
                MainPage = new SplashPage ( );
            }
            else
            {
                GoToRoot ( );

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

        private static USDAFoodService nutritionDb;
        public static USDAFoodService NutritionDb
        {
            get
            {
                if (nutritionDb == null)
                {
                    nutritionDb = new USDAFoodService();
                }

                return nutritionDb;
            }
        }

        public static void GoToRoot ( )
        {
            if ( Device.OS == TargetPlatform.Android )
            {
                CurrentApp.MainPage = new RootPage ( );
            }
        }

        public static async Task ExecuteIfConnected ( Func<Task> actionToExecuteIfConnected )
        {
            if ( IsConnected )
            {
                await actionToExecuteIfConnected ( );
            }
        }

        public static bool IsConnected
        {
            get { return true; }
        }

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
