using System.Diagnostics;
using IReach.Models;
using IReach.Pages.Base;
using IReach.ViewModels;
using Xamarin.Forms;

namespace IReach.Pages.Food.User
{
    public partial class UserFoodListPage : UserFoodListPageXaml
    {
        private ToolbarItem tbi;
        public UserFoodListPage ( )
        {
            InitializeComponent ( );

            BindingContext =  new UserFoodListViewModel(this.Navigation); 


            var tbi = new ToolbarItem ( "+", null, ( ) =>
            {
                var foodItem = new FoodItem ( );
                var foodPage =  new FoodItemPage(foodItem);

                ViewModel.Navigation.PushAsync ( foodPage );
            }, 0, 0 );

            if (Device.OS == TargetPlatform.Android)
            {
                tbi = new ToolbarItem("+", "plus", () =>
                {
                    var foodItem = new FoodItem();
                    var foodPage = new FoodItemPage(foodItem);

                    ViewModel.Navigation.PushAsync(foodPage);
                },0,0); 
            }

            ToolbarItems.Add(tbi);
             
        }

        private void ListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var foodItem = (FoodItem)e.SelectedItem;
            var foodPage = new FoodItemPage(foodItem);

            Navigation.PushAsync(foodPage);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing(); 
            Debug.WriteLine("User Food List Page Appearing"); 
            ViewModel.LoadItemsCommand.Execute(null); 
        }

       
    }

    public abstract class UserFoodListPageXaml : ModelBoundContentPage<UserFoodListViewModel>
    {
    }
}
