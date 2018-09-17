using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TicTacToeAPI.RepositoryLayer;

namespace TicTacToeAPI.BusinessLayer
{
    public class UserService
    {
        IUserRepository repository;
        public UserService()
        {
            repository = new CassandraUserRepository();
        }
        public string RegisterUser(User user)
        {
            user.AccessToken = AccessTokenGenerator.GenerateToken(user.EmailId);
            if (repository.Create(user))
            {
                return user.AccessToken;
            }
            return null;
        }
    }
}
