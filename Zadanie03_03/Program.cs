using System;

namespace Zadanie03_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            Console.WriteLine($"Wartość funkcji y = 3x dla");
            while (x <= 10)
            {
                Console.WriteLine($"x = {x} jest równe {x*3}");
                x++;
            }
        }
    }
}
