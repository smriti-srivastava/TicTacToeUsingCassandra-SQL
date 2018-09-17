using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeAPI.Entities
{
    public class Log
    {
        public int LogId { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string Exception { get; set; }
        public string Comment { get; set; }
    }
}
