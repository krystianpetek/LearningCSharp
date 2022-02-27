using System;
using System.IO;
using System.Net;

namespace Rozdzial5_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int result;
            switch (args.Length)
            {
                default:
                    Console.WriteLine("BŁĄD: należy podać adres URL i nazwę pliku");
                    Console.WriteLine("Użytkowanie: Downloader.exe <URL> <nazwa_docelowa_pliku>");
                    result = 1;
                    break;

                case 2:
                    WebClient webclient = new WebClient();
                    webclient.DownloadFile(args[0], args[1]);
                    result = 0;
                    break;
            }
            //return result;
            // Environment.GetCommandLineArgs() == string[] args

            // PRZEKAZYWANIE ZMIENNYCH PRZEZ WARTOŚĆ
            string fullName;
            string driveLetter = "C:";
            string folderPath = "Data";
            string fileName = "index.html";
            fullName = Link(driveLetter, folderPath, fileName);
            Console.WriteLine(fullName);

            static string Link(string letter, string path, string name)
            {
                string exit;
                exit = string.Format("{1}{0}{2}{0}{3}", Path.DirectorySeparatorChar, letter, path, name);
                return exit;
            }

            // PRZEKAZYWANIE ZMIENNYCH PRZEZ REFERENCJE
            string first = "Witaj";
            string second = "Żegnaj";
            Console.WriteLine($@"first = ""{first}"", second = ""{second}""");
            Swap(ref first, ref second);
            Console.WriteLine($@"first = ""{first}"", second = ""{second}""");

            static void Swap(ref string first, ref string second)
            {
                string temp = first;
                first = second;
                second = temp;
            }
        }
    }
}