using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using IReach.Interfaces;
using IReach.Models;
using IReach.Services;
using Xamarin.Forms;
using IReach.ViewModels.Base;

namespace IReach.ViewModels.Foods
{
    public class FoodGroupItemsViewModel : BaseViewModel
    {
        private static IUsdaFoodService FoodService { get; } = 
            DependencyService.Get<IUsdaFoodService> ( );
         
        public FoodGroupItemsViewModel(INavigation navigation = null) : base(navigation)
        {
            Title = "Food In Groups"; 
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set {
                _searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        private IList<food> _foods; 
        public IList<food> Foods
        {
            get { return _foods; }
            private set
            {
                _foods = value;
                OnPropertyChanged("Foods");
            }
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

            Debug.WriteLine("Group ID: {0}", GroupId);
            Foods = await FoodService.GetFoodsWithGroupId ( GroupId ); 

            Debug.WriteLine("Food Count = {0}", Foods.Count);
            IsBusy = false;
        }

        private Command _filterCommand;

        public Command FilterCommand
        {
            get { return _filterCommand ?? (_filterCommand = new Command(async () => await ExecuteFilterCommand())); }
        }

        private async Task ExecuteFilterCommand()
        {
            throw new NotImplementedException();
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
                Foods = await FoodService.SearchFoods(SearchText, GroupId);
            }  
            IsBusy = false;
        } 
    }
}
