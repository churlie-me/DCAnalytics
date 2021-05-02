using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DCAnalytics
{
    [DataContract]
    public class Answers : DCAnalyticsObject, IEnumerable<Answer>, ICollection<Answer>
    {

        private List<Answer> _answers;
        public new MapQuestion Parent
        {
            get
            {
                return base.Parent as MapQuestion;
            }
        }

        public int Count
        {
            get
            {
                return _answers.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public Answers(DCAnalyticsObject parent):base(parent)
        {
            _answers = new List<Answer>();
        }

        public override void Cancel()
        {
            
        }

        public IEnumerator<Answer> GetEnumerator()
        {
            foreach (var a in _answers)
                yield return a;
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

        public void Add(Answer item)
        {
            _answers.Add(item);
        }

        public void Clear()
        {
            _answers.Clear();
        }

        public bool Contains(Answer item)
        {
            return _answers.Contains(item);
        }

        public void CopyTo(Answer[] array, int arrayIndex)
        {

        }

        public bool Remove(Answer item)
        {
            return _answers.Remove(item);
        }
    }
}
