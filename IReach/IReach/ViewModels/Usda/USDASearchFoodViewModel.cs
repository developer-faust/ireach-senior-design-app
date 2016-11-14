using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using IReach.Interfaces;
using IReach.Models;
using Xamarin.Forms;
using IReach.ViewModels.Base;

namespace IReach.ViewModels.Usda
{
    public class UsdaSearchFoodViewModel : BaseViewModel
    {
        private static IUsdaFoodService FoodService { get; } =
            DependencyService.Get<IUsdaFoodService>();


        public UsdaSearchFoodViewModel(string searchText = null)
        {
            Title = "Search USDA database";
            Debug.WriteLine("VieModel Searching {0}", searchText);
            SearchText = searchText;
        }

        private IList<food> _foods;
        public IList<food> Foods
        {
            get { return _foods; }
            set
            {
                _foods = value;
                OnPropertyChanged("Foods");
            }
        }

        private IList<food_group> _foodGroups;
        public IList<food_group> FoodGroups
        {
            get { return _foodGroups; }
            set
            {
                _foodGroups = value;
                OnPropertyChanged("FoodGroups");
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

        private Command _searchCommand;
        public Command SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command(async () => await ExecuteSearchCommand()));
            }
        }

        private async Task ExecuteSearchCommand()
        {

            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                IsBusy = false;
                Debug.WriteLine("Search String is Empty!");
            }

            Debug.WriteLine("Searching for {0}", SearchText);
            Foods = await FoodService.SearchFoods(SearchText);

            Debug.WriteLine("Foods Count = {0}", Foods.Count);
            IsBusy = false;
        }

    }
}
