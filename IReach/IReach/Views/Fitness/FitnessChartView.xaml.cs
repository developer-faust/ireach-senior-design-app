using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.ViewModels.Fitness;
using IReach.Views.Base;
using Xamarin.Forms;

namespace IReach.Views.Fitness
{
    public partial class FitnessChartView : FitnessChartViewXaml
    {

        public FitnessChartViewModel ViewModel;
        private ToolbarItem toolbarItem;

        public FitnessChartView ( )
        {
            InitializeComponent ( );

            BindingContext = ViewModel = new FitnessChartViewModel(this.Navigation);

            CircularGauge.BindingContext = ViewModel;

            ViewModel.StepsCount = 70;
            
            // Header position
            Header.Position = Device.OnPlatform(iOS: new Point(0.5, 0.6), Android: new Point(0.5, 0.7), WinPhone:new Point(0.5, 0.7));
        }
    }

    public abstract class FitnessChartViewXaml : ModelBoundContentView<FitnessChartViewModel>
    {
        
    }
}
