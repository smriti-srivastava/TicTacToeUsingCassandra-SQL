using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeAPI.Entities;

namespace TicTacToeAPI.RepositoryLayer
{
    public class CassandraLogRepository : ILogRepository
    {
        private Cluster cluster;
        private ISession session;
        private void Session()
        {
            cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            session = cluster.Connect("tictactoe");
        }
        public bool Create(Log log)
        {
            Session();
            if (session.Execute(String.Format("INSERT INTO Log(logid, request, response, exception) VALUES(now(), '{0}', '{1}', '{2}')", log.Request, log.Response, log.Exception)) != null) return true;
            else return false;
        }
    }
}
