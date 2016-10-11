using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using IReach.Interfaces;
using IReach.Models; 
using Xamarin.Forms;
using IReach.ViewModels.Base;

namespace IReach.ViewModels.Foods
{
    public class BrowseFoodsViewModel : BaseViewModel
    {
        private static IUsdaFoodService FoodService { get; } = DependencyService.Get<IUsdaFoodService> ( ); 
        public BrowseFoodsViewModel(INavigation navigation = null) : base(navigation)
        {
            Title = "Food Groups";
        }  

        private IList<food_group> _foodGroups;
        public IList<food_group> FoodGroups
        {
            get { return _foodGroups; }
            private set
            {
                _foodGroups = value;
                OnPropertyChanged("FoodGroups"); 
            }
        }

        private IList<food> _foods;
        public IList<food> Foods
        {
            get { return _foods; }
            set {
                _foods = value;
                OnPropertyChanged("Foods");
            }
        }
        private string _foodGroupName;
        public string FoodGroupName
        {
            get { return _foodGroupName; }
            private set
            {
                _foodGroupName = value;
                OnPropertyChanged("FoodGroupName");
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText"); 
            }
        }

        private int _searchFoodGroupId;
        public int SearchFoodGroupId
        {
            get { return _searchFoodGroupId; }
            private set
            {
                _searchFoodGroupId = value; 
                OnPropertyChanged("SearchFoodGroupId");
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

        private Command _searchCommand; 
        public Command SearchCommand
        {
            get
            {
                return _searchCommand ?? ( _searchCommand = new Command ( async ( ) => await ExecuteSearchCommand ( ) ) );
            }
        }
        private async Task ExecuteSearchCommand ( )
        {
            IList<food> previousList = new List<food> ( Foods );
            if ( IsBusy )
            {
                return;
            }

            IsBusy = true;

            if ( string.IsNullOrWhiteSpace ( SearchText ) )
            {
                IsBusy = false;
                Debug.WriteLine ( "Search String is Empty!" );
                await ExecuteLoadItemsCommand ( );
            }
            else
            {
                Debug.WriteLine ( "Searching for {0}", SearchText );
                Foods = await FoodService.SearchFoods ( SearchText );
            } 

            IsBusy = false;
        }

        private async Task BindFoodGroup()
        {
            FoodGroups = await FoodService.GetFoodGroups ( ); 
        }
    } 
}
