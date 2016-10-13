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
                PercentComplete = (value/TargetSteps)*100;
                OnPropertyChanged("StepsCount");
            }
        }

        private double _percentComplete; 
        public double PercentComplete
        {
            get { return _percentComplete; }
            set
            {
                _percentComplete = value;
                OnPropertyChanged("PercentComplete");
            }
        }

        private double _target = 500; 
        public double TargetSteps
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
                OnPropertyChanged("TargetSteps");
            }
        }

        public string TodaysDate => DateTime.UtcNow.Date.ToString("D");
    }
}
