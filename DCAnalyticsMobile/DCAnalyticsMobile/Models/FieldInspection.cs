using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalyticsMobile.Models
{
    public class FieldInspection: DataCollectionObject
    {
        public DateTime DateTime { get; set; }
        public Statuses Status { get; set; }
        public string FarmerKey { get; set; }
        public string Template { get; set; }
        public string FieldName { get; set; }
        public List<Section> Sections { get; set; }
        public List<string> Coordinates { get; set; }
        public int ConfigurationId { get; set; }
    }
}
