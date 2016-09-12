using System;
using System.IO;
using IReach;
using IReach.Droid;
using IReach.Services;
using Xamarin.Forms;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using SQLite.Net.Async;

[assembly: Dependency(typeof(USDALite_Android))]
namespace IReach
{
    public class USDALite_Android : IUsdaService
    {

        private SQLiteConnectionWithLock _conn;

        public USDALite_Android ( )
        {
        }

        private static string GetDatabasePath ( )
        {
            const string sqliteFilename = "usda_food.sqlite3";

            string documentsPath = Environment.GetFolderPath ( Environment.SpecialFolder.Personal ); // Documents folder
            var path = Path.Combine ( documentsPath, sqliteFilename );

            Console.WriteLine ( path );
            if ( !File.Exists ( path ) )
            {
                var s = Forms.Context.Resources.OpenRawResource ( IReach.Droid.Resource.Raw.usda_food );
                FileStream writeStream = new FileStream ( path, FileMode.OpenOrCreate, FileAccess.Write );

                ReadWriteStream ( s, writeStream );
            }
            return path;
        }

        public SQLiteConnection GetConnection()
        {
            var dbPath = GetDatabasePath ( ); 
            return new SQLiteConnection ( new SQLitePlatformAndroid ( ), dbPath );
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            var dbPath = GetDatabasePath ( );
            var platform = new SQLitePlatformAndroid ( );

            var connectionFactory = new Func<SQLiteConnectionWithLock> (
                ( ) =>
                {
                    if ( _conn == null )
                    {
                        _conn = new SQLiteConnectionWithLock ( platform,
                            new SQLiteConnectionString ( dbPath, storeDateTimeAsTicks: true ) );
                    }

                    return _conn;
                } );

            return new SQLiteAsyncConnection ( connectionFactory );

        }

        public void CloseConnection()
        {
            if ( _conn != null )
            {
                _conn.Close ( );
                _conn.Dispose ( );
                _conn = null;

                GC.Collect ( );
                GC.WaitForPendingFinalizers ( );
            }
        }

        private static void ReadWriteStream(Stream readStream, FileStream writeStream)
        {

            int Length = 256;
            Byte[ ] buffer = new Byte[ Length ];
            int bytesRead = readStream.Read ( buffer, 0, Length );
            // write the required bytes
            while ( bytesRead > 0 )
            {
                writeStream.Write ( buffer, 0, bytesRead );
                bytesRead = readStream.Read ( buffer, 0, Length );
            }
            readStream.Close ( );
            writeStream.Close ( );
        }
    }
}