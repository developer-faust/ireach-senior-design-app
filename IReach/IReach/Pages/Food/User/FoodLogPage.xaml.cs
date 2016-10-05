using IReach.Pages.Diary;
using Xamarin.Forms;

namespace IReach.Pages.Food.User
{
    public partial class FoodLogPage : TabbedPage
    {
        public FoodLogPage()
        {
            InitializeComponent();

            this.Children.Add(new DiaryDashboardPage());
            this.Children.Add(new Pages.Food.User.FoodListPage());
            this.Children.Add(new Pages.Food.Usda.USDASearchFoodPage());
            this.Children.Add(new Pages.Food.Usda.USDABrowseFoodsPage());
        }
    }
}
