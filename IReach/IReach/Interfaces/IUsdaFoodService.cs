using System.Collections.Generic;
using System.Threading.Tasks;
using IReach.Models;
using System.Collections.ObjectModel;

namespace IReach.Interfaces
{
    public interface IUsdaFoodService
    {
        Task<ObservableCollection<food_group>> GetFoodGroups();
        Task<ObservableCollection<food>> GetFoodsWithGroupId(int groupId);
        Task<ObservableCollection<food>> GetFoods();
        Task<ObservableCollection<food>> SearchFoods(string searchString);
        Task<ObservableCollection<food>> SearchFoods(string searchString, int groupId);

        Task<ObservableCollection<FoodNutrients>> GetFoodNutritions(int foodId);
        Task<ObservableCollection<common_nutrient>> GetCommonGetCommonNutrients();
        Task<common_nutrient> GetCommonNutrient();
        Task<food> GetFoodWithID(int foodId); 
    }
}
