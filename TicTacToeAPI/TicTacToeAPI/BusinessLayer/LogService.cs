using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeAPI.Entities;
using TicTacToeAPI.RepositoryLayer;

namespace TicTacToeAPI.BusinessLayer
{
    public class LogService
    {
        private ILogRepository _repository;
        private static LogService _logger;
        private LogService()
        {
            _repository = new CassandraLogRepository();
            
        }

        public static LogService GetLogger()
        {
            if (_logger == null)
                _logger = new LogService();
            return _logger;
        }

        public bool LogAction(Log log)
        {
            return this._repository.Create(log);
        }
    }
}
