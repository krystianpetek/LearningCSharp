using System;

namespace Zadanie03_25
{
    class Program
    {
        static void Main(string[] args)
        {
            int j = 0;

            for (int i = 1000; i < 10000; i++)
            {
                int firstTwo = i / 100;
                int lastTwo = i % 100;

                if (firstTwo * firstTwo + lastTwo * lastTwo == i)
                {
                    Console.WriteLine($"{i} = {firstTwo} * {firstTwo} + {lastTwo} * {lastTwo}");
                    j++;
                }

            }
            Console.WriteLine();
            Console.WriteLine("Znaleziono " + j + " liczby.");
        }
    }
}
