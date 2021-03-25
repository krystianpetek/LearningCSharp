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
        }
        static void program()
        {

        }
    }
}
