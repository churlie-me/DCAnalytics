using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DCAnalytics
{
    [DataContract]
    public class Clients : DCAnalyticsObject, IEnumerable<Client>
    {

        private List<Client> _clients;

        public Clients()
        {
            _clients = new List<Client>();
        }

        public override void Cancel()
        {
            
        }

        public Client Add()
        {
            Client client = new Client(this);
            client.ObjectState = ObjectStates.Added;
            _clients.Add(client);
            return client;
        }
        public IEnumerator<Client> GetEnumerator()
        {
            foreach (var c in _clients)
                yield return c;
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
