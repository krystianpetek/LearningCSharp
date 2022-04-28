using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    internal class Program
    {
        public static void Main()
        {
            SMSSender sms = new SMSSender();
            EmailSender emailSender = new EmailSender();
            LogToFile log = new LogToFile(emailSender);
            log.Notify("s");
        }

    }
}
