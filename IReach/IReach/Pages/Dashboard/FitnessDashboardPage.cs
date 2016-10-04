using IReach.Localization;
using IReach.ViewModels.Dashboard;
using IReach.Views;
using IReach.Views.Dashboard;
using IReach.Views.Fitness;
using System;
using System.Threading.Tasks;
using IReach.Models;
using Xamarin.Forms;

namespace IReach.Pages.Dashboard
{
    /// <summary>
    /// Dashboard for fitness page 
    /// </summary>
    public class FitnessDashboardPage : ContentPage
    {
        private ScrollView _ScrollView;
        private StackLayout _StackLayout; 
        private FloatingActionButtonView _Fab;

        private FitnessDashboardChartViewModel _ChartViewModel { get; set; } 
        private FitnessDashboardViewModel _FitnessDashboardViewModel { get; set; }
        public FitnessDashboardPage()
        {
            // Set the binding for this page using the view models
            this.SetBinding(Page.TitleProperty, new Binding()
            {
                Source = TextResources.FitnessDashboard
            }); 
            
            // Chart View Model goes here set its binding to 
            var fitnessChartView = new FitnessDashboardChartView
            {
                BindingContext = _ChartViewModel = new FitnessDashboardChartViewModel()
               
            };

            var fitnessView = new FitnessView
            {
                BindingContext = _FitnessDashboardViewModel = new FitnessDashboardViewModel(new Command(PushTabbedFitnessPageAction)) 
            };


            // The Scroll View is where the list of Fitness Data points will go.
            _ScrollView = new ScrollView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        fitnessView
                    }
                }
            };

            _StackLayout = new StackLayout
            {
                Spacing = 0,
                Children =
                {
                    new Label()
                    {
                        Text = "Fitness Summary",
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                        FontAttributes = FontAttributes.Bold
                    },
                    fitnessChartView,
                    _ScrollView
                }
            };
        }

        Action<object> PushTabbedFitnessPageAction
        {
            get { return new Action<object>(async o => await PushTabbedFitnessPage((FitnessItem)o));}
        }

        async Task PushTabbedFitnessPage(FitnessItem fitness = null)
        {
            
        }

    }
}
