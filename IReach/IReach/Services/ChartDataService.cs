using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Interfaces;
using IReach.Models;
using IReach.Models.Local;
using Xamarin.Forms;

namespace IReach.Services
{
    public class ChartDataService : IChartDataService
    {
        private IFoodDataService _FoodDatabase;

        const int defaultNumberOfWeeks = 6;

        public ChartDataService()
        {
            _FoodDatabase = DependencyService.Get<IFoodDataService>();

        }



        public async Task<IEnumerable<WeeklyCaloriesDataPoint>> GetWeeklyCaloriesDataPointsAsync(IEnumerable<FoodItem> foods, int numberOfWeeks = 6,
            MealTypeOption mealOption = MealTypeOption.All)
        {
            var weeklyCaloriesDataPoints = new List<WeeklyCaloriesDataPoint>();

            var now = DateTime.UtcNow;
            var today = DateTime.SpecifyKind(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0), DateTimeKind.Utc);

            int delta = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - today.DayOfWeek;

            if (delta > 0)
                delta -= 7;

            var firstDayOfCurrentWeek = today.AddDays(delta);
            var weekStart = firstDayOfCurrentWeek;

            var weekEnd = weekStart.AddDays(7);
            var enumerableFoods = foods as IList<FoodItem> ?? foods.ToList();

            double weekTotal = 0;

            for (int i = 0; i < numberOfWeeks; i++)
            {
                weekStart = weekStart.AddDays(-7);
                weekEnd = weekEnd.AddDays(-7);

                weekTotal = GetCalorieTotalForPeriod(enumerableFoods, weekStart, weekEnd);
                weeklyCaloriesDataPoints.Add(new WeeklyCaloriesDataPoint()
                {
                    StartDate = weekStart,
                    EndDate = weekEnd,
                    Amount = weekTotal
                });
            } 

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
