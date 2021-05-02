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
    public class TrainerController : BaseApiController
    {

        public TrainerController():base()
        {

        }
        [HttpGet]
        // GET: api/configuration/id
        [Route("api/Trainer/{Id}")]
        public HttpResponseMessage Get(string id)
        {
            var certification = new TrainerProvider(DbInfo).GetTrainer(int.Parse(id));
            var exists = certification != null;
            var status = exists ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return Request.CreateResponse(status, certification);
        }

        [HttpGet]
        [Route("api/trainer/training/{Id}")]
        public HttpResponseMessage GetTrainers(string id)
        {
            try
            {
                var trainers = new TrainerProvider(DbInfo).GetTrainers(id);
                return Request.CreateResponse(HttpStatusCode.OK, trainers);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.StackTrace);
            }
        }

        public HttpResponseMessage Post(Trainer trainer)
        {
            try
            {
                var provider = new TrainerProvider(DbInfo);
                var isSaved = provider.Save(trainer);
                return Request.CreateResponse(HttpStatusCode.OK, isSaved);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        // PUT: api/Training/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Topic/5
        public HttpResponseMessage Delete(string id)
        {
            var provider = new TrainerProvider(DbInfo);
            var deleted = provider.DeleteTrainer(id);
            return Request.CreateResponse(HttpStatusCode.OK, deleted);
        }
    }
}
