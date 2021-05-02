using System;
using System.IO;
using Foundation;
using SQLite;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.iOS.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace DCAnalyticsMobile.iOS.Services
{
    public class DatabaseService : IDBInterface
    {
        public DatabaseService()
        {
        }

        public SQLiteConnection CreateConnection()
        {
            var sqliteFilename = "DCAnalytics.db3";

            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            string path = Path.Combine(libFolder, sqliteFilename);

            var connection = new SQLiteConnection(path);

            // Return the database connection 
            return connection;
        }
    }
}
