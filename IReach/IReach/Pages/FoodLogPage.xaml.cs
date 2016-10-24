using IReach.Pages.Diary;
using Xamarin.Forms;

namespace IReach.Pages
{
    public partial class FoodLogPage : TabbedPage
    {
        public FoodLogPage()
        {
            InitializeComponent();

            this.Children.Add(new DietDashboardPage());
            this.Children.Add(new Food.User.UserFoodListPage());
            this.Children.Add(new Food.Usda.UsdaSearchFoodPage());
            this.Children.Add(new Food.Usda.BrowseFoodsPage());
        }
    }
}
