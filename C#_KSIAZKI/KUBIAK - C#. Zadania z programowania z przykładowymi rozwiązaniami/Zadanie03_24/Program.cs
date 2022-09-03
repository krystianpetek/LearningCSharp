using System;

namespace Zadanie03_24
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program wyświetla duże litery alfabetu od A do Z i spowrotem");
            int i = 'A';
            while (i <= 'Z')
            {
                if ((char)i == 'Z')
                    Console.Write($"{(char)i}.");
                else
                {
                    Console.Write($"{(char)i}, ");
                }
                i++;
            };
            Console.WriteLine();
            i = 'Z';
            while (i >= 'A')
            {
                if ((char)i == 'A')
                    Console.Write($"{(char)i}.");
                else
                {
                    Console.Write($"{(char)i}, ");
                }
                i--;
            };
        }
    }
}
