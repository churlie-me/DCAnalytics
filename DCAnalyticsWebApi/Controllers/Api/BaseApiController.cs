using DCAnalytics.Data;
using DCAnalytics;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DCAnalyticsWebApi.Controllers.Api
{
    [EnableCors]
    public class BaseApiController : ApiController
    {
        public dloDbInfo DbInfo { get; set; }

        public BaseApiController()
        {
            Init();
        }

        private void Init()
        {
            DbInfo = new DCAnalytics.Data.dloDbInfo();
            DbInfo.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DCAnalyticsConnectionString"].ConnectionString;
        }

        protected HttpResponseMessage BuildSuccessResult(HttpStatusCode statusCode)
        {
            return this.Request.CreateResponse(statusCode);
        }

        protected HttpResponseMessage BuildSuccessResult(HttpStatusCode statusCode, object data)
        {
            return data != null ? this.Request.CreateResponse(statusCode, data) : this.Request.CreateResponse(statusCode);
        }

        protected HttpResponseMessage BuildErrorResult(HttpStatusCode statusCode, string errorCode = null, string message = null)
        {
            return this.Request.CreateResponse(statusCode, new Error()
            {
                ErrorCode = errorCode,
                Message = message
            });
        }
    }

    public class Error
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
