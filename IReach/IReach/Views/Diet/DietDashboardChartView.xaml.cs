using IReach.Pages.Base;
using IReach.ViewModels.Diary;
using IReach.Views.Base;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace IReach.Views.Diet
{
    public partial class DietDashboardChartView : DietDashboardChartViewXaml
    { 
        public DietDashboardChartView()
        {
            InitializeComponent(); 
            this.BindingContext = new DietDashboardChartViewModel(this.Navigation);
            //Chart.BindingContext = ViewModel;

            CalConsumedSeries.SetBinding(ChartSeries.ItemsSourceProperty, "CalorieItems"); 
        }   
    }

    public abstract class DietDashboardChartViewXaml : ModelBoundContentView<DietDashboardChartViewModel>
    {  
    }
}
