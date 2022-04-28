using System;
using System.IO;

namespace Delegaty
{
    internal class Program
    {
        private static FileStream fs;
        private static StreamWriter sw;

        public delegate void PrintMessage(string s);

        public static void WriteToConsole(string s)
        {
            Console.WriteLine($"Wiadomość: {s}");
        }

        public static void WriteToFile(string s)
        {
            using (fs = File.Open("d:\\wiadomosc.txt", FileMode.Append, FileAccess.Write))
            {
                using (sw = new StreamWriter(fs))
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

        private static void Main(string[] args)
        {
            PrintMessage pm1 = new PrintMessage(WriteToConsole);
            PrintMessage pm2 = new PrintMessage(WriteToFile);
            SendString(pm1);
            SendString(pm2);

            Console.ReadKey();
        }
    }
}