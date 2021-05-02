using DCAnalytics;

namespace DCAnalyticsMobile.Models
{
    public class Dependency: DataCollectionObject
    {
        public DataCollectionObectTypes TargetObjectType { get; set; }
        public Target Target { get; set; }
        public string TargetObjectKey { get; set; }
        public string Template { get; set; }
        public bool Deleted { get; set; }
        public int Occurance { get; set; } = -1;
    }
}