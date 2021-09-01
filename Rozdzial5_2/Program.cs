using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace Rozdzial5_2
{
    class Program
    {
        static int Main(string[] args)
        {
            int result;
            switch(args.Length)
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
            return result;
        }
    }
}
