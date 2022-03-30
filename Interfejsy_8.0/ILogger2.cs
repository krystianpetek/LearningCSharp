using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy_8._0
{
    internal interface ILogger2
    {
        abstract void Write(string message);
        virtual void Info(string message)
        {
            Write("info: " + clean(message));
            count++;
        }
        virtual void Error(string message)
        {
            Write("error: " + clean(message));
            count++;
        }
        virtual void Warn(string message)
        {
            Write("warning: " + clean(message));
            count++;
        }
        private string clean(string message)
        {
            message.Trim();
            return $"{DateTime.Now}: {message}";
        }
        public const string version = "0.1.1";
        private static int count;
        public static int CountMessages => count;

    }
}
