using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalyticsMobile.Models
{
    public class Package : DataCollectionObject
    {
        public Plan Plan { get; set; }
        public bool Deleted { get; set; }
        public decimal Price { get; set; }
    }
}
