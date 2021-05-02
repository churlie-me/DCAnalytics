using DCAnalytics.Data;
using DCAnalytics.Data.Providers;
using DCAnalytics;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DCAnalyticsWebApi.Controllers.Api
{
    [EnableCors]
    public class TopicController : BaseApiController
    {
        public TopicController():base()
        {

        }
        [HttpGet]
        // GET: api/Topic/id
        [Route("api/Topic/{Id}")]
        public HttpResponseMessage Get(string id)
        {
            var certification = new TopicProvider(DbInfo).GetTopic(int.Parse(id));
            var exists = certification != null;
            var status = exists ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return Request.CreateResponse(status, certification);
        }

        [HttpGet]
        // GET: api/Topic/id
        [Route("api/topic/training/{Id}")]
        public HttpResponseMessage GetTopics(string id)
        {
            try
            {
                var topics = new TopicProvider(DbInfo).GetTopics(id);
                return Request.CreateResponse(HttpStatusCode.OK, topics);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        [HttpPost]
        // POST: api/Topic
        public HttpResponseMessage Post(Topic topic)
        {
            try
            {
                var provider = new TopicProvider(DbInfo);
                var isSaved = provider.Save(topic);
                return Request.CreateResponse(HttpStatusCode.OK, isSaved);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        // PUT: api/Topic/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Topic/5
        public HttpResponseMessage Delete(string id)
        {
            var provider = new TopicProvider(DbInfo);
            var deleted = provider.DeleteTopic(id);
            return Request.CreateResponse(HttpStatusCode.OK, deleted);
        }
    }
}
