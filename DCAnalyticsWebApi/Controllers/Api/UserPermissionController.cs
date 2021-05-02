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
    public class UserPermissionController : BaseApiController
    {
        public UserPermissionController():base()
        {

        }

        // POST: api/UserPermission
        public HttpResponseMessage Post(UserPermissions userPermissions)
        {          
            UserPermissionProvider provider = new UserPermissionProvider(DbInfo);
            foreach (var userPermission in userPermissions)
            {
                provider.Save(userPermission);
            }
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

    }
}
