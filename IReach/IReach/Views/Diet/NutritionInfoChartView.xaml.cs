using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.ViewModels.Foods;
using IReach.Views.Base;
using Xamarin.Forms;

namespace IReach.Views.Diet
{
    public partial class NutritionInfoChartView : NutritionInfoChartViewXaml
    {
        public NutritionInfoChartView()
        {
            InitializeComponent();
        }
    }

    public abstract class NutritionInfoChartViewXaml : ModelBoundContentView<FoodNutritionChartViewModel>
    {

    }
}
