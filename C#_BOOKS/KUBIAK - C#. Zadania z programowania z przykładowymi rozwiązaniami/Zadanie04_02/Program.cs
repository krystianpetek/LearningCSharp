using System;

namespace Zadanie04_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int j = 10;
            int[] dane = new int[10];
            for (int i = 0; i < 10; i++)
            {
                j--;
                dane[i] = j;
            }
            foreach (var x in dane)
                Console.WriteLine($"dane[{dane[x]}] = {x}");
        }
    }
}
