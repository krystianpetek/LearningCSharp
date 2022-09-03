using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy_8._0
{
    internal interface ILoggerOLD
    {
        void Info(string message);
        void Error(string message);
        void Warn(string message) => Console.WriteLine("warn default: " + message);
    }
}
