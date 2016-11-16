using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Extensions;
using IReach.Interfaces;
using IReach.Models;
using IReach.Models.Local;
using IReach.ViewModels.Base;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace IReach.ViewModels.Fitness
{
    public class FitnessGraphViewModel : BaseViewModel
    {
        private INavigation _navigation;
        public FitnessGraphViewModel(INavigation navigation = null) : base(navigation)
        {
            IsBusy = false;
            IsInitialized = false;
            _navigation = navigation;

            //ExecuteLoadSeedDataCommand();
        }
    }
}
