using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCAnalytics
{
    public  class DCAnalyticsApp
    {
        public Configuration Configuration { get; private set; }

        private static DCAnalyticsApp _instance;

        public static DCAnalyticsApp Instance
        {
            get
            {
                if(_instance==null)
                {
                    _instance = new DCAnalyticsApp();
                }
                return _instance;
            }
        }

        private  DCAnalyticsApp()
        {
            Configuration = new Configuration();
            CurrentUser = new User(null);
        }

        public User CurrentUser
        {
            get;private set;
        }
       
       
    }
}
