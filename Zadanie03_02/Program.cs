using System;

namespace Zadanie03_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            Console.WriteLine($"Wartość funkcji y = 3x dla");
            do
            {
                Console.WriteLine($"x = {x} jest równe {x * 3}");
                x++;
            }
            while (x <= 10);
        }
    }
}
