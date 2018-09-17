using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeAPI.RepositoryLayer
{
    public class CassandraUserRepository : IUserRepository
    {
        private Cluster cluster;
        private ISession session;
        private void Session()
        {
            cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            session = cluster.Connect("tictactoe");
        }
        public bool Create(User user)
        {
            Session();
            if (session.Execute(String.Format("INSERT INTO player(userid, email, name, password, accesstoken) VALUES(now(), '{0}', '{1}', '{2}', '{3}')", user.EmailId, user.Name, user.Password, user.AccessToken)) != null) return true;
            else return false;
        }

        public List<User> GetAll()
        {
            Session();
            List<User> users = new List<User>();
            RowSet result = session.Execute("SELECT * FROM player");
            foreach(Row row in result)
            {
                users.Add(
                    new User()
                    {
                        Name = Convert.ToString(row["name"]),
                        EmailId = Convert.ToString(row["email"]),
                        Password = Convert.ToString(row["password"]),
                        AccessToken = Convert.ToString(row["accesstoken"])
                    }
                );
            }
            return users;
        }
    }
}
