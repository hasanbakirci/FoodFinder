using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces;
using Services.Interfaces;

namespace Services.Services
{
    public class ConsoleLoggerService : ILoggerService
    {
        public void WriteLog(string message)
        {
            Console.WriteLine("[CONSOLE_LOGGER] : "+message);
        }
    }
}