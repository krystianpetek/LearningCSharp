using System;

namespace Zadanie03_23
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program wyświetla duże litery alfabetu od A do Z i spowrotem");
            int i = 'A';
            do
            {
                if ((char)i == 'Z')
                    Console.Write($"{(char)i}.");
                else
                {
                    Console.Write($"{(char)i}, ");
                }
                i++;
            } while (i <= 'Z');
            Console.WriteLine();
            i = 'Z';
            do
            {
                if ((char)i == 'A')
                    Console.Write($"{(char)i}.");
                else
                {
                    Console.Write($"{(char)i}, ");
                }
                i--;
            }while (i >= 'A');
        }
    }
}
