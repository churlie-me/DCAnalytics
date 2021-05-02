using DCAnalytics.Data.Providers;
using DCAnalytics;
using DCAnalytics.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DCAnalyticsWebApi.Controllers.Api
{
    public class PackageController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var provider = new PackageProvider(DbInfo);
                return Request.CreateResponse(HttpStatusCode.OK, provider.RetrievePackages());
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post(Package package)
        {
            try
            {
                var provider = new PackageProvider(DbInfo);
                var isSaved = provider.Save(package);
                return Request.CreateResponse(HttpStatusCode.OK, isSaved);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
