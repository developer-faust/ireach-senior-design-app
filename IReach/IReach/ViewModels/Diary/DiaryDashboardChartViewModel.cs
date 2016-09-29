using System.Collections.ObjectModel;
using IReach.Interfaces;
using IReach.Models;
using IReach.ViewModels.Base;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using System;
using System.Linq;
using System.Threading.Tasks;
using IReach.Extensions;

namespace IReach.ViewModels.Diary
{
    public class DiaryDashboardChartViewModel : BaseViewModel
    {
        IFoodDataService _DataClient;
        private IChartDataService _ChartDataService;

        private Command _loadSeedDataCommand;
         
        private ObservableCollection<FoodItem> _Foods;
        private ObservableCollection<ChartDataPoint> _WeeklyCaloriesChartDataPoints;

        private string _AverageWeeklyCalories;
        public bool NeedsRefresh { get; set; }

        public DiaryDashboardChartViewModel(INavigation navigation = null ) : base(navigation)
        {
            _DataClient = DependencyService.Get<IFoodDataService>();
            _ChartDataService = DependencyService.Get<IChartDataService>(); 

            Foods = new ObservableCollection<FoodItem>();
            WeeklyCaloriesChartDataPoints = new ObservableCollection<ChartDataPoint>();

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

            Foods = (await App.UserAsyncDb.GetFoodsAsync()).ToObservableCollection();

            WeeklyCaloriesChartDataPoints =
                (await _ChartDataService.GetWeeklyCaloriesDataPointsAsync(Foods))
                    .OrderBy(x => x.StartDate)
                    .Select(x => new ChartDataPoint(FormatDateRange(x.StartDate, x.EndDate), x.Amount))
                    .ToObservableCollection();

            AverageWeeklyCalories = string.Format("{0:D", WeeklyCaloriesChartDataPoints.Average(x => x.YValue));
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
        static string FormatDateRange(DateTime start, DateTime end)
        {
            return $"{start.ToString("d MMM")}-\n{end.AddDays(-1).ToString("d MMM")}"; 
        }
    }
}
