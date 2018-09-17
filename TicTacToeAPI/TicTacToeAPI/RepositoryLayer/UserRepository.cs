using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeAPI.RepositoryLayer
{
    public class UserRepository:IUserRepository
    {
        private string connectionString = string.Empty;
        private SqlConnection connection;

        public UserRepository()
        {
            this.connectionString = @"Data Source=TAVDESK149;Initial Catalog=TicTacToeDB;User Id=sa;Password=test123!@#";
        }
        private void Connection()
        {
          
            this.connection = new SqlConnection(this.connectionString);

        }
        public bool Create(User user)
        {
            Connection();
            string query = String.Format("INSERT INTO Player(Email, Name, Password, AccessToken) VALUES(@email, @userName, @password, @accessToken)");
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@email", user.EmailId);
            command.Parameters.AddWithValue("@userName", user.Name);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@accessToken", user.AccessToken);
            connection.Open();
            bool result = command.ExecuteNonQuery() > 0 ? true : false;
            connection.Close();
            return result;
        }

        public User GetById(int Id)
        {
            Connection();
            User user = new User();
            string query = String.Format("SELECT * FROM Player WHERE Email={0}", Id);
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    user.EmailId = Convert.ToString(dataReader["Email"]);
                    user.Name = Convert.ToString(dataReader["Email"]);
                    user.Password = Convert.ToString(dataReader["Password"]);
                    user.AccessToken = Convert.ToString(dataReader["AccessToken"]);
                }
            }
            connection.Close();
            return user;
        }

        public List<User> GetAll()
        {
            Connection();
            List<User> userList = new List<User>();
            string query = String.Format("SELECT * FROM Player");
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    userList.Add(new User()
                    {
                        EmailId = Convert.ToString(dataReader["Email"]),
                        Name = Convert.ToString(dataReader["Email"]),
                        Password = Convert.ToString(dataReader["Password"]),
                        AccessToken = Convert.ToString(dataReader["AccessToken"])
                    });
                }
            }
            return userList;
        }
    }
}
