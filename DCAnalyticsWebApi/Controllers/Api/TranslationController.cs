using DCAnalytics;
using Google.Cloud.Translation.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DCAnalyticsWebApi.Controllers.Api
{
    public class TranslationController : ApiController
    {
        public TranslationController()
        {

        }

        [HttpPost]
        //api/Translation/Translate
        public HttpResponseMessage Translate(Configuration configuration)
        {
            new TranslationService(configuration).Translate();
            return Request.CreateResponse(HttpStatusCode.OK, configuration);
        }

        // GET: api/Translation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Translation/5
        public string Get(int id)
        {
            return "value";
        }

        //// POST: api/Translation
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT: api/Translation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Translation/5
        public void Delete(int id)
        {
        }
    }
}
