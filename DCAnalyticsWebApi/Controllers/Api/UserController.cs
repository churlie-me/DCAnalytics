using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DCAnalytics.Data;
using System.Configuration;
using DCAnalytics;
using Microsoft.AspNetCore.Cors;
using DCAnalytics.Data.Services;

namespace DCAnalyticsWebApi.Controllers.Api
{
    [AllowAnonymous]
    public class UserController : BaseApiController
    {

        private dloDbInfo _dbInfo;

        public UserController()
        {
            Init();
        }

        private void Init()
        {
            _dbInfo = new DCAnalytics.Data.dloDbInfo();
            _dbInfo.ConnectionString = ConfigurationManager.ConnectionStrings["DCAnalyticsConnectionString"].ConnectionString;
        }

        [HttpGet]
        // GET: api/User
        public HttpResponseMessage Get(int id)
        {
            var user = new UserProvider(_dbInfo).GetUser(id);
            var exists = user != null;
            var status = exists ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return Request.CreateResponse(status, user);
        }

        [HttpGet]
        [Route("api/user/configuration/{Id}")]
        // GET: api/User
        public HttpResponseMessage GetConfigurationUsers(int Id)
        {
            var user = new UserProvider(_dbInfo).ConfigurationUsers(Id);
            var exists = user != null;
            var status = exists ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return Request.CreateResponse(status, user);
        }

        [HttpPost]
        [Route("api/user/configuration/")]
        public HttpResponseMessage AddConfigurationUser(User user)
        {
            try
            {
                bool added = new UserProvider(_dbInfo).AddConfigurationUser(user);
                return Request.CreateResponse(HttpStatusCode.OK, added);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/user/admin")]
        public HttpResponseMessage SuperAdmins()
        {
            try
            {
                var users = new UserProvider(_dbInfo).GetSuperAdmins();
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: api/User
        [HttpGet]
        [Route("api/user/client/{Id}")]
        public HttpResponseMessage GetUserByClient(int Id)
        {
            var users = new UserProvider(_dbInfo).ClientUsers(Id);
            var exists = users != null;
            var status = exists ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return Request.CreateResponse(status, users);
        }

        [HttpPost]
        [Route("api/user/client")]
        public HttpResponseMessage ClientUser(User user)
        {
            try
            {
                bool added = new UserProvider(_dbInfo).AddOrUpdateUser(user);
                return Request.CreateResponse(HttpStatusCode.OK, added);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.StackTrace);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post(User user)
        {
            try
            {
                bool added = new UserProvider(_dbInfo).AddOrUpdateUser(user);
                return Request.CreateResponse(HttpStatusCode.OK, added);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.StackTrace);
            }
        }

        [HttpPost]
        [Route("api/user/authentication")]
        public HttpResponseMessage Authentication(Credentials credentials)
        {
            try
            {
                User authorized = new UserProvider(_dbInfo).AuthoriseUser(credentials);
                return Request.CreateResponse(HttpStatusCode.OK, authorized);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.StackTrace);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var provider = new UserProvider(_dbInfo);
            var deleted = provider.DeleteUser(id);
            return Request.CreateResponse(HttpStatusCode.OK, deleted);
        }

        [HttpPost]
        [Route("api/user/configuration/delete")]
        public HttpResponseMessage DeleteConfigurationUser(User user)
        {
            var provider = new UserProvider(_dbInfo);
            var deleted = provider.DeleteConfigurationUser(user);
            return Request.CreateResponse(HttpStatusCode.OK, deleted);
        }

        [HttpPost]
        [Route("api/user/verify")]
        public HttpResponseMessage VerifyUser(User _user)
        {
            try
            {
                _user = new UserProvider(_dbInfo).VerifyUser(_user);
                return Request.CreateResponse(HttpStatusCode.OK, _user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.StackTrace);
            }
        }

        [HttpPost]
        [Route("api/user/password/reset")]
        public HttpResponseMessage ResetPassword(User _user)
        {
            try
            {
                var isPasswordChanged = new UserProvider(_dbInfo).ResetPassword(_user);
                if (isPasswordChanged)
                {
                    var innerHtml     = "   <h5> Hello DCAnalytics User,</h5>"
                                      + "   <p>" + "Your password has been succefully changed" + "</p>"
                                      + "   <h5 style='margin-top: 85px;'> Best Regards,</h5>"
                                      + "   <span> DCAnalytics Team </span>";
                    MailService.SendMail(_user.Email, true, "DCAnalytics Password Changed", innerHtml);
                    return Request.CreateResponse(HttpStatusCode.OK, isPasswordChanged);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.OK, isPasswordChanged);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, false);
            }
        }

        [HttpPost]
        [Route("api/user/password/forgot")]
        public HttpResponseMessage ForgotPassword(User _user)
        {
            try
            {
                User user = new UserProvider(_dbInfo).GetUser(_user.Email);
                if (user != null)
                {
                    var innerHtml     = "   <h5> Hello DCAnalytics User,</h5>"
                                      + "   <p>" + "We have received a request to the password to your DCAnalytics Account (" + user.Email + "). <br> Your verification code is : <strong>" + user.Usercode + "</strong> </p>"
                                      + "   <h5 style='margin-top: 85px;'> Best Regards,</h5>"
                                      + "   <span> DCAnalytics Team </span>";
                    MailService.SendMail(_user.Email, true, "DCAnalytics Verification Code", innerHtml);
                    new UserProvider(_dbInfo).AddOrUpdateUser(user);
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.OK, false);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, false);
            }
        }
    }
}
