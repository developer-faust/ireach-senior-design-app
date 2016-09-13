using System.Collections.Generic;
using Xamarin.Forms;
using IReach.Models;
using IReach.Services;
using System;
using System.Threading.Tasks;
using IReach.Helpers;
using SQLite.Net.Async;
using IReach.Service;

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
                return await Database.Table<food_group> ( ).Where ( x => x.id > 0 ).ToListAsync ( );
            }
        }

        public Task<IList<food>> GetFoods ( )
        {
            throw new NotImplementedException ( );
        }

        public Task<food> GetFoodWithID ( int foodId )
        {
            throw new NotImplementedException ( );
        }

        public Task<IList<food>> SearchFoods ( string name )
        {
            throw new NotImplementedException ( );
        }

        /*  static object locker = new object();

          SQLiteConnection database;

          public USDANutritionDB()
          {
              database = DependencyService.Get<ISQLiteUsda>().GetConnection();
              database.CreateTable<food>(); 
          }

          public IEnumerable<common_nutrient> GetCommonNutrients()
          {
              lock (locker)
              {
                  return (from i in database.Table<common_nutrient>() select i).ToList();
              } 
          }

          public common_nutrient GetCommonNutrient(int id)
          {
              lock (locker)
              {
                  return database.Table<common_nutrient>().FirstOrDefault(x => x.id == id);
              }
          }

          public IEnumerable<food> GetFoods()
          {
              lock (locker)
              {
                  return (from i in database.Table<food>() select i).ToList();
              }
          }

          public food GetFoodWithID(int id)
          {
              lock (locker)
              { 

                  var food = database.Table<food>().FirstOrDefault(x => x.id == id);
                  Debug.WriteLine ( "food ID = {0}", id );
                  Debug.WriteLine("short desc: {0}", food.short_desc);
                  return food;
              }
          }

          public IEnumerable<food> GetFoodsWithGroupID (int groupID)
          {
              lock (locker)
              {
                  var foods = (from i in database.Table<food>() select i).ToList();
                  var items = (from h in foods
                      where h.food_group_id == groupID
                      select h);

                  int j = 0;
                  foreach ( var foodInGroup in items )
                  {
                      Debug.WriteLine ( "Group: {0} -- {1}", j++, foodInGroup.short_desc );
                  }
                  return items;
              }
          }
          public IEnumerable<food> SearchFood(string foodName)
          {
              lock (locker)
              {
                  var foods = (from i in database.Table<food>() select i).ToList();

                  var item = (from h in foods
                      where h.short_desc.Contains(foodName.ToUpper())
                      select h);

                  var searchFood = item as IList<food> ?? item.ToList(); 
                  return searchFood; 
              }
          }

          public IEnumerable<food_group> GetFoodGroups()
          {
              lock (locker)
              {
                  var foodGroups = (from i in database.Table<food_group>() select i).ToList();

                  int j = 0;
                  foreach (var foodGroup in foodGroups)
                  {
                      Debug.WriteLine("Group: {0} -- {1}", j++, foodGroup.name);
                  }
                  return foodGroups;
              }
          }
          */

    }
}
