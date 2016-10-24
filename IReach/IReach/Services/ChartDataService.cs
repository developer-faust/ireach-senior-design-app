using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using IReach.Interfaces;
using IReach.Models;
using IReach.Models.Local;
using IReach.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ChartDataService))]
namespace IReach.Services
{
    public class ChartDataService : IChartDataService
    {
        private IUserFoodDataService _userFoodDatabase;

        const int defaultNumberOfWeeks = 6;

        public ChartDataService()
        {
            _userFoodDatabase = DependencyService.Get<IUserFoodDataService>(); 
        }

        public async Task<ObservableCollection<DietChartModel>> GetDailyCaloriesDataPointsAsync(
            IEnumerable<FoodItem> foods, int numberOfDays = 7)
        {
            var dailyCaloriesDataPoints = new ObservableCollection<DietChartModel>();

            var now = DateTime.UtcNow;

            var today = DateTime.SpecifyKind(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0), DateTimeKind.Utc);
            int delta = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - today.DayOfWeek;

            if (delta > 0)
            {
                delta -= 7;
            }

            int daysBack = - 7;
            var firstDayOfCurrentWeek = today.AddDays(daysBack);
            var weekStart = firstDayOfCurrentWeek;

            var weekEnd = weekStart.AddDays(7);
            var enumerableFoods = foods as IList<FoodItem> ?? foods.ToList();

            double dailyTotal = 0;

            for (int i = 0; i < numberOfDays; i++)
            {
                var day = weekStart.AddDays(i);

                string foodName;
                dailyTotal =  GetCalorieTotalForDay(enumerableFoods, day);
                Debug.WriteLine("{0} Total {1}", day.DayOfWeek, dailyTotal);

                dailyCaloriesDataPoints.Add(
                    new DietChartModel(day.DayOfWeek.ToString(), dailyTotal));
            }

            return dailyCaloriesDataPoints;
        }

        private static double GetCalorieTotalForDay(IEnumerable<FoodItem> enumerableFoods, DateTime day)
        {
            double total = 0.0;
            IEnumerable<FoodItem> results;
            results = enumerableFoods.Where(
                            food =>
                                food.DateCreated == day);

            Debug.WriteLine("Date: {0} Number of foods {1}", day.ToString("ddd MMM dd"), results.Count());
            foreach (var foodItem in results)
            {
                total += foodItem.Calories;
            }

            return total;
        }

        public async Task<IEnumerable<WeeklyCaloriesDataPoint>> GetWeeklyCaloriesDataPointsAsync(IEnumerable<FoodItem> foods, int numberOfWeeks = 6,
            MealTypeOption mealOption = MealTypeOption.All)
        {
            var weeklyCaloriesDataPoints = new List<WeeklyCaloriesDataPoint>();

            var now = DateTime.Now;

            // TODO: Change Hard Coded Sample Today's Date from 6 * 7 (six weeks * 7 DaysPer Week) to its Default 
            // The data is calculated backwords it will get 6 weeks worth of data upto current week.
            var today = DateTime.SpecifyKind(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0), DateTimeKind.Utc); 
            Debug.WriteLine("Todays Date : {0}", today.ToString("ddd MMM dd"));
            int delta = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - today.DayOfWeek;

            if (delta > 0)
                delta -= 7;

            var previous = today.AddDays(-7);
            var enumerableFoods = foods as IList<FoodItem> ?? foods.ToList();

            double weekTotal = 0;
            
            weekTotal = GetCalorieTotalForDay(enumerableFoods, today);
            Debug.WriteLine("Total = {0}", weekTotal);
            /*  var firstDayOfCurrentWeek = today.AddDays(delta);
              Debug.WriteLine("First day of week {0}", firstDayOfCurrentWeek.ToString("ddd dd-mmm"));
              var weekStart = firstDayOfCurrentWeek; 
              var weekEnd = weekStart.AddDays(-7);
              Debug.WriteLine("1 Week {0}", weekEnd.ToString("ddd dd-mmm"));

              var enumerableFoods = foods as IList<FoodItem> ?? foods.ToList();

              double weekTotal = 0;

              for (int i = 0; i < 7; i++)
              { 
                  weekTotal = GetCalorieTotalForPeriod(enumerableFoods, weekStart, weekEnd);
                  Debug.WriteLine("WeekTotal = {0}", weekTotal);

                  weeklyCaloriesDataPoints.Add(new WeeklyCaloriesDataPoint()
                  {
                      StartDate = weekStart,
                      EndDate = weekEnd, 
                      Amount = weekTotal
                  });
              } 

              */
            weeklyCaloriesDataPoints.Add(new WeeklyCaloriesDataPoint()
            {
                Date = today, 
                Amount = 1600
            });

            weeklyCaloriesDataPoints.Add(new WeeklyCaloriesDataPoint()
            {
                Date = today.AddDays(-1),
                Amount = 800
            });

            weeklyCaloriesDataPoints.Add(new WeeklyCaloriesDataPoint()
            {
                Date = today.AddDays(-2),
                Amount = 1400
            });

            weeklyCaloriesDataPoints.Add(new WeeklyCaloriesDataPoint()
            {
                Date = today.AddDays(-3),
                Amount = 1200
            });

            weeklyCaloriesDataPoints.Add(new WeeklyCaloriesDataPoint()
            {
                Date = today.AddDays(-4),
                Amount = 1600
            });
            weeklyCaloriesDataPoints.Add(new WeeklyCaloriesDataPoint()
            {
                Date = today.AddDays(-5),
                Amount = 1600
            });
            weeklyCaloriesDataPoints.Add(new WeeklyCaloriesDataPoint()
            {
                Date = today.AddDays(-6),
                Amount = 1600
            });

            weeklyCaloriesDataPoints.Add(new WeeklyCaloriesDataPoint()
            {
                Date = today.AddDays(-7),
                Amount = 1600
            });
            return weeklyCaloriesDataPoints;

        }

      
        public Task<IEnumerable<IGrouping<string, CategoryFoodDataPoint>>> GetCategoryFoodDataPointsAsync(IEnumerable<FoodItem> foods, int numberOfWeeks = 6,
            MealTypeOption mealOption = MealTypeOption.All)
        {
            throw new NotImplementedException();
        }

        private static double GetCalorieTotalForPeriod(IEnumerable<FoodItem> foods, DateTime dateStart, DateTime dateEnd, MealTypeOption mealType = MealTypeOption.All)
        {
            double total = 0;

            IEnumerable<FoodItem> results;

            switch (mealType)
            {
                    case MealTypeOption.Breakfast:
                    results = foods.Where(
                        food =>
                            food.MealType == mealType &&
                            food.DateCreated >= dateStart &&
                            food.DateCreated < dateEnd);
                    break;

                    case MealTypeOption.Lunch:
                    results = foods.Where(
                        food =>
                            food.MealType == MealTypeOption.Lunch &&
                            food.DateCreated >= dateStart &&
                            food.DateCreated < dateEnd);
                    break;
                    case MealTypeOption.Dinner:
                        results = foods.Where(
                            food =>
                                food.MealType == MealTypeOption.Dinner &&
                                food.DateCreated >= dateStart &&
                                food.DateCreated < dateEnd);
                        break;
                    default:
                        results = foods.Where(
                            food =>  
                                food.DateCreated >= dateStart &&
                                food.DateCreated < dateEnd);
                        break;  
            }

            foreach (var foodItem in results)
            {
                total += foodItem.Calories; 
            } 

            return total;
        }

    }
}
