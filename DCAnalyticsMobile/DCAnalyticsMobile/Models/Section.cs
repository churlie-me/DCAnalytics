using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalyticsMobile.Models
{
    public class Section : DataCollectionObject
    {
        public string Description { get; set; }
        public List<Question> Questions { get; set; }
        public List<SubSection> SubSections { get; set; }
    }
}
