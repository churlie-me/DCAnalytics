using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DCAnalyticsWebApi.Controllers.Api
{
    public class DeviceController : ApiController
    {
        // GET: api/Device
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Device/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Device
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Device/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Device/5
        public void Delete(int id)
        {
        }

        [Route("api/Device/Activate")]
        [HttpGet]
        public HttpResponseMessage Activate (string id,bool activate)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

    }
}
