using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalyticsMobile.Models
{
    public class DbInfo
    {
        public string Server { get; set; }
        public string Authentication { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string DatabaseType { get; set; }
        public string MasterConnectionString { get; set; }
        public string ConnectionString { get; set; }
    }
}
