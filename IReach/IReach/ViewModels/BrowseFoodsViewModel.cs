using IReach.Models;
using IReach.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IReach.ViewModels
{
    public class BrowseFoodsViewModel : BaseViewModel
    {
        private static IUsdaFoodService UsdaFoodService { get; } = DependencyService.Get<IUsdaFoodService> ( );
         
        private IList<food_group> _foodGroups;

        public BrowseFoodsViewModel(Page page)
        {
            page.Appearing += async ( sender, e ) =>
            {
                await BindFoodGroup ( ); 
            };
        }


        public IList<food_group> FoodGroups
        {
            get { return _foodGroups; }
            private set { SetProperty ( ref _foodGroups, value ); }
        }


        private string _foodGroupName;
        public string FoodGroupName
        {
            get { return _foodGroupName; }
            private set { SetProperty(ref _foodGroupName, value); }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            private set { SetProperty ( ref _searchText, value ); }
        }

        private int _searchFoodGroupId;
        public int SearchFoodGroupID
        {
            get { return _searchFoodGroupId; }
            private set { SetProperty ( ref _searchFoodGroupId, value ); }
        }


        private async Task BindFoodGroup()
        {
            FoodGroups = await UsdaFoodService.GetFoodGroups ( );

        }
    } 
}
