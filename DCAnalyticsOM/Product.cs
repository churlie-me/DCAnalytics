using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DCAnalytics
{
    [DataContract]
    public class Product : DCAnalyticsObject
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(_name!=value)
                {
                    _name = value;
                    ObjectState = ObjectStates.Modified;
                }
            }
        }

        [DataMember]
        public bool Deleted { get; set; }

        public Product(DCAnalyticsObject parent):base(parent)
        {

        }
        
        
        public override void Cancel()
        {
            
        }

        public override void Update()
        {
            
        }

        public override void Validate()
        {
           
        }
    }
}
