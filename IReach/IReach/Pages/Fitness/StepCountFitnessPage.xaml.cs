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
        }
    }

    public abstract class StepCountFitnessPageXaml : ModelBoundContentPage<StepCountViewModel>
    {
        
    }
}
