using SQLite.Net;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReach
{
    public interface ISQLiteUsda
    {
        SQLiteConnection GetConnection ( );
        SQLiteAsyncConnection GetAsyncConnection ( );
        void CloseConnection ( );
    }
}
