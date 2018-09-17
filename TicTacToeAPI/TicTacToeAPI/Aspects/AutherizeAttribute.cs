using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TicTacToeAPI.BusinessLayer;
using System.Web.Http;

namespace TicTacToeAPI.Aspects
{
    public class AutherizeAttribute : ResultFilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        
        }
        [ExceptionHandler]
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string accessToken = context.HttpContext.Request.Headers["AccessToken"].ToString();
            if (!AutherizeService.Autherize(accessToken))
            {
                var response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(string.Format("Unautherized Access")),
                    ReasonPhrase = "Invalid Access Token" 
                };
                throw new UnauthorizedAccessException();
            }
        }
    }
}
