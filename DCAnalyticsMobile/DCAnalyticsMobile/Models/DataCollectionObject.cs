using DCAnalytics;

namespace DCAnalyticsMobile.Models
{
    public class DataCollectionObject
    {
        public int OID { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public bool IsSystem { get; set; }
        public string TableName { get; set; }
        public DataCollectionObectTypes CollectionObjectType { get; set; }
    }
}