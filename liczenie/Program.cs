using System;

namespace liczenie
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            Console.Write("Wprowadź liczbę: ");
            x = int.Parse(Console.ReadLine());

            Console.Write($"{x}, ");
            while (x != 1)
            {
                if (x % 2 == 0)
                    x /= 2;
                else
                {
                    if (x == 1)
                    {
                        break;
                    }
                    else
                    {
                        x = x * 3 + 1;
                    }
                }
                if(x == 1)
                {
                    Console.Write($"{x}");

                }
                else
                Console.Write($"{x}, ");
            }
        }
    }
}
