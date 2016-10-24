using System.Text;
using System.Threading.Tasks;
using IReach.Pages.Fitness;
using IReach.ViewModels.Base;
using Xamarin.Forms;

namespace IReach.ViewModels.Fitness
{
    public class FitnessSettingsViewModel : BaseViewModel
    {
        private INavigation _navigation;
        private FitnessChartViewModel FitnessChartViewModel;
        public FitnessSettingsViewModel(INavigation nav) : base(nav)
        {
            _navigation = nav;
            //FitnessChartViewModel = new FitnessChartViewModel(this.Navigation);
        }

        private double _goal;
        public double Goal
        {
            get { return _goal; }//FitnessChartViewModel.TargetSteps; }
            set
            {
                /*if (FitnessChartViewModel.TargetSteps != value)
                {
                    FitnessChartViewModel.TargetSteps = value;
                    FitnessChartViewModel.Recalculate();
                }*/
                _goal = value;
            }
        }

        private int _sensitivity;
        public int Sensitivity
        {
            get { return _sensitivity; }
            set { _sensitivity = value; }
        }

        private double _steps;
        public double CurrentSteps
        {
            get { return _steps; }//FitnessChartViewModel.StepsCount; }
            set
            {
                /*if (FitnessChartViewModel.StepsCount != value)
                {
                    FitnessChartViewModel.TargetSteps = value;
                    FitnessChartViewModel.Recalculate();
                }*/
                _steps = value;
            }
        } 
    }
}
