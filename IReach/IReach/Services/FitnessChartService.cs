using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Interfaces;
using IReach.Models;
using IReach.Models.Local;
using Xamarin.Forms;

namespace IReach.Services
{
    public class FitnessChartService : IFitnessChartService
    {
        private IFitnessDataService _FitnessDataService;

        public FitnessChartService()
        {
            _FitnessDataService = DependencyService.Get<IFitnessDataService>();
        }
         
        
        public async Task<IEnumerable<DailyStepsDataPoint>> GetDailyStepsDataPointsAsync(IEnumerable<FitnessItem> fitnessItems, int numberOfDays = 1)
        {
            var dailyStepsDataPoints = new List<DailyStepsDataPoint>();


            return dailyStepsDataPoints;
        }
    }
}
