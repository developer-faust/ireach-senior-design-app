using System;
using IReach.Models;
using IReach.Services;
using MvvmHelpers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace IReach.ViewModels
{
    public class FoodGroupItemsViewModel : BaseViewModel
    {
        private static IUsdaFoodService FoodService { get; } = 
            DependencyService.Get<IUsdaFoodService> ( );

        public FoodGroupItemsViewModel( )
        {
            Title = "Food In Groups"; 
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }

        private IList<food> _foods; 
        public IList<food> Foods
        {
            get { return _foods; }
            private set { SetProperty(ref _foods, value); }
        }
         

        public int GroupId { get; set; }

        private Command _loadItemsCommand;
        public Command LoadItemsCommand
        {
            get
            {
                return _loadItemsCommand ?? ( _loadItemsCommand = new Command ( async ( ) => await ExecuteLoadItemsCommand ( ) ) );
            }
        }

        private async Task ExecuteLoadItemsCommand ( )
        {
            if ( IsBusy )
                return;

            IsBusy = true;
            Foods = await FoodService.GetFoodsWithGroupId ( GroupId ); 
            IsBusy = false;
        }

        private Command _searchCommand;

        public Command SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command(async ()=> await ExecuteSearchCommand()));
            }
        }
        private async Task ExecuteSearchCommand()
        {
            IList<food> previousList = new List<food>(Foods);
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                IsBusy = false;
                Debug.WriteLine("Search String is Empty!");
                await ExecuteLoadItemsCommand();
            }
            else
            { 
                Debug.WriteLine("Searching for {0}", SearchText);
                Foods = await FoodService.SearchFoods(SearchText);
            }

           
            IsBusy = false;
        }
 
    }
}
