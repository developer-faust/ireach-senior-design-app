using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.Models.Local;

namespace IReach.Interfaces
{
    public interface IChartDataService
    {
        Task<IEnumerable<DietChartModel>> GetWeeklyCaloriesDataPointsAsync(IEnumerable<FoodItem> foods, int numberOfWeeks = 6, MealTypeOption mealOption = MealTypeOption.All);
        Task <ObservableCollection<DietChartModel>> GetDailyCaloriesDataPointsAsync(IEnumerable<FoodItem> foods, int numberOfDays = 7);
        Task<IEnumerable<IGrouping<string, CategoryFoodDataPoint>>> GetCategoryFoodDataPointsAsync(IEnumerable<FoodItem> foods, int numberOfWeeks = 6, MealTypeOption mealOption = MealTypeOption.All);
    }
}
