using System;

namespace Zadanie02_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Random losuj = new Random();
            int los = losuj.Next(0, 10);
            Console.WriteLine("Wylosowana liczba to : " + los);
            Console.WriteLine("Zgadnij liczbę od 0 do 9");
            int zgaduj = int.Parse(Console.ReadLine());
            while (zgaduj != los)
            {
                Console.WriteLine("Podaj liczbę jeszcze raz");
                zgaduj = int.Parse(Console.ReadLine());

            }
            Console.WriteLine("Wygrana!");

        }
    }
}
