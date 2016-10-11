﻿using System.Collections.ObjectModel;
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

        private string _AverageWeeklyCalories;
        public bool NeedsRefresh { get; set; }

        public FoodDashboardChartViewModel(INavigation navigation = null ) : base(navigation)
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

            Foods = (await _DataClient.GetFoodsAsync()).ToObservableCollection();

            WeeklyCaloriesChartDataPoints =
                (await _ChartDataService.GetWeeklyCaloriesDataPointsAsync(Foods))
                    .OrderBy(x => x.StartDate)
                    .Select(x => new ChartDataPoint(FormatDateRange(x.StartDate, x.EndDate), x.Amount))
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
        static string FormatDateRange(DateTime start, DateTime end)
        {
            return $"{start.ToString("d MMM")}-\n{end.AddDays(-1).ToString("d MMM")}"; 
        }
    }
}