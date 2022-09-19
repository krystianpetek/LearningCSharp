using System;

namespace RekurencyjneLiczenie
{
    class Program
    {
        private static int Liczenie(int x)
        {
            if (x < 10)
                return 1;
            else
                return 1 + Liczenie(x / 10);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Liczenie(93232355));
        }
    }
}
