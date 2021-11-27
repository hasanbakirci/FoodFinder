using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ILoggerRepository
    {
        void WriteLog(string message);
    }
}