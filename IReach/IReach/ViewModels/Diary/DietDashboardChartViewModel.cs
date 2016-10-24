using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Extensions;
using IReach.Interfaces;
using IReach.Models;
using IReach.Models.Local;
using IReach.ViewModels.Base;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace IReach.ViewModels.Diary
{
    public class DietDashboardChartViewModel : BaseViewModel
    {  

        public ObservableCollection<ChartDataPoint> CalorieItems { get; set; }
        public ObservableCollection<DietChartModel> CalorieTargets { get; set; }

        private IChartDataService _chartDataService;
        private IUserFoodDataService _dataClient;
        private Command _loadSeedDataCommand;

        private string _averageDailyCalories;


        private INavigation _navigation;
        public DietDashboardChartViewModel(INavigation navigation = null) : base(navigation)
        {

            IsBusy = false;
            IsInitialized = false; 
            _navigation = navigation;


            _dataClient = DependencyService.Get<IUserFoodDataService>();
            _chartDataService = DependencyService.Get<IChartDataService>();

            /*CalorieItems = new ObservableCollection<DietChartModel>()
            {
                new DietChartModel("Tue", 300),
                new DietChartModel("Wed", 450),
                new DietChartModel("Thu", 600),
                new DietChartModel("Fri", 1000),
                new DietChartModel("Sat", 900),
                new DietChartModel("Sun", 200),
                new DietChartModel("Mon", 500),
                new DietChartModel("Tue", 600)

            };
            */
            CalorieTargets = new ObservableCollection<DietChartModel>
            {
                new DietChartModel("Tue", 700),
                new DietChartModel("Wed", 700),
                new DietChartModel("Thu", 775),
                new DietChartModel("Fri", 1000),
                new DietChartModel("Sat", 900),
                new DietChartModel("Sun", 600), 
                new DietChartModel("Mon", 500),
                new DietChartModel("Tue", 600)

            };

            //DailyCalorieChartDataPoints = CalorieItems.Select(x=> new ChartDataPoint(x.Name, x.Value)).ToObservableCollection();
        }

        private ObservableCollection<FoodItem> _foods;
        public ObservableCollection<FoodItem> Foods
        {
            get { return _foods; }
            set
            {
                _foods = value;
                OnPropertyChanged("Foods");
            }
        }
        public Command LoadSeedDataCommand
        {
            get
            {
                return _loadSeedDataCommand ??
                       (_loadSeedDataCommand = new Command(async () => await ExecuteLoadSeedDataCommand()));
            }
        }

        public async Task ExecuteLoadSeedDataCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            Foods = (await _dataClient.GetFoodsAsync()).ToObservableCollection();
            CalorieItems = (await _chartDataService.GetWeeklyCaloriesDataPointsAsync(Foods))
                    .OrderBy(x => x.Date)
                    .Select(x => new ChartDataPoint(x.Date.ToString("ddd").Substring(0, 2), x.Amount))
                    .ToObservableCollection(); 
 

            IsBusy = false;
            IsInitialized = true;
        } 
        public string WeekAverageCalories
        {
            get { return _averageDailyCalories; }
            set
            {
                _averageDailyCalories = value;
                OnPropertyChanged("WeekAverageCalories");
            }
        }
    }
}
