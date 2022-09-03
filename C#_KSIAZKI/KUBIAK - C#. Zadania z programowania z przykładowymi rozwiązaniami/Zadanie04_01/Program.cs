using System;

namespace Zadanie04_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dane = new int[10];
            for (int i = 0; i < 10; i++)
            {
                dane[i] = i;
            }
            foreach (var x in dane)
                Console.WriteLine($"dane[{dane[x]}] = {x}");
        }
    }
}
