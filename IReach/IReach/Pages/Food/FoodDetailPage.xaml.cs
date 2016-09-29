using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Pages.Base;
using IReach.ViewModels.Diet;
using Xamarin.Forms;

namespace IReach.Pages.Food
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
