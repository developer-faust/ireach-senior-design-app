using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Pages.Base;
using IReach.ViewModels.Fitness;
using Xamarin.Forms;

namespace IReach.Pages.Fitness
{
    public partial class StepCountFitnessPage : StepCountFitnessPageXaml
    {
        public StepCountFitnessPage()
        {
            InitializeComponent();
            double weight = 200; //average number for purposes of this (will have to get users actual weight to implement this
            double stepsperMile = 2000; //average number of steps per mile
            double calorieConverion = weight * 1.28 / stepsperMile; //1.28 is the average calories/pound/mile at casual walking speed (2mph); 1.96 is for brisk walking (3mph)
            double caloriesBurned = calorieConverion * Convert.ToDouble(StepsCounted.Text);
            CaloriesBurnedValue.Text = caloriesBurned.ToString();
        }
    }

    public abstract class StepCountFitnessPageXaml : ModelBoundContentPage<StepCountViewModel>
    {
        
    }
}
