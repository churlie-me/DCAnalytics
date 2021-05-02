using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DCAnalyticsWebApi.Controllers.Api
{
    public class DbInfoController : ApiController
    {
        // GET: api/DbInfo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DbInfo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DbInfo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DbInfo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DbInfo/5
        public void Delete(int id)
        {
        }
    }
}
