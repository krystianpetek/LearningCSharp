using System;

namespace Zadanie03_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program wyświetla liczby całkowite od 1 do 20");
            for (int i = 0; i <= 20; i++)
            {
                if (i == 20)
                {
                    Console.Write($"{i}.");
                }
                else
                {
                    Console.Write($"{i}, ");
                }
            }
        }
    }
}
