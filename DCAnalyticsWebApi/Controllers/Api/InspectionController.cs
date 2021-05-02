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
    public class InspectionController : BaseApiController
    {
        public InspectionController() : base()
        {

        }

        [HttpGet]
        // GET: api/configuration/id
        [Route("api/Inspection/{Id}")]
        public HttpResponseMessage Get(string id)
        {
            var certification = new FieldInspectionProvider(DbInfo).GetInspection(int.Parse(id));
            var exists = certification != null;
            var status = exists ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return Request.CreateResponse(status, certification);
        }

        [HttpGet]
        [Route("api/Inspection/configuration/{Id}")]
        public HttpResponseMessage GetCertifications(string id)
        {
            try
            {
                var inspections = new FieldInspectionProvider(DbInfo).GetFieldInspections(int.Parse(id));
                return Request.CreateResponse(HttpStatusCode.OK, inspections);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/inspection/reports/{respons_id}")]
        public HttpResponseMessage GetReports(string respons_id)
        {
            try
            {
                var reports = new FieldInspectionProvider(DbInfo).GetReports(respons_id);
                return Request.CreateResponse(HttpStatusCode.OK, reports);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/inspection/overview/{Id}")]
        public HttpResponseMessage CertificationsOverview(string id)
        {
            try
            {
                var inspections = new FieldInspectionProvider(DbInfo).CertificationsOverview(int.Parse(id));
                return Request.CreateResponse(HttpStatusCode.OK, inspections);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post(FieldInspection inspection)
        {
            try
            {
                var provider = new FieldInspectionProvider(DbInfo);
                var isSaved = provider.Save(inspection);
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
            var provider = new FieldInspectionProvider(DbInfo);
            var deleted = provider.DeleteFieldInspection(id);
            return Request.CreateResponse(HttpStatusCode.OK, deleted);
        }
    }
}