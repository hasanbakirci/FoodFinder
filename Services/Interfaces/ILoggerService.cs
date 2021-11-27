using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILoggerService
    {
        void WriteLog(string message);
    }
}