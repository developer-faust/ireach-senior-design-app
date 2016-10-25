using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Pages.Fitness;
using IReach.ViewModels.Base;
using Xamarin.Forms;
using IReach.Models;

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
        public double StepsCount
        {
            get { return StepCount.Steps.GetTotalSteps(); }
            set
            {
                if (StepCount.Steps.GetTotalSteps() != value)
                {
                    StepCount.Steps.SetTotalSteps(value);
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

        public double TargetSteps
        {
            get
            {
                return StepCount.Steps.GetStepsGoal();
            }
            set
            {
                if (StepCount.Steps.GetStepsGoal() != value)
                {
                    StepCount.Steps.SetStepsGoal(value);
                    OnPropertyChanged("TargetSteps");
                    Recalculate();
                }

            }
        }

        public string TodaysDate => DateTime.UtcNow.Date.ToString("D");
    }
}
