using System;

namespace Zadanie04_08
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = new int[10, 10];
            int[,] b = new int[10, 10];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = j;
                }
            }
            for (int m = 0; m < b.GetLength(0); m++)
            {
                for (int n = 0; n < b.GetLength(1); n++)
                {
                    b[m, n] = a[n, m];
                }
            }
            // WYSWIETLENIE
            int A = 0;
            Console.WriteLine("Wyświetlenie zawartości tablicy A");
            while (A < a.GetLength(0))
            {
                int B = 0;
                while (B < a.GetLength(1))
                {
                    Console.Write(a[A, B]);
                    B++;
                }
                Console.WriteLine();
                A++;
            }
            int C = 0;
            Console.WriteLine("\nWyświetlenie zawartości tablicy B");
            while (C < b.GetLength(0))
            {
                int D = 0;
                while (D < b.GetLength(1))
                {
                    Console.Write(b[C, D]);
                    D++;
                }
                Console.WriteLine();
                C++;
            }
        }
    }
}
