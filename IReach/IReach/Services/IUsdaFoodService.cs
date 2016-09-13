using IReach.Models; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IReach.Services
{
    public interface IUsdaFoodService
    {
        Task <IList<food_group>> GetFoodGroups ();
        Task<IList<food>> GetFoods ( );
        Task<IList<food>> SearchFoods (string name); 

        Task<IList<common_nutrient>> GetCommonGetCommonNutrients ( );
        Task <common_nutrient> GetCommonNutrient ( );
        Task<food> GetFoodWithID ( int foodId ); 

    }
}
