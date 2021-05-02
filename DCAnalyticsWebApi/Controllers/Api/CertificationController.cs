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
    public class CertificationController : BaseApiController
    {    
        public CertificationController():base()
        {
            
        }

        [HttpGet]
        // GET: api/configuration/id
        [Route("api/certification/configuration/{Id}")]
        public HttpResponseMessage GetCertifications(string id)
        {
            try
            {
                var certifications = new CertificationProvider(DbInfo).GetCertifications(int.Parse(id));
                return Request.CreateResponse(HttpStatusCode.OK, certifications);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.StackTrace);
            }
        }

        [HttpGet]
        // GET: api/configuration/id
        [Route("api/certification/overview/{Id}")]
        public HttpResponseMessage CertificationsOverview(string id)
        {
            try
            {
                var certifications = new CertificationProvider(DbInfo).CertificationsOverview(int.Parse(id));
                return Request.CreateResponse(HttpStatusCode.OK, certifications);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/certification/reports/{respons_id}")]
        public HttpResponseMessage GetReports(string respons_id)
        {
            try
            {
                var reports = new CertificationProvider(DbInfo).GetReports(respons_id);
                return Request.CreateResponse(HttpStatusCode.OK, reports);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.StackTrace);
            }
        }

        [HttpGet]
        // GET: api/configuration/id
        [Route("api/Certification/{Id}")]
        public HttpResponseMessage Get(string id)
        {
            var certification = new CertificationProvider(DbInfo).GetCertification(int.Parse(id));
            var exists = certification != null;
            var status = exists ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return Request.CreateResponse(status, certification);
        }

        [HttpPost]
        public HttpResponseMessage Post(Certification certification)
        {
            try
            {
                var provider = new CertificationProvider(DbInfo);
                var _save = provider.Save(certification);
                return Request.CreateResponse(HttpStatusCode.OK, _save);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Certification/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Configuration/5
        public HttpResponseMessage Delete(int id)
        {
            var provider = new CertificationProvider(DbInfo);
            var deleted = provider.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, deleted);
        }
    }
}
