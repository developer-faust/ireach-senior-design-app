using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.Models.Local;

namespace IReach.Interfaces
{
    public interface IFitnessChartService
    {
        Task<IEnumerable<DailyStepsDataPoint>> GetDailyStepsDataPointsAsync(IEnumerable<FitnessItem> fitnessItems, int numberOfDays = 1);
    }
}
