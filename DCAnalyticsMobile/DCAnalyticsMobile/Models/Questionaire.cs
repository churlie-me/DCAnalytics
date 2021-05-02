using System;
using System.Collections.Generic;
using System.Text;
using DCAnalytics;

namespace DCAnalyticsMobile.Models
{
    public class Questionaire: DataCollectionObject
    {
        public Statuses Status { get; set; }
        public bool IsSelected { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Section> Sections { get; set; }
        public List<Certification> Certifications { get; set; }
        public DateTime DateTime { get; set; }
        public int Sequence { get; set; }
        public string Template { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public List<Region> Regions { get; set; }
        public Region Region { get; set; }
    }
}
