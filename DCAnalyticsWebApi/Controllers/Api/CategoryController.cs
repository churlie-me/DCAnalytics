using DCAnalytics.Data;
using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DCAnalyticsWebApi.Controllers.Api
{
    public class CategoryController : BaseApiController
    {
        public CategoryController():base()
        {

        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var categories = new CategoryProvider(DbInfo).RetrieveCategories();
                return Request.CreateResponse(HttpStatusCode.OK, categories);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/Category/Templates")]
        public HttpResponseMessage GetTemplateCategories()
        {
            try
            {
                var categories = new CategoryProvider(DbInfo).RetrieveTemplateCategories();
                return Request.CreateResponse(HttpStatusCode.OK, categories);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.StackTrace);
            }
        }

        [HttpPost]
        // POST: api/Category
        public HttpResponseMessage Post(Category category)
        {
            try
            {
                var provider = new CategoryProvider(DbInfo);
                var isSaved = provider.Save(category);
                return Request.CreateResponse(HttpStatusCode.OK, isSaved);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
