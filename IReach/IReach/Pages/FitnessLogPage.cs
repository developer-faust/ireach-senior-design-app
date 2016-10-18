using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using IReach.Pages.Fitness;
using Xamarin.Forms;

namespace IReach.Pages
{
    public class FitnessLogPage : TabbedPage
    {
        public FitnessLogPage()
        {
            this.Children.Add(new FitnessDashboardPage());
            this.Children.Add(new MyFitnessPage()
            {
                Title = "Fitness Page"
            });
        }
         
    }
}
