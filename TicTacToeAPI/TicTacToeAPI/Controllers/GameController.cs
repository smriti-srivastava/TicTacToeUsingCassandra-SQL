using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTacToeAPI.Aspects;
using TicTacToeAPI.BusinessLayer;

namespace TicTacToeAPI.Controllers
{
    [Produces("application/json")]
    [Route("TicTacToe")]
    public class GameController : Controller
    {
    
        
        [HttpPut]
        [Log]
        [Autherize]
        [ExceptionHandler]
        [Route("Move")]
        public void Move([FromBody]int boxId)
        {
            Game.Move(boxId, String.Format(HttpContext.Request.Headers["AccessToken"]));
        }

        [HttpGet]
        [Log]
        [Route("Status")]
        [ExceptionHandler]
        [Autherize]
        public string GetStatus()
        {
            return Game.gameStatus;
        }
    }
}