using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DCAnalytics.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace DCAnalyticsWebApi.Controllers.Api
{
    public class ConfigurationController : BaseApiController
    {
        [HttpGet]
        // GET: api/configuration/id
        [Route("api/Configuration/{Id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var config = new ConfigurationProvider(DbInfo).GetConfiguration(id);
                var exists = config != null;
                var status = exists ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
                return Request.CreateResponse(status, config);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.StackTrace);
            }
        }

        // GET: api/User
        [HttpGet]
        [Route("api/Configuration/Client/{Id}")]
        public HttpResponseMessage ClientConfigurations(int Id)
        {
            var configuration = new ConfigurationProvider(DbInfo).ClientConfigurations(Id);
            var exists = configuration != null;
            var status = exists ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return Request.CreateResponse(status, configuration);
        }

        [HttpGet]
        [Route("api/Configuration/Client/Mobile/{Id}")]
        public HttpResponseMessage ClientMobileConfigurations(int Id)
        {
            var configuration = new ConfigurationProvider(DbInfo).ClientMobileConfigurations(Id);
            var exists = configuration != null;
            var status = exists ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return Request.CreateResponse(status, configuration);
        }

        [HttpPost]
        [Route("api/Configuration")]
        // POST: api/Configuration
        public HttpResponseMessage Post(Configuration configuration)
        {
            try
            {
                var provider = new ConfigurationProvider(DbInfo);
                var _save =  provider.Save(configuration);

                if(_save)
                    return Request.CreateResponse(provider.GetConfiguration(configuration.Key));

                return Request.CreateResponse(HttpStatusCode.OK, _save);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        public void ImportConfiguration(string config)
        {
            
        }

        public void SaveConfiguration()
        {

        }

        [HttpPut]
        [Route("api/Configuration")]
        // PUT: api/Configuration/5
        public void Put(Configuration configuration)
        {
        }

        [HttpDelete]
        // DELETE: api/Configuration/5
        [Route("api/configuration/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var provider = new ConfigurationProvider(DbInfo);
            var deleted = provider.DeleteConfiguration(id);
            return Request.CreateResponse(HttpStatusCode.OK, deleted);
        }

    }
}
