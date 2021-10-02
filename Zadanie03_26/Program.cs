using System;

namespace Zadanie03_26
{
    class Program
    {
        static void Main(string[] args)
        {
            int j = 0;

            for (int i = 100000; i < 1000000; i++)
            {
                int firstTwo = i / 1000;
                int lastTwo = i % 1000;

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
