using IReach.Models; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IReach.Services
{
    public interface IUsdaFoodService
    {
        Task <IList<food_group>> GetFoodGroups ();
        Task<IList<food>> GetFoodsWithGroupId(int groupId);
        Task<IList<food>> GetFoods ( );
        Task<IList<food>> SearchFoods (string searchString ); 

        Task<IList<common_nutrient>> GetCommonGetCommonNutrients ( );
        Task <common_nutrient> GetCommonNutrient ( );
        Task<food> GetFoodWithID ( int foodId ); 

    }
}
