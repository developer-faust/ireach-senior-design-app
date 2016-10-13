using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Pages.Fitness;
using IReach.ViewModels.Base;
using Xamarin.Forms;

namespace IReach.ViewModels.Fitness
{
    public class FitnessChartViewModel : BaseViewModel
    {
        private INavigation _navigation;
        public FitnessChartViewModel(INavigation navigation) : base(navigation)
        {
            _navigation = navigation;

        }

        // For testing
        private double stepsCount;

        public double StepsCount
        {
            get { return stepsCount; }
            set
            {
                stepsCount = value;
                OnPropertyChanged("StepsCount");
            }
        } 
       
    }
}
