using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using DCAnalyticsMobile.Droid.Services;
using Xamarin.Forms;
using DCAnalyticsMobile.Services;
using Environment = System.Environment;

[assembly: Dependency(typeof(DatabaseService))]
namespace DCAnalyticsMobile.Droid.Services
{
    public class DatabaseService : IDBInterface
    {
        public DatabaseService()
        {
        }

        public SQLiteConnection CreateConnection()
        {
            var sqliteFilename = "DCAnalytics.db3";
            string documentsDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsDirectoryPath, sqliteFilename);

            var conn = new SQLiteConnection(path);

            return conn;
        }

        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            while (bytesRead >= 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}