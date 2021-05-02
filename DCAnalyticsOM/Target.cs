using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace DCAnalytics
{
    public class Target
    {
        [DataMember]
        public Section Section { get; set; }

        [DataMember]
        public SubSection SubSection { get; set; }

        [DataMember]
        public Question Question { get; set; }
    }
}
