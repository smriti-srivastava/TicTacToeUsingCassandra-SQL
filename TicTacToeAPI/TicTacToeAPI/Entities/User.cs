using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeAPI.RepositoryLayer
{
    public class User
    {
        public int UserId { set; get; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
    }
}
