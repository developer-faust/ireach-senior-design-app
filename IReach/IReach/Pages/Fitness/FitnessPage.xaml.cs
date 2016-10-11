using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Pages.Base;
using IReach.ViewModels.Fitness;
using IReach.Views.Base;
using Xamarin.Forms;

namespace IReach.Pages.Fitness
{
    public partial class FitnessPage : FitnessPageXaml
    {
        public FitnessPage()
        {
            InitializeComponent();
        }
    }

    public abstract class FitnessPageXaml : ModelBoundContentPage<FitnessViewModel>
    {
    }
}
