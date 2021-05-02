using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DCAnalytics
{
    [DataContract]
    public class Dependencies : DCAnalyticsObject, IEnumerable<Dependency>
    {
        private List<Dependency> _dependencies;

        public Dependencies(DCAnalyticsObject parent):base(parent)
        {
            _dependencies = new List<Dependency>();
        }

        public Dependency Add()
        {
            Dependency dependency = new Dependency(this);
            dependency.ObjectState = ObjectStates.Added;
            _dependencies.Add(dependency);
            return dependency;
        }

        public void Remove(Dependency dependency)
        {
            _dependencies.Remove(dependency);
        }

        public override void Cancel()
        {
            
        }

        public IEnumerator<Dependency> GetEnumerator()
        {
            foreach (var d in _dependencies)
                yield return d;
        }

        public override void Update()
        {
            
        }

        public override void Validate()
        {
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
