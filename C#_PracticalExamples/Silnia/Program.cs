using System;

namespace Silnia
{
    class Program
    {
        public static int Factorial(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * Factorial(n - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(5));
        }
    }
}
