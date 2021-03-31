using System;

namespace ConsoleApp3_typy_referencyjne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Typy referencyjne to: tablice, klasy, ciągi.");
            Console.WriteLine("Zmienne typu wartości są przechowywane na stosie,\na zmienne typu referencyjnego na stercie\n");
            int[] data = new int[3];

            string shortenedString = "Hello World!";
            Console.WriteLine(shortenedString);

        }
    }
}
