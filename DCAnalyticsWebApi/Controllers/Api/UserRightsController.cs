using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DCAnalyticsWebApi.Controllers.Api
{
    public class UserRightsController : BaseApiController
    {
        public UserRightsController() : base()
        {

        }
      
        // POST: api/UserRights
        public HttpResponseMessage Post(Configuration configuration)
        {
            configuration.InitUserRights();
            return Request.CreateResponse(HttpStatusCode.OK, configuration);
        }

      
    }
}
