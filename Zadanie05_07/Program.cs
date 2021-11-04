using System;

namespace Zadanie05_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj n: ");
            int.TryParse(Console.ReadLine(), out int n);
            Fibonacci fibo = new Fibonacci();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine( fibo.Ciag(i) );
            }
        }
    }
    class Fibonacci
    {
        public int Ciag(int n)
        {
            if (n > 1)
            {
                return Ciag(n - 2) + Ciag(n - 1);
            }
            else if (n == 1)
                return 1;
            else
                return 0;
        }
    }
}
