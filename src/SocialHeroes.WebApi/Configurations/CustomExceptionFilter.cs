using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Data.SqlClient;
using System.Net;

namespace SocialHeroes.WebApi.Configurations
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;            
            var contextException = context.Exception;
            object result = null;
            result = new { success = false, errors = contextException };
            var messageException = contextException.InnerException.InnerException != null ?
                                   contextException.InnerException.InnerException.Message : contextException.InnerException.Message;




            if (contextException.GetType() == typeof(UnauthorizedAccessException))
            {
                status = HttpStatusCode.Unauthorized;
                result = new
                {
                    success = false,
                    errors = messageException
                };
            }

            if (contextException.GetType() == typeof(NullReferenceException))
            {
                status = HttpStatusCode.NotFound;
                result = new
                {
                    success = false,
                    errors = messageException
                };
            }


            if (contextException.GetType() != typeof(NullReferenceException) && 
                contextException.GetType() != typeof(UnauthorizedAccessException))
            {

                result = new
                {
                    success = false,
                    errors = messageException
                };
            }
            
            HttpResponse response = context.HttpContext.Response;

            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            context.Result = new JsonResult(result);
        }
    }
}
