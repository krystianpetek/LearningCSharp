using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfejsy_8._0
{
    internal interface ILogger
    {
        void Write(string message); // obowiazek implementacji
        void Info(string message)
        {
            Write($"info: {clean(message)}");
            count++;
        }

        void Error(string message)
        {
            Write($"error: {clean(message)}");
            count++;
        }

        void Warn(string message)
        {
            Write($"warning: {clean(message)}");
            count++;
        }

        private string clean(string message)
        {
            message.Trim();
            return DateTime.Now + ": " + message;
        }
        public const string version = "0.1.1";
        private static int count = 0;
        public static int CountMessage => count;
    }
}