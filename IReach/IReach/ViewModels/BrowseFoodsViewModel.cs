using IReach.Models;
using IReach.Services;
using MvvmHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IReach.ViewModels
{
    public class BrowseFoodsViewModel : BaseViewModel
    {
        private static IUsdaFoodService UsdaFoodService { get; } = DependencyService.Get<IUsdaFoodService> ( ); 
        public BrowseFoodsViewModel( )
        {
            Title = "Food Groups";
        }  

        private IList<food_group> _foodGroups;
        public IList<food_group> FoodGroups
        {
            get { return _foodGroups; }
            private set
            {
                SetProperty ( ref _foodGroups, value ); 
            }
        }


        private string _foodGroupName;
        public string FoodGroupName
        {
            get { return _foodGroupName; }
            private set
            {
                SetProperty(ref _foodGroupName, value);
                OnPropertyChanged();
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            private set
            {
                SetProperty ( ref _searchText, value );
                OnPropertyChanged();
            }
        }

        private int _searchFoodGroupId;
        public int SearchFoodGroupId
        {
            get { return _searchFoodGroupId; }
            private set
            {
                SetProperty ( ref _searchFoodGroupId, value ); 
                OnPropertyChanged();
            }
        }

        private Command _loadItemsCommand; 
        public Command LoadItemsCommand
        {
            get
            {
                return _loadItemsCommand ?? (_loadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand()));
            }
        }

        private async Task ExecuteLoadItemsCommand()
        {
            if(IsBusy)
                return;

            IsBusy = true;
            await BindFoodGroup();

            IsBusy = false; 
        }
        private async Task BindFoodGroup()
        {
            FoodGroups = await UsdaFoodService.GetFoodGroups ( ); 
        }
    } 
}
