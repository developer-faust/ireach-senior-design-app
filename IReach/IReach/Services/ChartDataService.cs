using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
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
        private IFoodDataService _FoodDatabase;

        const int defaultNumberOfWeeks = 1;

        public ChartDataService()
        {
            _FoodDatabase = DependencyService.Get<IFoodDataService>(); 
        }
         
        public async Task<IEnumerable<WeeklyCaloriesDataPoint>> GetWeeklyCaloriesDataPointsAsync(IEnumerable<FoodItem> foods, int numberOfWeeks = defaultNumberOfWeeks,
            MealTypeOption mealOption = MealTypeOption.All)
        {
            var weeklyCaloriesDataPoints = new List<WeeklyCaloriesDataPoint>();

            var now = DateTime.UtcNow; 
            // TODO: Change Hard Coded Sample Today's Date from 6 * 7 (six weeks * 7 DaysPer Week) to its Default 
            // The data is calculated backwords it will get 6 weeks worth of data upto current week.
            var today = DateTime.SpecifyKind(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0), DateTimeKind.Utc);

            int delta = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - today.DayOfWeek; 
            if (delta > 0)
                delta -= 7;

            var firstDayOfCurrentWeek = today.AddDays(delta);
            var weekStart = firstDayOfCurrentWeek; 

            var enumerableFoods = foods as IList<FoodItem> ?? foods.ToList();

            double dayTotal = 0;

            for (int i = 0; i < 7; i++)
            {

                DateTime day = weekStart.AddDays(i);

                dayTotal = GetCalorieTotalForPeriod(enumerableFoods, day);
                Debug.WriteLine("WeekTotal = {0}", dayTotal); 

                weeklyCaloriesDataPoints.Add(new WeeklyCaloriesDataPoint()
                {
                    Created = day, 
                    Amount = dayTotal
                });
            } 

            return weeklyCaloriesDataPoints;

        }

      
        public Task<IEnumerable<IGrouping<string, CategoryFoodDataPoint>>> GetCategoryFoodDataPointsAsync(IEnumerable<FoodItem> foods, int numberOfWeeks = 6,
            MealTypeOption mealOption = MealTypeOption.All)
        {
            throw new NotImplementedException();
        }

        private static double GetCalorieTotalForPeriod(IEnumerable<FoodItem> foods, DateTime date, MealTypeOption mealType = MealTypeOption.All)
        {
            double total = 0;

            IEnumerable<FoodItem> results;

            switch (mealType)
            {
                    case MealTypeOption.Breakfast:
                    results = foods.Where(
                        food =>
                            food.MealType == mealType &&
                            food.DateCreated == date);
                    break;

                    case MealTypeOption.Lunch:
                    results = foods.Where(
                        food =>
                            food.MealType == MealTypeOption.Lunch &&
                            food.DateCreated == date);
                    break;
                    case MealTypeOption.Dinner:
                        results = foods.Where(
                            food =>
                                food.MealType == MealTypeOption.Dinner &&
                                food.DateCreated == date);
                        break;
                    default:
                        results = foods.Where(
                            food =>  
                                food.DateCreated == date);
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
