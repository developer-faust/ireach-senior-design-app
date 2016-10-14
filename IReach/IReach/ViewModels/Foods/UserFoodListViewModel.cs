
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using IReach.Interfaces;
using IReach.Models;
using IReach.Services;
using IReach.ViewModels.Base;
using Xamarin.Forms;

namespace IReach.ViewModels
{
    public class UserFoodListViewModel : BaseViewModel
    {

        // Database service using dependency injection
        private IUserFoodDataService FoodService { get;  } = DependencyService.Get<IUserFoodDataService>();

        private INavigation _navigation;
        public UserFoodListViewModel(INavigation navigation = null) : base(navigation)
        {
            _navigation = navigation;
            IsBusy = false;
            Title = "Food Diary";
        }

        private ObservableCollection<FoodItem> _foods; 
        public ObservableCollection<FoodItem> UserFoods
        {
            get { return _foods; }
            private set
            {
                _foods = value; 
                OnPropertyChanged("UserFoods");
            }
        }

        private Command _loadItemsCommand;
        public Command LoadItemsCommand
        {
            get
            {
                Debug.WriteLine("Execute Load Items");
                return _loadItemsCommand ?? (_loadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand()));
            }
        }

        private async Task ExecuteLoadItemsCommand()
        {
            Debug.WriteLine("ExecuteLoadItemsCommand: IsBusy = {0}", IsBusy);

            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            await BindFoods();

            IsBusy = false;
        }

        private async Task BindFoods()
        {

            Debug.WriteLine("BindFoods: Calling Food Service");
            UserFoods = await FoodService.GetFoodsAsync();

            Debug.WriteLine("User Foods Count = {0}", UserFoods.Count);
        }
    }
}
