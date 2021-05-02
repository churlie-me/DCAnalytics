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
    public class SyncController : BaseApiController
    {
        public SyncController():base()
        {
        }

        [HttpPost]
        [Route("api/sync/questionaire")]
        public HttpResponseMessage Post(Questionaire questionaire)
        {
            try
            {
                var provider = new SyncProvider(DbInfo);
                var synched = false;
                synched = provider.SyncQuestionaire(questionaire);
                return Request.CreateResponse(HttpStatusCode.OK, synched);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/sync/inspection")]
        public HttpResponseMessage Post(FieldInspection inspection)
        {
            try
            {
                var provider = new SyncProvider(DbInfo);
                var synched = provider.SyncFieldInspection(inspection);
                return Request.CreateResponse(HttpStatusCode.OK, synched);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/sync/certification")]
        public HttpResponseMessage Post(Certification certification)
        {
            try
            {
                var provider = new SyncProvider(DbInfo);
                var synched = false;
                synched = provider.SyncCertification(certification);
                return Request.CreateResponse(HttpStatusCode.OK, synched);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/sync/training")]
        public HttpResponseMessage Post(Training training)
        {
            try
            {
                var provider = new SyncProvider(DbInfo);
                var synched = provider.SyncTraining(training);
                return Request.CreateResponse(HttpStatusCode.OK, synched);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/sync/certification")]
        public HttpResponseMessage Post(Purchase purchase)
        {
            try
            {
                var provider = new SyncProvider(DbInfo);
                var synched = provider.SyncPurchase(purchase);
                return Request.CreateResponse(HttpStatusCode.OK, synched);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.Message);
            }
        }
    }
}
