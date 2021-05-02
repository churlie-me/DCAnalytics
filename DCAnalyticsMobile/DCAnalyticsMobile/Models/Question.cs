using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalyticsMobile.Models
{
    public class Question : DataCollectionObject
    {
        public DCAnalytics.QuestionTypes QuestionType { get; set; }
        public string QuestionText { get; set; }
        public bool Required { get; set; }
        public bool Pending { get; set; }
        public DCAnalytics.DataTypes DataType { get; set; }
        public EnumList EnumList { get; set; }
        public List<Answer> Answers { get; set; }
        public List<SkipCondition> Conditions { get; set; }
        public List<Dependency> Dependencies  { get; set; }
        public int Occurance { get; set; }
    }
}
