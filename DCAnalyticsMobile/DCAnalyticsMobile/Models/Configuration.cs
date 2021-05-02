using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalyticsMobile.Models
{
    public class Configuration: DataCollectionObject
    {
        public string FileName { get; set; }
        public string Icon { get; set; }
        public SyncDirection SyncDirection { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool RequireLocation { get; set; }
        public string Domain { get; set; }
        public string Database { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public int Status { get; set; }
        public List<Questionaire> Questionaires { get; set; }
        public List<EnumList> EnumerationLists { get; set; }
        public List<User> Users { get; set; }
        public List<UserRight> UserRights { get; set; }
        public DbInfo DbInfo { get; set; }
        public Settings Settings { get; set; }
        public List<Purchase> Purchases { get; set; }
        public List<Certification> Certifications { get; set; }
        public List<Training> Trainings { get; set; }
        public EnumList Regions { get; set; }
        public EnumList Products { get; set; }
        public EnumList Prices { get; set; }
        public List<FieldInspection> Inspections { get; set; }
        public int Sequence { get; set; }
    }
}
