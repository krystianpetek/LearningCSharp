using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegaty
{
    internal class Program
    {
        static FileStream fs;
        static StreamWriter sw;
        public delegate void PrintMessage(string s);

        public static void WriteToConsole(string s)
        {
            Console.WriteLine($"Wiadomość: {s}");
        }

        public static void WriteToFile(string s)
        {
            using (fs = File.Open("d:\\wiadomosc.txt", FileMode.Append, FileAccess.Write))
            {
                using(sw = new StreamWriter(fs))
                {
                    sw.WriteLine(s);
                    sw.Flush();
                    sw.Close();
                }
                fs.Close();
            }
        }

        public static void SendString(PrintMessage pm)
        {
            pm("Witaj świecie");
        }

        static void Main(string[] args)
        {
            PrintMessage pm1 = new PrintMessage(WriteToConsole);
            PrintMessage pm2 = new PrintMessage(WriteToFile);
            SendString(pm1);
            SendString(pm2);

            Console.ReadKey();
        }
    }
}
