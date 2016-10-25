using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using IReach.Extensions;
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
            var weeklyCaloriesDataPoints = new List<DietChartModel>();
            var now = DateTime.Now;

            // TODO: Change Hard Coded Sample Today's Date from 6 * 7 (six weeks * 7 DaysPer Week) to its Default 
            // The data is calculated backwords it will get 6 weeks worth of data upto current week.
            var today = DateTime.SpecifyKind(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0), DateTimeKind.Utc);
            // Debug.WriteLine("Todays Date : {0}", today.ToString("ddd MMM dd"));
            // Debug.WriteLine("Number of Days to go back = {0}", numberOfDays);
            int delta = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - today.DayOfWeek;

            if (delta > 0)
                delta -= 7;

            var past = today.AddDays(-1.0 * 2.0);
            // Debug.WriteLine("Past: {0}", past.ToString("ddd dd MMM"));
            var enumerableFoods = foods as IList<FoodItem> ?? foods.ToList();
            Debug.WriteLine("Food Count: {0}", enumerableFoods.Count);

            double dayTotal = 0;

            for (DateTime date = past; date <= today; date = date.AddDays(1.0))
            {
                dayTotal = GetCalorieTotalForDay(enumerableFoods, date);

                Debug.WriteLine("Date: {0} Total = {1}", date.ToString("ddd dd MMM"), dayTotal);
                weeklyCaloriesDataPoints.Add(new DietChartModel()
                {
                    Name = date.ToString("ddd"),
                    Value = dayTotal,
                    Size = 1500
                });
            }

            foreach (var item in weeklyCaloriesDataPoints)
            {
                Debug.WriteLine("Weekly Datapoint: {0} : {1}", item.Name, item.Value);
            }

            // weekTotal = GetCalorieTotalForDay(enumerableFoods, today);
            // Debug.WriteLine("Total = {0}", weekTotal);

            return weeklyCaloriesDataPoints.ToObservableCollection();
        }

        private static double GetCalorieTotalForDay(IEnumerable<FoodItem> enumerableFoods, DateTime day)
        {
            double total = 0.0;
            IEnumerable<FoodItem> results;
            results = enumerableFoods.Where(
                            food =>
                                food.DateCreated == day);

            // Debug.WriteLine("Date: {0} Number of foods {1}", day.ToString("ddd MMM dd"), results.Count());
            foreach (var foodItem in results)
            {
                total += foodItem.Calories;
            }

            return total;
        }

        public async Task<IEnumerable<DietChartModel>> GetWeeklyCaloriesDataPointsAsync(IEnumerable<FoodItem> foods, int numberOfDays = 7,
            MealTypeOption mealOption = MealTypeOption.All)
        {

            var weeklyCaloriesDataPoints = new List<DietChartModel>();
            var now = DateTime.Now;

            // TODO: Change Hard Coded Sample Today's Date from 6 * 7 (six weeks * 7 DaysPer Week) to its Default 
            // The data is calculated backwords it will get 6 weeks worth of data upto current week.
            var today = DateTime.SpecifyKind(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0), DateTimeKind.Utc);
            // Debug.WriteLine("Todays Date : {0}", today.ToString("ddd MMM dd"));
            // Debug.WriteLine("Number of Days to go back = {0}", numberOfDays);
            int delta = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - today.DayOfWeek;

            if (delta > 0)
                delta -= 7;

            var past = today.AddDays(-1.0 * numberOfDays);
            // Debug.WriteLine("Past: {0}", past.ToString("ddd dd MMM"));
            var enumerableFoods = foods as IList<FoodItem> ?? foods.ToList();
            Debug.WriteLine("Food Count: {0}", enumerableFoods.Count);

            double dayTotal = 0;

            for (DateTime date = past; date <= today; date = date.AddDays(1.0))
            {
                dayTotal = GetCalorieTotalForDay(enumerableFoods, date);

                Debug.WriteLine("Date: {0} Total = {1}", date.ToString("ddd dd MMM"), dayTotal);
                 
                weeklyCaloriesDataPoints.Add(new DietChartModel()
                {
                    Name = date.ToString("ddd"),
                    Value = dayTotal,
                    Size = dayTotal > 0 ? 1800 : 0 
                });
            }

            foreach (var item in weeklyCaloriesDataPoints)
            {
                Debug.WriteLine("Weekly Datapoint: {0} : {1}", item.Name, item.Value);
            }

            // weekTotal = GetCalorieTotalForDay(enumerableFoods, today);
            // Debug.WriteLine("Total = {0}", weekTotal);

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
