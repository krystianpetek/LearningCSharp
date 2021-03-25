using System;

namespace ConsoleApp2_zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int wartoscSprzedazy = 1001;
            int znizka = wartoscSprzedazy > 1000 ? 100 : 50;
            Console.WriteLine($"Zniżka: {znizka}zł");

            Console.WriteLine($"Zniżka: {(wartoscSprzedazy = 900 > 1000 ? 100 : 50)}zł");

            Random losowanie = new Random();
            int szansa = losowanie.Next(0, 100);
            Console.WriteLine("Jeżeli wylosowane zostanie 0-50 to reszka, od 51 do 100 orzeł");
            Console.WriteLine($"Liczba: {szansa}: {(szansa>=50 ? "orzeł":"reszka")}");

            szansa = losowanie.Next(0, 2);
            Console.WriteLine($"Liczba: {szansa}: {(szansa == 0 ? "orzeł" : "reszka")}");
        }
    }
}
