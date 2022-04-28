using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibility
{
    internal class ErrorLogger
    {
        public int ID { get; set; }
        public string PathToLogFile { get; set; }
        public string ExceptionMessage { get; set; }
        public void WriteToErrorLog(string path, string message)
        {
            File.WriteAllText(path, message);
        }
    }
}
