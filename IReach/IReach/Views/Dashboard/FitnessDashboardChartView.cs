using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Statics;
using IReach.ViewModels.Dashboard;
using IReach.Views.Base;
using Xamarin.Forms;

namespace IReach.Views.Dashboard
{
    public class FitnessDashboardChartView : ModelBoundContentView<FitnessDashboardChartViewModel>
    {
        public FitnessDashboardChartView()
        {
            var chartHeaderView = new FitnessDashChartHeaderView()
            {
                HeightRequest = RowSizes.MediumRowHeightDouble,
                Padding = new Thickness(20, 10, 20, 0)
            };

            chartHeaderView.SetBinding(FitnessDashChartHeaderView.DailyStepsProperty, "DailyStepsTaken");


        }

    }
}
