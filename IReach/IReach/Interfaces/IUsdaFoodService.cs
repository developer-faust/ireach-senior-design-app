using System.Collections.Generic;
using System.Threading.Tasks;
using IReach.Models;

namespace IReach.Interfaces
{
    public interface IUsdaFoodService
    {
        Task <IList<food_group>> GetFoodGroups ();
        Task<IList<food>> GetFoodsWithGroupId(int groupId);
        Task<IList<food>> GetFoods ( );
        Task<IList<food>> SearchFoods (string searchString );
        Task<IList<food>> SearchFoods(string searchString, int groupId);

        Task<IList<common_nutrient>> GetCommonGetCommonNutrients ( );
        Task <common_nutrient> GetCommonNutrient ( );
        Task<food> GetFoodWithID (int foodId);

    }
}
