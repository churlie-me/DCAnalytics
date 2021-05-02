using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DCAnalytics.Data;
using System.Configuration;

namespace DCAnalyticsWebApi.Controllers.Api
{
    public class QuestionaireController : BaseApiController
    {       
        public QuestionaireController()
        {
            
        }
    
        // POST: Questionaire/Create
        [HttpPost]
        public HttpResponseMessage Post(Questionaire questionaire)
        {
            try
            {
                QuestionaireProvider provider = new QuestionaireProvider(DbInfo);
                provider.Save(questionaire);
                return Request.CreateResponse(HttpStatusCode.OK, true);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/Questionaire/{Id}")]
        public HttpResponseMessage Get(int Id)
        {
            try
            {
                var _questionaire = new QuestionaireProvider(DbInfo).GetQuestionaire(Id);
                return Request.CreateResponse(HttpStatusCode.OK, _questionaire);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/questionaire/templates")]
        public HttpResponseMessage Templates()
        {
            try
            {
                var _questionaires = new QuestionaireProvider(DbInfo).GetQuestionaires(0);
                return Request.CreateResponse(HttpStatusCode.OK, _questionaires);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/Questionaire/Configuration/{Id}")]
        public HttpResponseMessage ConfigurationQuestionaires(int Id)
        {
            try
            {
                var _questionaires = new QuestionaireProvider(DbInfo).GetQuestionaires(Id);
                return Request.CreateResponse(HttpStatusCode.OK, _questionaires);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/questionaire/overview/{Id}")]
        public HttpResponseMessage ReviewQuestionaires(string Id)
        {
            try
            {
                var _questionaires = new QuestionaireProvider(DbInfo).GetReviewQuestionaires(Id);
                return Request.CreateResponse(HttpStatusCode.OK, _questionaires);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        // POST: Questionaire/Edit/5
        [HttpPost]
        public HttpResponseMessage Edit(string id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, true);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        // POST: Questionaire/Delete/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, true);

            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }
    }
}
