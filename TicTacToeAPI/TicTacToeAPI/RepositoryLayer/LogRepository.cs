using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeAPI.Entities;

namespace TicTacToeAPI.RepositoryLayer
{
    public class LogRepository: ILogRepository
    {
        private string connectionString = string.Empty;
        private SqlConnection connection;

        public LogRepository()
        {
            this.connectionString = @"Data Source=TAVDESK149;Initial Catalog=TicTacToeDB;User Id=sa;Password=test123!@#";
        }

        private void Connection()
        {
            this.connection = new SqlConnection(this.connectionString);
        }
        public bool Create(Log log)
        {
            Connection();
            string query = "INSERT INTO Log(Request, Response, Exception) VALUES(@request, @response, @exception)";
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@request", log.Request);
            command.Parameters.AddWithValue("@response", log.Response);
            command.Parameters.AddWithValue("@exception", log.Exception);
            connection.Open();
            return command.ExecuteNonQuery() > 0 ? true : false;
        }
    }
}
