using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using IReach.Interfaces;
using IReach.Models;
using IReach.ViewModels.Base;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using System.Threading.Tasks;
using IReach.Extensions;

namespace IReach.ViewModels.Dashboard
{

    /// <summary>
    /// ViewMode for modeling the ChartView for fitness dashboard page
    /// </summary>
    public class FitnessDashboardChartViewModel : BaseViewModel
    {
        // Data Service
        private IFitnessDataService _DataClient;
        private IFitnessChartService _ChartService;

        private Command _loadSeedDataCommand;

        private ObservableCollection<FitnessItem> _Fitness;
        private ObservableCollection<ChartDataPoint> _DailyStepCountDatapoints;

        private string _DailyStepCount;
        public bool NeedsRefresh { get; set; }

        public FitnessDashboardChartViewModel(INavigation navigation = null) : base(navigation)
        {
            _DataClient = DependencyService.Get<IFitnessDataService>();
            _ChartService = DependencyService.Get<IFitnessChartService>(); 

        }


        public ObservableCollection<FitnessItem> Fitness
        { 
            get { return _Fitness; }
            set
            {
                _Fitness = value;
                OnPropertyChanged("Fitness");
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
                return;

            IsBusy = true;

            Fitness = (await _DataClient.GetFitnessDataAsync()).ToObservableCollection();

            // Get daily step counts. Default is 1 days. The Constructor could be changed to return more data points.
            // For any number of days.
            DaileStepCountDataPoints =
                (await _ChartService.GetDailyStepsDataPointsAsync(Fitness))
                    .OrderBy(x => x.StartDate)
                    .Select(x => new ChartDataPoint(FormatDateRange(x.StartDate, x.EndDate), x.Amount))
                    .ToObservableCollection();


            DailyStepsCount = string.Format("{0}", _DailyStepCountDatapoints.Average(x => x.YValue));

            Debug.WriteLine("Weekly Average Calories: {0}", DailyStepsCount);
            IsInitialized = true;
            IsBusy = false;
        }

        public string DailyStepsCount
        {
            get { return _DailyStepCount; }
            set
            {
                _DailyStepCount = value;
                OnPropertyChanged("DailyStepsCount");
            }
        }
         
        public ObservableCollection<ChartDataPoint> DaileStepCountDataPoints
        {
            get { return _DailyStepCountDatapoints; }
            set
            {
                _DailyStepCountDatapoints = value;
                OnPropertyChanged("DaileStepCountDataPoints");
            }
        }
        static string FormatDateRange(DateTime start, DateTime end)
        {
            return $"{start.ToString("d MMM")}-\n{end.AddDays(-1).ToString("d MMM")}";
        }

    }
}
