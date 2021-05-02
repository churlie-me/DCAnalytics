using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalyticsMobile.Models
{
    public class Answer: DataCollectionObject
    {
        public string AnswerText { get; set; }
        public bool Deleted { get; set; }
        public string DependenceKey { get; set; }
        public int Occurance { get; set; }
    }
}
