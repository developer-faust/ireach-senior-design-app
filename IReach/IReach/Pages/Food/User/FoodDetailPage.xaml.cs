using IReach.Pages.Base;
using IReach.ViewModels.Foods;

namespace IReach.Pages.Food.User
{
    public partial class FoodDetailPage : FoodDetailPageXaml
    {
        public FoodDetailPage()
        {
            InitializeComponent();
        }
    }

    public abstract class FoodDetailPageXaml : ModelBoundContentPage<FoodDetailViewModel>
    {
    }
}
