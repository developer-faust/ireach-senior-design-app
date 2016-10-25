using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models.Local;
using SQLite.Net.Attributes;
using IReach.Interfaces;
using IReach.ViewModels.Fitness;

namespace IReach.Models
{
    public static class StepCount
    {
        static Lazy<IFitness> _stepcount = new Lazy<IFitness>(() => CreateSteps());
        public static IFitness Steps
        {
            get
            {
                IFitness val = _stepcount.Value;
                return val;
            }
        }

        static IFitness CreateSteps()
        {
            return new FitnessSteps();
        }

    }
    
}
