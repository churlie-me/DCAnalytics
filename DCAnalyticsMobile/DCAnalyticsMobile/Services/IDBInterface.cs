using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalyticsMobile.Services
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}
