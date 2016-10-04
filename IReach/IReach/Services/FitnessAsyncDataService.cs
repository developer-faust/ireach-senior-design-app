using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IReach.Helpers;
using IReach.Interfaces;
using IReach.Models;
using IReach.Services;
using SQLite.Net.Async;
using Xamarin.Forms;

[assembly: Dependency(typeof(FitnessAsyncDataService))]
namespace IReach.Services
{
    public class FitnessAsyncDataService : IFitnessDataService
    {
        private static readonly AsyncLock Locker = new AsyncLock();

        private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISQLite>().GetAsyncConnection();

        public FitnessAsyncDataService()
        {
            CreateAllTablesAsync();

        }
        public async void CreateAllTablesAsync()
        {
            await Database.CreateTableAsync<FitnessItem>();
        }

        public Task<IEnumerable<FitnessItem>> GetFitnessDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FitnessItem> GetFitnessAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveFitnessAsync(FitnessItem fitness)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFitnessAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsSeeded { get; }
        public Task SeedLocalDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
