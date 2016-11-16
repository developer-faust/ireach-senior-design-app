using IReach.Pages.Base;
using IReach.ViewModels.Fitness;
using IReach.Views.Base;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace IReach.Views.Fitness
{
    public partial class FitnessGraphView : FitnessGraphViewXaml
    {
        public FitnessGraphView()
        {
            InitializeComponent();
            this.BindingContext = new FitnessGraphViewModel(this.Navigation);
            //Chart.BindingContext = ViewModel;

            CalConsumedSeries.SetBinding(ChartSeries.ItemsSourceProperty, "CalorieItems");
        }
    }

    public abstract class FitnessGraphViewXaml : ModelBoundContentView<FitnessGraphViewModel>
    {
    }
}
