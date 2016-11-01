using IReach.Pages.Base;
using IReach.ViewModels.Foods;
using IReach.Views.Diet;
using Xamarin.Forms;

namespace IReach.Pages.Food.User
{
    public partial class FoodDetailPage : FoodDetailPageXaml
    {

        private StackLayout contentFrame;
        private FoodNutritionChartViewModel NutritionChartViewModel { get; set; }
        public FoodDetailPage()
        {
            InitializeComponent();
            BindingContext = new FoodDetailViewModel(this.Navigation);

            var nutritionInfoChartView = new NutritionInfoChartView()
            {
                BindingContext = NutritionChartViewModel = new FoodNutritionChartViewModel(this.Navigation)
            }; 
            
            content.Children.Insert(0, nutritionInfoChartView);
            
        }


    }

    public abstract class FoodDetailPageXaml : ModelBoundContentPage<FoodDetailViewModel>
    {
    }
}
