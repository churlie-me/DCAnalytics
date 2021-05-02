using DCAnalytics.Data.Providers;
using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Google.Apis.Translate.v3;
using Google.Cloud.Translation.V2;

namespace DCAnalyticsWebApi.Controllers.Api
{
    public class BillingController : BaseApiController
    {
        public BillingController():base()
        {
            
        }

     
        [HttpGet]
        [Route("api/billing/client/{id}")]
        public HttpResponseMessage Get(string id)
        {
            try
            {
               
                var bills = new BillingProvider(DbInfo).RetrieveClientBills(id);
                return Request.CreateResponse(HttpStatusCode.OK, bills);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.StackTrace);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var bills = new BillingProvider(DbInfo).RetrieveBills();
                return Request.CreateResponse(HttpStatusCode.OK, bills);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.StackTrace);
            }
        }

        [HttpPost]
        // POST: api/Billing
        public HttpResponseMessage Post(Billing billing)
        {
            try
            {
                var provider = new BillingProvider(DbInfo);
                var isSaved = provider.Save(billing);
                return Request.CreateResponse(HttpStatusCode.OK, isSaved);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
