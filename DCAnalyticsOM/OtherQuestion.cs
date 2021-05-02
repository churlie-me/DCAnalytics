using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DCAnalytics
{
    [DataContract]
    public class OtherQuestion : Question
    {
        public string Answer { get; set; }
        public OtherQuestion(DCAnalyticsObject parent) : base(parent)
        {

        }

        public override void Validate()
        {
            
        }

        public override void Cancel()
        {
           
        }

        public override void Update()
        {
            
        }
    }
}
