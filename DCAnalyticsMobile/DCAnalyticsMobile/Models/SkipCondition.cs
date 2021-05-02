using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalyticsMobile.Models
{
    public class SkipCondition: DataCollectionObject
    {
        public string AttributeKey { get; set; }
        public Qualifiers Qualifier { get; set; }
        public DataCollectionObectTypes DataCollectionObectType { get; set; }
        public EnumValue Answer { get; set; }
        public Target Target { get; set; }
    }
}
