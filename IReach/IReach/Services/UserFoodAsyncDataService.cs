using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using IReach.Extensions;
using IReach.Helpers;
using IReach.Interfaces;
using IReach.Models;
using IReach.Services;
using SQLite.Net.Async;
using Xamarin.Forms;

[assembly: Dependency(typeof(UserFoodAsyncDataService))]
namespace IReach.Services
{
    public class UserFoodAsyncDataService : IUserFoodDataService
    {
        private static readonly AsyncLock Locker = new AsyncLock();
        private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISQLite>().GetAsyncConnection();

        public UserFoodAsyncDataService()
        {
            CreateAllTablesAsync();
        }

        public async void CreateAllTablesAsync()
        {
            await Database.CreateTableAsync<FoodItem>();
        }


        public async Task<ObservableCollection<FoodItem>> GetFoodsAsync()
        {
            using (await Locker.LockAsync())
            {
                var result = await Database.QueryAsync<FoodItem>("SELECT * FROM FoodItem");
                return result.ToObservableCollection();
            }
        }

        internal Task GetFoodAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<FoodItem> GetFoodAsync(int id)
        {
            using (await Locker.LockAsync())
            {
                var result = await (from s in Database.Table<FoodItem>()
                                    orderby s.ID
                                    where s.ID == id
                                    select s).FirstOrDefaultAsync();

                return result;
            }

        }

        public async Task SaveFoodAsync(FoodItem food)
        {
            using (await Locker.LockAsync())
            {
                if (food.ID != 0)
                {
                    await Database.UpdateAsync(food);
                }
                else
                {
                    await Database.InsertAsync(food);
                }
            }
        }

        public async Task DeleteFoodAsync(int foodId)
        {
            using (await Locker.LockAsync())
            {
                await Database.DeleteAsync<FoodItem>(foodId);
            }
        }

        private bool _isSeeded;
        public bool IsSeeded { get { return _isSeeded; } }

        private bool _IsSeeded;
        public async Task SeedLocalDataAsync()
        {
            _IsSeeded = true;
        }


        public double TotalCalories()
        {
            double total = 0;
            var foods = GetFoodsAsync();
            foreach (var food in foods.Result)
            {
                total += food.Calories;
            }
            return total;
        }
    }
}
