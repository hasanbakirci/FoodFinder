using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces;

namespace Data.Repository
{
    public class TxtLoggerRepository : ILoggerRepository
    {
        public void WriteLog(string message)
        {
            using (StreamWriter writer = File.AppendText("../log.txt"))
            {
                writer.WriteLine(message);
            }
        }
    }
}