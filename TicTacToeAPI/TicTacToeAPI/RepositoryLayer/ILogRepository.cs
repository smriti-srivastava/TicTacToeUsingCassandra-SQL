using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeAPI.Entities;

namespace TicTacToeAPI.RepositoryLayer
{
    interface ILogRepository
    {
        bool Create(Log log);
    }
}
