using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DCAnalytics.Data;
using System.Web.Http.Results;

namespace DCAnalyticsWebApi.Controllers.Api
{
    public class ClientsController : ApiController
    {
        private dloDbInfo _dbInfo;
        public ClientsController()
        {
            InitDb();
        }

        private void InitDb()
        {
            _dbInfo = new dloDbInfo();
            _dbInfo.ConnectionString = ConfigurationManager.ConnectionStrings["DCAnalyticsConnectionString"].ConnectionString;     
        }

        [HttpGet]
        [Route("api/Clients/{Id}")]
        public HttpResponseMessage Get(int Id)
        {
            try
            {
                var client = new ClientProvider(_dbInfo).GetClient(Id);
                var exists = client != null;
                var status = exists ? HttpStatusCode.OK : HttpStatusCode.NotFound;

                return Request.CreateResponse(status, client);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Clients")]
        public HttpResponseMessage Get()
        {
            try
            {
                var clients = new ClientProvider(_dbInfo).GetClients();
                return Request.CreateResponse(HttpStatusCode.OK, clients);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Clients")]
        // POST: api/Client
        public HttpResponseMessage Post(Client client)
        {
            bool saved = false;
            try
            {
                saved = new ClientProvider(_dbInfo).Save(client);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, saved);
        }

        [HttpPost]
        [Route("api/Clients/Update")]
        // POST: api/Client
        public HttpResponseMessage Update(Client client)
        {
            bool saved = false;
            try
            {
                saved = new ClientProvider(_dbInfo).Save(client);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, saved);
        }

        // DELETE: api/Configuration/5
        public HttpResponseMessage Delete(int id)
        {
            var provider = new ClientProvider(_dbInfo);
            var deleted = provider.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, deleted);
        }
    }
}
