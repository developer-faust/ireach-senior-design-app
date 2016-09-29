using System.Diagnostics;
using IReach.Models;
using Xamarin.Forms;

namespace IReach.Pages.Food.User
{
    public partial class FoodListPage : ContentPage
    {
        private ToolbarItem tbi;
        public FoodListPage ( )
        {
            InitializeComponent ( );

            tbi = new ToolbarItem ( "+", null, ( ) =>
            {
                var foodItem = new FoodItem ( );
                var foodPage = new Pages.Food.User.FoodItemPage {BindingContext = foodItem};

                Navigation.PushAsync ( foodPage );
            }, 0, 0 );

            if (Device.OS == TargetPlatform.Android)
            {
                tbi = new ToolbarItem("+", "plus", () =>
                {
                    var foodItem = new FoodItem();
                    var foodPage = new Pages.Food.User.FoodItemPage {BindingContext = foodItem};

                    Navigation.PushAsync(foodPage);
                },0,0); 
            }

            ToolbarItems.Add(tbi);
        }

        void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var foodItem = (FoodItem) e.SelectedItem;
            var foodPage = new Pages.Food.User.FoodItemPage();

            
            foodPage.BindingContext = foodItem;

          
            ( (App) App.Current).ResumeAtFoodID = foodItem.ID;
            Debug.WriteLine("Setting ResumeAtFoodId = " + foodItem.ID);
            Debug.WriteLine("Created: {0}", foodItem.DateCreated.ToString());

            Navigation.PushAsync(foodPage);

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ((App) App.Current).ResumeAtFoodID = -1;
            var foods = await App.UserAsyncDataService.GetFoodsAsync();

            listView.ItemsSource = foods;
        }
    }
}
