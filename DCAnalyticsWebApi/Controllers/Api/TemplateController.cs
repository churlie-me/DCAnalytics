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
    public class TemplateController : BaseApiController
    {
        public TemplateController() : base()
        {

        }

        [HttpGet]
        [Route("api/Template/{id}")]
        public HttpResponseMessage Get(string id)
        {
            try
            {
                var template = new TemplateProvider(DbInfo).RetrieveTemplate(id);
                return Request.CreateResponse(HttpStatusCode.OK, template);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.StackTrace);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var templates = new TemplateProvider(DbInfo).RetrieveTemplates();
                return Request.CreateResponse(HttpStatusCode.OK, templates);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.StackTrace);
            }
        }

        [HttpPost]
        // POST: api/Billing
        public HttpResponseMessage Post(Template template)
        {
            try
            {
                var provider = new TemplateProvider(DbInfo);
                var isSaved = provider.Save(template);
                return Request.CreateResponse(HttpStatusCode.OK, isSaved);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
