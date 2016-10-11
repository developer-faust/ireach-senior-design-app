using System.Collections.ObjectModel;
using IReach.Interfaces;
using IReach.Models;
using IReach.ViewModels.Base;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IReach.Extensions;

namespace IReach.ViewModels.Diary
{
    public class FoodDashboardChartViewModel : BaseViewModel
    {
        IFoodDataService _DataClient;
        private IChartDataService _ChartDataService;

        private Command _loadSeedDataCommand;
         
        private ObservableCollection<FoodItem> _Foods;
        private ObservableCollection<ChartDataPoint> _WeeklyCaloriesChartDataPoints;
        private ObservableCollection<ChartDataPoint> _dailyTargetChartDataPoints;

        private string _AverageWeeklyCalories;
        public bool NeedsRefresh { get; set; }

        public FoodDashboardChartViewModel(INavigation navigation = null ) : base(navigation)
        {
            _DataClient = DependencyService.Get<IFoodDataService>();
            _ChartDataService = DependencyService.Get<IChartDataService>(); 

            Foods = new ObservableCollection<FoodItem>();
            _WeeklyCaloriesChartDataPoints = new ObservableCollection<ChartDataPoint>(); 
            _dailyTargetChartDataPoints = new ObservableCollection<ChartDataPoint>();
            IsInitialized = false;
        }

        public Command LoadSeedDataCommand
        {
            get
            {
                return _loadSeedDataCommand ??
                       (_loadSeedDataCommand = new Command(async () => await ExecuteLoadSeedDataCommand()));
            }
        }

        public ObservableCollection<ChartDataPoint> WeeklyCaloriesChartDataPoints
        {
            get { return _WeeklyCaloriesChartDataPoints; }
            set
            {
                _WeeklyCaloriesChartDataPoints = value;
                OnPropertyChanged("WeeklyCaloriesChartDataPoints");
            }
        }

        public ObservableCollection<ChartDataPoint> DailyTargetChartDataPoints
        {
            get { return _dailyTargetChartDataPoints; }
            set
            {
                _dailyTargetChartDataPoints = value; 
                OnPropertyChanged("DailyTargets");
            }
        }
        public ObservableCollection<FoodItem> Foods
        {
            get { return _Foods; }
            set
            {
                _Foods = value;
                OnPropertyChanged("Foods");
            }
        }
        public async Task ExecuteLoadSeedDataCommand()
        {
            if(IsBusy)
                return;

            IsBusy = true;

            Foods = (await _DataClient.GetFoodsAsync()).ToObservableCollection();

            WeeklyCaloriesChartDataPoints =
                (await _ChartDataService.GetWeeklyCaloriesDataPointsAsync(Foods, 1))
                    .OrderBy(x => x.Created)
                    .Select(x => new ChartDataPoint(FormatDateRange(x.Created), x.Amount))
                    .ToObservableCollection();

            DailyTargetChartDataPoints = (await _ChartDataService.GetWeeklyCaloriesDataPointsAsync(Foods, 1))
                    .OrderBy(x => x.Created)
                    .Select(x => new ChartDataPoint(FormatDateRange(x.Created), 2000))
                    .ToObservableCollection();


            AverageWeeklyCalories = string.Format("{0}", WeeklyCaloriesChartDataPoints.Average(x => x.YValue));

            Debug.WriteLine("Weekly Average Calories: {0}", AverageWeeklyCalories);
            IsInitialized = true; 
            IsBusy = false;
        }

        public string AverageWeeklyCalories
        {
            get { return _AverageWeeklyCalories; }
            set
            {
                _AverageWeeklyCalories = value;
                OnPropertyChanged("AverageWeeklyCalories");
            }
        }
        static string FormatDateRange(DateTime createdTime)
        {
            return $"{createdTime.ToString("d MMM")}"; 
        }
    }
}
