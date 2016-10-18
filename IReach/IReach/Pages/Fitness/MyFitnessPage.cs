using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Localization;
using Xamarin.Forms;

namespace IReach.Pages.Fitness
{
    public class MyFitnessPage: ContentPage
    {
        public string Heading; 
        public MyFitnessPage()
        {  
            Heading = "This is the Fitness page"; 
            // rendering of this page is done natively on each platform, otherwise it will just be blank
        }
    }
}
