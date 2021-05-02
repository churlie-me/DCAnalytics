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
    public class PurchaseController : BaseApiController
    {
        public PurchaseController() : base()
        {

        }

        [HttpGet]
        // GET: api/configuration/id
        [Route("api/purchase/{Id}")]
        public HttpResponseMessage Get(string id)
        {
            var certification = new PurchaseProvider(DbInfo).GetPurchase(int.Parse(id));
            var exists = certification != null;
            var status = exists ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return Request.CreateResponse(status, certification);
        }

        [HttpGet]
        // GET: api/configuration/id
        [Route("api/purchase/configuration/{Id}")]
        public HttpResponseMessage GetPurchase(string id)
        {
            try
            {
                var purchases = new PurchaseProvider(DbInfo).GetPurchases(int.Parse(id));
                return Request.CreateResponse(HttpStatusCode.OK, purchases);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/purchase/reports/{response_id}")]
        public HttpResponseMessage GetReports(string response_id)
        {
            try
            {
                var reports = new PurchaseProvider(DbInfo).GetReports(response_id);
                return Request.CreateResponse(HttpStatusCode.OK, reports);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        // POST: api/Inspection
        public HttpResponseMessage Post(Purchase purchase)
        {
            try
            {
                var provider = new PurchaseProvider(DbInfo);
                var isSaved = provider.Save(purchase);
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
        public HttpResponseMessage Delete(int id)
        {
            var provider = new PurchaseProvider(DbInfo);
            var deleted = provider.DeletePurchase(id);
            return Request.CreateResponse(HttpStatusCode.OK, deleted);
        }

    }
}
