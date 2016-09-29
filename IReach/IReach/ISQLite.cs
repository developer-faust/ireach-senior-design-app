using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Async;

namespace IReach
{
    /// <summary>
    /// Interface for working with both Sync and Async database. 
    /// 
    /// Implemented by the SQLite_Android Service to gain acces to native android sqlite database. To gain access to the database the app uses DependencyService.Get<ISQLite>().GetConnection or
    /// DependencyService.Get<ISQLite>().GetConnectionAsync for async database operation
    /// </summary>
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetAsyncConnection ( );
        void CloseConnection ( );
    }
}
