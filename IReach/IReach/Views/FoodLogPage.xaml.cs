using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace IReach.Views
{
    public partial class FoodLogPage : TabbedPage
    {
        public FoodLogPage()
        {
            InitializeComponent();

            this.Children.Add(new FoodListPage());
            this.Children.Add(new USDASearchFoodPage());
            this.Children.Add(new USDABrowseFoodsPage());
        }
    }
}
