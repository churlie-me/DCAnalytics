using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalyticsMobile.Models
{
    public class Certification: DataCollectionObject
    {
        public Statuses Status { get; set; }
        public int Sequence { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public CertificationTypes CerificationType { get; set; }
        public List<Section> Sections { get; set; }
        public string FarmerKey { get; set; }
        public string Template { get; set; }
        public int ConfigurationId { get; set; }
    }
}
