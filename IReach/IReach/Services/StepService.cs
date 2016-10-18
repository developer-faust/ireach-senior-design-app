using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IReach.Extensions;
using IReach.Helpers;
using IReach.Interfaces;
using IReach.Models;
using IReach.Services;
using SQLite.Net.Async;
using Xamarin.Forms;


[assembly: Dependency(typeof(StepService))]
namespace IReach.Services
{
    class StepService : IStepService
    {
        private static readonly AsyncLock Locker = new AsyncLock();
        private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISQLite>().GetAsyncConnection();

        public StepService()
        {
            //CreateStepTables();
        }

        /*public async void CreateStepTables()
        {
            await Database.CreateTableAsync<StepItem>();
        }*/

    }
}
