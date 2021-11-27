using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces;
using Services.Interfaces;

namespace Services.Services
{
    public class TxtLoggerService : ILoggerService
    {
        private readonly ILoggerRepository _loggerRepository;

        public TxtLoggerService(ILoggerRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }

        public void WriteLog(string message)
        {
            _loggerRepository.WriteLog(message);
        }
    }
}