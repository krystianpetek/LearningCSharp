using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy_8._0
{
    internal class ConsoleLogger1 : ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
        public void Warn(string message) => Console.WriteLine("debug warning: "+message);
    }
}
