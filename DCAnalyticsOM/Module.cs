using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalytics
{
    public class Module : DCAnalyticsObject
    {

        
        public Module()
        {
        }

        public Module(DCAnalyticsObject parent) : base(parent)
        {
        }

        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
