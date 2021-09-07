using System;
using System.IO;

namespace Rozdzial5_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // TABLICE PARAMETRÓW - params
            string fullName;
            fullName = Combine(Directory.GetCurrentDirectory(), "bin", "config", "index.html");
            Console.WriteLine(fullName);
            fullName = Combine(Environment.SystemDirectory, "temp", "index.html");
            Console.WriteLine(fullName);
            fullName = Combine(new string[] { "C:\\", "Data", "HomeDir", "index.html" });
            Console.WriteLine(fullName);

            static string Combine(params string[] paths)
            {
                string result = string.Empty;
                foreach(string path in paths)
                {
                    result = Path.Combine(result, path);
                }
                return result;
            }

        }


    }
}
