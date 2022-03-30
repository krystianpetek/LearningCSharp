using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy_8._0
{
    internal class NewConsoleLogger : OldConsoleLogger, ILoggerOLD
    {
        public void Warn(string message) => Console.WriteLine("warn: " + message);
    }
}
