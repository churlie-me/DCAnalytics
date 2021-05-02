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
    public class TraineeController : BaseApiController
    {

        public TraineeController() : base()
        {

        }
        [HttpGet]
        // GET: api/configuration/id
        [Route("api/Trainee/{Id}")]
        public HttpResponseMessage Get(string id)
        {
            var certification = new TraineeProvider(DbInfo).GetTrainee(int.Parse(id));
            var exists = certification != null;
            var status = exists ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return Request.CreateResponse(status, certification);
        }

        [HttpGet]
        // GET: api/configuration/id
        [Route("api/trainee/training/{Id}")]
        public HttpResponseMessage GetTrainee(string id)
        {
            try
            {
                var trainees = new TraineeProvider(DbInfo).GetTrainees(int.Parse(id));
                return Request.CreateResponse(HttpStatusCode.OK, trainees);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        // POST: api/Inspection
        public HttpResponseMessage Post(Trainee trainee)
        {
            try
            {
                var provider = new TraineeProvider(DbInfo);
                var isSaved = provider.Save(trainee);
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
            var provider = new TraineeProvider(DbInfo);
            var deleted = provider.DeleteTrainee(id);
            return Request.CreateResponse(HttpStatusCode.OK, deleted);
        }
    }
}
