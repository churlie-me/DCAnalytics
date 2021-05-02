using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DCAnalytics
{
    [DataContract]
    public class MapQuestion : Question
    {
        [DataMember]
        public new Answers Answers
        {
            get;
            set;
        }
        public MapQuestion(DCAnalyticsObject parent) : base(parent)
        {
            Answers = new Answers(this);
        }

    }
}
