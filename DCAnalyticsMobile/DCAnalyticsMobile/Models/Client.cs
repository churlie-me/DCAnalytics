using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalyticsMobile.Models
{
    public class Client : DataCollectionObject
    {
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Logo { get; set; }
        public string Location { get; set; }
        public bool Deleted { get; set; }
        public Package Package { get; set; }
    }
}
