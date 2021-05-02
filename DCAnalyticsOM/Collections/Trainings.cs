using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DCAnalytics
{
    [DataContract]
    public class Trainings : DCAnalyticsObject, IEnumerable<Training>
    {

        private List<Training> _trainings;

        public Trainings():base()
        {
            _trainings = new List<Training>();
        }
        public Trainings(DCAnalyticsObject parent):base(parent)
        {
            _trainings = new List<Training>();
        }
        public Training Add()
        {
            Training trainer = new Training(this);
            trainer.ObjectState = ObjectStates.Added;
            _trainings.Add(trainer);
            return trainer;
        }

        public void Remove(Training training)
        {
            _trainings.Remove(training);
        }

        public override void Cancel()
        {
            
        }

        public IEnumerator<Training> GetEnumerator()
        {
            foreach (var tc in _trainings)
                yield return tc;
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

        public override void ReadJson(JObject obj)
        {
            base.ReadJson(obj);
            JArray trainingObjs = JArray.FromObject(obj["Trainings"]);
            if (trainingObjs != null)
            {
                foreach (var cobj in trainingObjs)
                {
                    var training = Add();
                    training.ReadJson((JObject)cobj);
                }
            }
        }




    }
}
