using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using IReach.Services;
using SQLite.Net;
using Xamarin.Forms;

namespace IReach.Data
{
    public class FoodItemDatabase
    {
        static object locker = new object();

        SQLiteConnection database;

        public FoodItemDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<FoodItem>();
        }

        public IEnumerable<FoodItem> GetFoodItems ( )
        {
            lock ( locker )
            {
                return ( from i in database.Table<FoodItem> ( ) select i ).ToList ( );
            }
        }

        public FoodItem GetItem ( int id )
        {
            lock ( locker )
            {
                return database.Table<FoodItem> ( ).FirstOrDefault ( x => x.ID == id );
            }
        }

        public int SaveItem ( FoodItem item )
        {
            lock ( locker )
            {
                if ( item.ID != 0 )
                {
                    database.Update ( item );
                    return item.ID;
                }
                else
                {
                    return database.Insert ( item );
                }
            }
        }
        public int DeleteItem ( int id )
        {
            lock ( locker )
            {
                return database.Delete<FoodItem> ( id );
            }
        }
         
        public double TotalCalories ()
        {
            double total = 0;
            var cal = (from s in database.Table<FoodItem>() select s.Calories);
            foreach (var c in cal)
            {
                total += c;
            }

            Debug.WriteLine("Total Calories = {0}", total); 
            return total;
             
        }
    }
}
