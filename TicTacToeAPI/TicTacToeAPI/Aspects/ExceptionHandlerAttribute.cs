using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TicTacToeAPI.BusinessLayer;
using TicTacToeAPI.Entities;

namespace TicTacToeAPI.Aspects
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        Log log;
        public override void OnException(ExceptionContext context)
        {
            
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = context.Exception.Message;
            this.log = new Log();
            log.Request =  context.HttpContext.Request.Method + ":" + context.HttpContext.Request.Path;
            log.Response = "Failure";
            log.Exception = context.Exception.Message;
            log.Comment = message;
            LogService.GetLogger().LogAction(log);
            context.HttpContext.Response.StatusCode = (int)status;
            context.Result = new JsonResult(message);
            base.OnException(context);
        }
    }
}
