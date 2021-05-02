using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalyticsMobile.Models
{
    public class Training : DataCollectionObject
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public List<Trainer> Trainers { get; set; }
        public List<Topic> Topics { get; set; }
        public List<Trainee> Trainees { get; set; }
    }
}