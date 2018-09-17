using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeAPI.BusinessLayer;
using TicTacToeAPI.Entities;

namespace TicTacToeAPI
{
    public class LogAttribute : ResultFilterAttribute, IActionFilter
    {
        Log log;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                this.log = new Log();
                log.Request = context.HttpContext.Request.Method + ":" + context.HttpContext.Request.Path;
                log.Response = "Success";
                log.Exception = "None";
                log.Comment = "Resquest Successful";
                LogService.GetLogger().LogAction(log);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           
        }
    }
}
