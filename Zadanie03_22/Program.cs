using System;

namespace Zadanie03_22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program wyświetla duże litery alfabetu od A do Z i spowrotem");
            for (int i = 'A'; i <= 'Z'; i++)
                Console.Write($"{(char)i}. ");
            Console.WriteLine();
            for (int i = 'Z'; i >= 'A'; i--)
                Console.Write($"{(char)i}. ");
        }
    }
}
