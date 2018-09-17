using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeAPI.RepositoryLayer
{
    interface IUserRepository
    {
        bool Create(User user);
        List<User> GetAll();
    }
}
