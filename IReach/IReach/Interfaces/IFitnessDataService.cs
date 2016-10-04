using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;

namespace IReach.Interfaces
{
    public interface IFitnessDataService
    {
        Task<IEnumerable<FitnessItem>>GetFitnessDataAsync();
        Task<FitnessItem> GetFitnessAsync(int id);
        Task SaveFitnessAsync(FitnessItem fitness);
        Task DeleteFitnessAsync(int id);

        bool IsSeeded { get; }
        Task SeedLocalDataAsync();
    }
}
