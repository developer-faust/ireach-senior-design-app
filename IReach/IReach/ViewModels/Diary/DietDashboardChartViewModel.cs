using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
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
        public ObservableCollection<DietChartModel> _calorieItems; 
        public ObservableCollection<DietChartModel> CalorieItems
        {
            get
            {
                return _calorieItems;
            }
            set
            {
                _calorieItems = value;
                OnPropertyChanged("CalorieItems");
            }
        }

        public ObservableCollection<DietChartModel> CalorieTargets { get; set; }

        private IChartDataService _chartDataService;
        private IUserFoodDataService _dataClient;
        private Command _loadSeedDataCommand;

        private double _averageDailyCalories;


        private INavigation _navigation;
        public DietDashboardChartViewModel(INavigation navigation = null) : base(navigation)
        {

            IsBusy = false;
            IsInitialized = false; 
            _navigation = navigation;
           
            ExecuteLoadSeedDataCommand(); 
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


            _dataClient = DependencyService.Get<IUserFoodDataService>();
            _chartDataService = DependencyService.Get<IChartDataService>();
             
            IsBusy = true;
            Foods = (await _dataClient.GetFoodsAsync()).ToObservableCollection();
            CalorieItems = (await _chartDataService.GetWeeklyCaloriesDataPointsAsync(Foods)).ToObservableCollection();

            var total = 0.0;
            int days = 0;
            foreach (var item in CalorieItems)
            {
                if (item.Value > 0)
                {
                    total += item.Value;
                    days++;
                }
                Debug.WriteLine("datecreated {0} Calories {1} Target {2}", item.Name, item.Value, item.Size); 
            } 

            AverageCalories = (total/days);
            IsBusy = false;
            IsInitialized = true;
        }
         
        public double AverageCalories
        {
            get { return _averageDailyCalories; }
            set
            {
                _averageDailyCalories = value;
                OnPropertyChanged("AverageCalories");
            }
        }
    }
}
