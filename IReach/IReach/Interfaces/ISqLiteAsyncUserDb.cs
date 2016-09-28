using SQLite.Net.Async;

namespace IReach.Interfaces
{
    public interface ISqLiteAsyncUserDb
    {
        SQLiteAsyncConnection GetAsyncConnection();
        void CloseConnection();
    }
}
