using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.Services;
using MvvmHelpers;
using Xamarin.Forms;

namespace IReach.ViewModels
{
    public class UsdaSearchFoodViewModel : BaseViewModel
    {
        private static IUsdaFoodService FoodService { get; } =
            DependencyService.Get<IUsdaFoodService> ( );

        public UsdaSearchFoodViewModel()
        {
            Title = "Search USDA database";
        }

        private IList<food> _foods;
        public IList<food> Foods
        {
            get { return _foods; }
            private set { SetProperty ( ref _foods, value ); }
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
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                SetProperty ( ref _searchText, value );
            }
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
          
            if ( IsBusy )
            {
                return;
            }

            IsBusy = true;

            if ( string.IsNullOrWhiteSpace ( SearchText ) )
            {
                IsBusy = false;
                Debug.WriteLine ( "Search String is Empty!" ); 
            }
                 
            Debug.WriteLine ( "Searching for {0}", SearchText );
            Foods = await FoodService.SearchFoods ( SearchText );
            
            Debug.WriteLine("Foods Count = {0}", Foods.Count);  
            IsBusy = false;
        }

    }
}
