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
    public class EnumListController : BaseApiController
    {
        public EnumListController():base()
        {

        }

        [HttpGet]
        [Route("api/enumlist/prices/configuration/{Id}")]
        public HttpResponseMessage GetPrices(string id)
        {
            try
            {
                var enumList = new EnumListProvider(DbInfo).GetEnumList(int.Parse(id), EnumListTypes.Price);
                return Request.CreateResponse(HttpStatusCode.OK, enumList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/enumlist/regions/configuration/{Id}")]
        public HttpResponseMessage GetRegions(string id)
        {
            try
            {
                var enums = new EnumListProvider(DbInfo).GetEnumList(int.Parse(id), EnumListTypes.Region);
                return Request.CreateResponse(HttpStatusCode.OK, enums);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/enumlist/products/configuration/{Id}")]
        public HttpResponseMessage GetProducts(string id)
        {
            try
            {
                var enums = new EnumListProvider(DbInfo).GetEnumList(int.Parse(id), EnumListTypes.Product);
                return Request.CreateResponse(HttpStatusCode.OK, enums);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post(EnumList enumList)
        {
            try
            {
                var provider = new EnumListProvider(DbInfo);
                var isSaved = provider.Save(enumList);
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
        public HttpResponseMessage Delete(string id)
        {
            var provider = new EnumListProvider(DbInfo);
            var deleted = provider.DeleteEnumList(id);
            return Request.CreateResponse(HttpStatusCode.OK, deleted);
        }

    }
}
