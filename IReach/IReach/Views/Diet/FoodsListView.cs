using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Cells.Food;
using IReach.Statics;
using Xamarin.Forms;

namespace IReach.Views.Diet
{
    public class FoodsListView : NonPresistentSelectedItemListView
    {
        public FoodsListView()
        {
            HasUnevenRows = false;
            RowHeight = RowSizes.LargeRowHeightInt;
            SeparatorVisibility = SeparatorVisibility.None;
            ItemTemplate = new DataTemplate(typeof(FoodListItemCell));
        }
    }
}
