using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Data;
using IReach.Helpers;
using IReach.Interfaces;
using IReach.Models;
using SQLite.Net.Async;
using Xamarin.Forms;

[assembly: Dependency(typeof(FoodItemAsyncDb))]
namespace IReach.Data
{
    public class FoodItemAsyncDb : IFoodDataService
    {
        private static readonly AsyncLock Locker = new AsyncLock();
        private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISQLite>().GetAsyncConnection(); 

        public FoodItemAsyncDb()
        {
            CreateAllTablesAsync();
        }

        public async void CreateAllTablesAsync()
        {
            await Database.CreateTableAsync<FoodItem>();
        }


        public async Task<IEnumerable<FoodItem>> GetFoodsAsync()
        {
            using (await Locker.LockAsync())
            {
                var query = await (from s in Database.Table<FoodItem>()
                    orderby s.ID
                    select s).ToListAsync();

                return query;
            }
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
