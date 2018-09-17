using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTacToeAPI.Aspects;
using TicTacToeAPI.BusinessLayer;
using TicTacToeAPI.RepositoryLayer;

namespace TicTacToeAPI.Controllers
{
    [Produces("application/json")]
    [Route("TicTacToe")]
    public class IdentityController : Controller
    {
        [Log]
        [HttpPost]
        [ExceptionHandler]
        [Route("Register")]
        public string CreateUser([FromBody]User user)
        {
            UserService service = new UserService();
            return service.RegisterUser(user);
        }
    }
}