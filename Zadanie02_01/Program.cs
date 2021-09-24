using System;

namespace Zadanie02_01
{
    class Program
    {
        // Trójka pitagorejska
        static void Main(string[] args)
        {
            Console.Write("Podaj liczbę A: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Podaj liczbę B: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Podaj liczbę C: ");
            int c = int.Parse(Console.ReadLine());
            if((a*a + b*b == c*c) || (a*a == b*b + c*c) || (b*b == a*a + c*c) )
            {
                Console.WriteLine($"Podane liczby: a = {a}, b = {b}, c = {c} tworzą trójke pitagorejską");
            }
            else
            {
                Console.WriteLine("Podane liczby nie tworzą trójki pitagorejskiej");
            }
        }
    }
}
