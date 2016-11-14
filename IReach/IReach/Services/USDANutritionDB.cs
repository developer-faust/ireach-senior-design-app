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


[assembly: Dependency(typeof(USDAFoodService))]
namespace IReach.Services
{
    /// <summary>
    /// This class provides a Implements IUsdaFoodService Interface and is registered as a service using Dependency Injection.
    /// the tag [assembly: Dependency(typeof(USDAFoodService))] registers this class as a service. To get access to this service anywhere 
    /// within the app:
    /// 
    /// var IamAUsdaService = DependencyService.Get<IUsdaFoodService>();
    /// 
    /// IamAUsdaService can now use all the operations within this class
    /// 
    /// </summary>
    public class USDAFoodService : IUsdaFoodService
    {

        private static readonly AsyncLock Locker = new AsyncLock ( );
        private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISQLiteUsda> ( ).GetAsyncConnection ( );

        #region TODO: For Daniel
        /// <summary>
        /// TODO: Daniel implement this part its just a feature to add to the add so that we can view foods with common Nutrients
        /// </summary>
        /// <returns></returns>
        public Task<ObservableCollection<common_nutrient>> GetCommonGetCommonNutrients ( )
        {
            throw new NotImplementedException ( );
        }

        public Task<common_nutrient> GetCommonNutrient ( )
        {
            throw new NotImplementedException ( );
        }

        #endregion

        public async Task<ObservableCollection<food_group>> GetFoodGroups ( )
        {
            using ( await Locker.LockAsync() )
            {
                var result = await Database.QueryAsync<food_group>("SELECT * FROM food_group"); 
                return result.ToObservableCollection();
            }
        }

        public async Task<ObservableCollection<food>> GetFoodsWithGroupId(int groupId)
        {
            using (await Locker.LockAsync())
            {
                Debug.WriteLine("Database GetFoodGroupID = {0}", groupId);
                var result = await (from s in Database.Table<food>()
                              orderby s.id
                              where s.food_group_id == groupId
                              select s).ToListAsync();
                Debug.WriteLine("Result Count = {0}", result.Count);
                 
                return result.ToObservableCollection();
            } 
        }


        /// <summary>
        /// Thre should be no reason to use this for now, because no feature requires the use of all 8000 foods.
        /// </summary>
        /// <returns></returns>
        public Task<ObservableCollection<food>> GetFoods ( )
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

        public async Task<ObservableCollection<food>> SearchFoods ( string searchString)
        {
            Debug.WriteLine("Search string = {0}", searchString);
            var words = (IEnumerable<string>) searchString.Split(' ').ToList(); 

            const string SqlClause = "short_desc LIKE '%{0}%'";
            words = words.Select(word => string.Format(SqlClause, word.Replace("'", "''")));
            var joined = string.Join(" AND ", words.ToArray());
            const string SqlQuery = "SELECT * FROM food WHERE {0}";

            var tableSearch = await Database.QueryAsync<food>(string.Format(SqlQuery, joined)); 
            Debug.WriteLine("Found Count = {0}", tableSearch.Count);

           return tableSearch.ToObservableCollection();
        }

        public async Task<ObservableCollection<food>> SearchFoods(string searchString, int groupId)
        {
            Debug.WriteLine("Searching for food name = {0} with group id = {1}", searchString, groupId); 
            var words = (IEnumerable<string>) searchString.Split(' ').ToList();

            const string SqlClause = "short_desc LIKE '%{0}%'";
            words = words.Select(word => string.Format(SqlClause, word.Replace("'", "''")));

            var joined = string.Join(" AND ", words.ToArray()); 
            const string SqlQuery = "SELECT * FROM food WHERE food_group_id = {0} AND {1}";

            var foods = await Database.QueryAsync<food>(string.Format(SqlQuery, groupId, joined)); 

            Debug.WriteLine("Food Count = {0}", foods.Count);

            return foods.ToObservableCollection();
        }

        public async Task<nutrition> GetNutrition(int foodId) //new function to return calories
        {
            Debug.WriteLine("Get calories for food ID {0}", foodId); 
            const string SqlQuery = "SELECT * FROM nutrition WHERE food_id = {0} AND nutrient_id = 208";

            var nutrition = await Database.QueryAsync<nutrition>(string.Format(SqlQuery, foodId)); 

            return nutrition.FirstOrDefault();
        }
        public async Task<ObservableCollection<FoodNutrients>> GetFoodNutritions(int foodId)
        {
            using (await Locker.LockAsync())
            {
                Debug.WriteLine($"Get nutritions for foodID = {foodId}");
                var nutritions = await Database.QueryAsync<nutrition>($"SELECT * FROM nutrition WHERE food_id = {foodId}");

                ObservableCollection<FoodNutrients> nutritionsInfo = new ObservableCollection<FoodNutrients>();
                foreach (var item in nutritions)
                {
                    var nutrient = await (from s in Database.Table<nutrient>()
                                          where s.id == item.nutrient_id
                                          select s).FirstOrDefaultAsync();

                    if (!char.IsDigit(nutrient.name[0]))
                    {
                        nutritionsInfo.Add(new FoodNutrients()
                        {
                            name = nutrient.name,
                            amount = item.amount,
                            units = nutrient.units
                        });
                    }
                }

                return nutritionsInfo;
            }
        }
    }
}
