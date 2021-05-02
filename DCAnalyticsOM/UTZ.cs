using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DCAnalytics
{
    [DataContract]
    public class UTZ : Certification
    {
        [DataMember]
        public new string Key
        {
            get
            {
                return base.Key;
            }
            set
            {
                base.Key = value;
            }
        }
        [DataMember]
        public new int OID
        {
            get
            {
                return base.OID;
            }
            set
            {
                base.OID = value;
            }
        }
        public UTZ(DCAnalyticsObject parent):base(parent)
        {
            CerificationType = CertificationTypes.FairTrade;
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
