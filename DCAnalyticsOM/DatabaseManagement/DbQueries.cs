using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DCAnalytics
{
    public class DbQueries :DCAnalyticsObject, IEnumerable<DbQuery>
    {
        private List<DbQuery> _queries;

        public DbQueries(DCAnalyticsObject parent) : base(parent)
        {
        }

        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<DbQuery> GetEnumerator()
        {
            foreach(var q in _queries)
                yield return q;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
