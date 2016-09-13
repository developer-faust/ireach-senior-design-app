using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.ViewModels;
using Xamarin.Forms;

namespace IReach.Controls
{
    public class FoodViewTemplateSelector : DataTemplateSelector
    {

        public DataTemplate FoodGroupTemplate { get; set; }
        public DataTemplate SearchFoodTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item.GetType() == typeof(food))
            {
                Debug.WriteLine("I am food");
                return SearchFoodTemplate;
            }

            Debug.WriteLine("I am food_group");
            return FoodGroupTemplate;
        }
    }
}
