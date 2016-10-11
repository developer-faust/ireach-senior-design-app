using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.ViewModels.Base;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace IReach.ViewModels.Fitness
{
    public class FitnessViewModel : BaseViewModel
    {

       

        public ObservableCollection<Model> StackedColumnData1 { get; set; }

        public ObservableCollection<Model> StackedColumnData2 { get; set; }

        public ObservableCollection<Model> StackedColumnData3 { get; set; }

        public ObservableCollection<Model> StackedColumnData4 { get; set; }

    

        public FitnessViewModel()
        { 

            StackedColumnData1 = new ObservableCollection<Model>
            {
                new Model("Jan", 900),
                new Model("Feb", 820),
                new Model("Mar", 880),
                new Model("Apr", 725),
                new Model("May", 765),
                new Model("Jun", 679),
            };
            StackedColumnData2 = new ObservableCollection<Model>
            {
                new Model("Jan", 190),
                new Model("Feb", 226),
                new Model("Mar", 194),
                new Model("Apr", 250),
                new Model("May", 222),
                new Model("Jun", 181),
            };
            StackedColumnData3 = new ObservableCollection<Model>
            {
                new Model("Jan", 250),
                new Model("Feb", 145),
                new Model("Mar", 190),
                new Model("Apr", 220),
                new Model("May", 225),
                new Model("Jun", 135),
            };
            StackedColumnData4 = new ObservableCollection<Model>
            {
                new Model("Jan", 150),
                new Model("Feb", 120),
                new Model("Mar", 115),
                new Model("Apr", 125),
                new Model("May", 132),
                new Model("Jun", 137),
            };
               
        } 

    }
}
