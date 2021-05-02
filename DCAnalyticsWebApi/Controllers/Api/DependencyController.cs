using DCAnalytics.Data;
using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DCAnalyticsWebApi.Controllers.Api
{
    public class DependencyController : BaseApiController
    {
        public DependencyController() : base()
        {
        }

        [HttpGet]
        // GET: api/Topic/id
        [Route("api/Dependency/{Id}")]
        public HttpResponseMessage Get(string id)
        {
            var certification = new DependencyProvider(DbInfo).GetDependency(id);
            var exists = certification != null;
            var status = exists ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return Request.CreateResponse(status, certification);
        }

        [HttpGet]
        // GET: api/Topic/id
        [Route("api/Dependency/GetDependencies/{Id}")]
        public HttpResponseMessage GetDependencies(string id)
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
        public HttpResponseMessage Post(Dependency dependency)
        {
            try
            {
                var provider = new DependencyProvider(DbInfo);
                var isSaved = provider.Save(dependency);
                return Request.CreateResponse(HttpStatusCode.OK, isSaved);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        // DELETE: api/Topic/5
        public HttpResponseMessage Delete(string id)
        {
            var provider = new DependencyProvider(DbInfo);
            var deleted = provider.DeleteDependency(id);
            return Request.CreateResponse(HttpStatusCode.OK, deleted);
        }
    }
}
