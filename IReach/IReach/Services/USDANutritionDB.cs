using System.Collections.Generic;
using Xamarin.Forms;
using IReach.Models;
using IReach.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Helpers;
using SQLite.Net.Async;
using IReach.Service;
using SQLite.Net;

[assembly: Dependency(typeof(USDAFoodService))]
namespace IReach.Service
{
    public class USDAFoodService : IUsdaFoodService
    {

        private static readonly AsyncLock Locker = new AsyncLock ( );
        private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISQLiteUsda> ( ).GetAsyncConnection ( );

        public Task<IList<common_nutrient>> GetCommonGetCommonNutrients ( )
        {
            throw new NotImplementedException ( );
        }

        public Task<common_nutrient> GetCommonNutrient ( )
        {
            throw new NotImplementedException ( );
        }

        public async Task<IList<food_group>> GetFoodGroups ( )
        {
            using ( await Locker.LockAsync() )
            {
                var result = await Database.QueryAsync<food_group>("SELECT * FROM food_group"); 
                return result;
            }
        }

        public async Task<IList<food>> GetFoodsWithGroupId(int groupId)
        {
            using (await Locker.LockAsync())
            {
                Debug.WriteLine("Database GetFoodGroupID = {0}", groupId);
                var result = await (from s in Database.Table<food>()
                              orderby s.id
                              where s.food_group_id == groupId
                              select s).ToListAsync();
                Debug.WriteLine("Result Count = {0}", result.Count);
                 
                return result;
            } 
        }

        public Task<IList<food>> GetFoods ( )
        {
            throw new NotImplementedException ( );
        }

        public async Task<food> GetFoodWithID (int foodId)
        {
            Debug.WriteLine("Get food ID = {0}", foodId);

            var food = await (from s in Database.Table<food>()
                where s.id == foodId
                select s).FirstOrDefaultAsync(); 

            return food;
        }

        public async Task<IList<food>> SearchFoods ( string searchString)
        {
            Debug.WriteLine("Search string = {0}", searchString);
            var words = (IEnumerable<string>) searchString.Split(' ').ToList(); 

            const string SqlClause = "short_desc LIKE '%{0}%'";
            words = words.Select(word => string.Format(SqlClause, word.Replace("'", "''")));
            var joined = string.Join(" AND ", words.ToArray());
            const string SqlQuery = "SELECT * FROM food WHERE {0}";

            var tableSearch = await Database.QueryAsync<food>(string.Format(SqlQuery, joined)); 
            Debug.WriteLine("Found Count = {0}", tableSearch.Count);

           return tableSearch;
        }

        public async Task<IList<food>> SearchFoods(string searchString, int groupId)
        {
            Debug.WriteLine("Searching for food name = {0} with group id = {1}", searchString, groupId); 
            var words = (IEnumerable<string>) searchString.Split(' ').ToList();

            const string SqlClause = "short_desc LIKE '%{0}%'";
            words = words.Select(word => string.Format(SqlClause, word.Replace("'", "''")));

            var joined = string.Join(" AND ", words.ToArray()); 
            const string SqlQuery = "SELECT * FROM food WHERE food_group_id = {0} AND {1}";

            var foods = await Database.QueryAsync<food>(string.Format(SqlQuery, groupId, joined)); 

            Debug.WriteLine("Food Count = {0}", foods.Count);

            return foods;
        }

        public async Task<nutrition> GetNutrition(int foodId) //new function to return calories
        {
            Debug.WriteLine("Get calories for food ID {0}", foodId); 
            const string SqlQuery = "SELECT * FROM nutrition WHERE food_id = {0} AND nutrient_id = 208";

            var nutrition = await Database.QueryAsync<nutrition>(string.Format(SqlQuery, foodId)); 

            return nutrition.FirstOrDefault();
        }

    }
}
