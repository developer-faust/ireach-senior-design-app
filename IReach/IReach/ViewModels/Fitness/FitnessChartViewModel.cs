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
        private double _stepsCount; 
        public double StepsCount
        {
            get { return _stepsCount; }
            set
            {
                if (_stepsCount != value)
                {
                    _stepsCount = value;
                    OnPropertyChanged("StepsCount");
                    Recalculate();
                }
               
            }
        }

        public void Recalculate()
        {

            _percentComplete = (StepsCount / TargetSteps) * 100;
        }

        private double _percentComplete; 
        public double Complete
        {
            get { return Math.Round(_percentComplete, 1); }
            set
            {
                if (_percentComplete != value)
                {
                    _percentComplete = value;
                    OnPropertyChanged("Complete");
                } 
            }
        }

        private double _target; 
        public double TargetSteps
        {
            get
            {
                return _target;
            }
            set
            {
                if (_target != value)
                {
                    _target = value;
                    OnPropertyChanged("TargetSteps");
                    Recalculate();
                }

            }
        }

        public string TodaysDate => DateTime.UtcNow.Date.ToString("D");

        
    }
}
