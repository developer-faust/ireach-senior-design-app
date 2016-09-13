using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Async;

namespace IReach
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetAsyncConnection ( );
        void CloseConnection ( );
    }
}
