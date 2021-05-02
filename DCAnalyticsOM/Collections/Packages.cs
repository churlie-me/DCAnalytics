using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DCAnalytics
{
    public class Packages : DCAnalyticsObject, IEnumerable<Package>
    {
        private List<Package> _packages;

        public Packages()
        {
            _packages = new List<Package>();
        }

        public Package Add()
        {
            Package package = new Package();
            _packages.Add(package);
            return package;
        }

        public override void Cancel()
        {

        }

        public IEnumerator<Package> GetEnumerator()
        {
            foreach (var b in _packages)
                yield return b;
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