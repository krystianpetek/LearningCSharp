using System;

namespace Zadanie01_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program wyświetla stałą PI z dokładnością do 5 cyfr po przecinku: {0}", Math.Round(Math.PI, 5));
            Console.WriteLine("{0:#.#####}", Math.PI); // STARY SPOSOB
        }
    }
}
