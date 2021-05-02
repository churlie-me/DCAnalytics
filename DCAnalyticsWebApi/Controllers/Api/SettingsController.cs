using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DCAnalyticsWebApi.Controllers.Api
{
    public class SettingsController : ApiController
    {
        // GET: api/Settings
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Settings/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Settings
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Settings/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Settings/5
        public void Delete(int id)
        {
        }
    }
}
