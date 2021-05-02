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
    public class TrainingController : BaseApiController
    {  
        public TrainingController():base()
        {
            
        }
  
        [HttpGet]
        // GET: api/configuration/id
        [Route("api/Training/{Id}")]
        public HttpResponseMessage Get(string id)
        {
            var certification = new TrainingProvider(DbInfo).GetTraining(int.Parse(id));
            var exists = certification != null;
            var status = exists ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return Request.CreateResponse(status, certification);
        }

        [HttpGet]
        [Route("api/training/reports/{configuration_id}")]
        public HttpResponseMessage GetReports(string configuration_id)
        {
            try
            {
                var reports = new TrainingProvider(DbInfo).GetReports(configuration_id);
                return Request.CreateResponse(HttpStatusCode.OK, reports);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        [HttpGet]
        // GET: api/configuration/id
        [Route("api/training/configuration/{Id}")]
        public HttpResponseMessage GetTrainings(string id)
        {
            try
            {
                var trainings = new TrainingProvider(DbInfo).GetTrainings(int.Parse(id));
                return Request.CreateResponse(HttpStatusCode.OK, trainings);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        [HttpPost]
        [Route("api/training/")]
        // POST: api/Training
        public HttpResponseMessage Post(Training training)
        {
            try
            {
                var provider = new TrainingProvider(DbInfo);
                var isSaved = provider.Save(training);
                if (isSaved)
                    return Request.CreateResponse(HttpStatusCode.OK, provider.LastEntry(training.Key));

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

        // DELETE: api/Topic/5
        public HttpResponseMessage Delete(string id)
        {
            var provider = new TrainingProvider(DbInfo);
            var deleted = provider.DeleteTraining(id);
            return Request.CreateResponse(HttpStatusCode.OK, deleted);
        }
    }
}
