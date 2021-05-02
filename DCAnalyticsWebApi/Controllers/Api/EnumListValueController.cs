using DCAnalytics.Data;
using DCAnalytics.Data.Providers;
using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DCAnalyticsWebApi.Controllers.Api
{
    public class EnumListValueController : BaseApiController
    {

        public EnumListValueController():base()
        {

        }

        [HttpGet]
        [Route("api/Topic/{Key}")]
        public HttpResponseMessage Get(string Key)
        {
            var certification = new EnumListValueProvider(DbInfo).GetEnumListValue(Key);
            var exists = certification != null;
            var status = exists ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return Request.CreateResponse(status, certification);
        }

      
        // POST: api/Inspection
        public HttpResponseMessage Post(EnumListValue enumList)
        {
            try
            {
                var provider = new EnumListValueProvider(DbInfo);
                var isSaved = provider.Save(enumList);
                return Request.CreateResponse(HttpStatusCode.OK, isSaved);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Training/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Configuration/5
        public HttpResponseMessage Delete(string id)
        {
            var provider = new EnumListValueProvider(DbInfo);
            var deleted = provider.DeleteEnumValue(id);
            return Request.CreateResponse(HttpStatusCode.OK, deleted);
        }
    }
}
