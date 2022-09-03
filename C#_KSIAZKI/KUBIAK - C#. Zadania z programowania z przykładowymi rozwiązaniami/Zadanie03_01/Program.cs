using System;

namespace Zadanie03_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program liczy wartość funkcji y = 3x
            Console.WriteLine($"Wartość funkcji y = 3x dla");
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"x = {i} jest równe {i * 3}");
            }
        }
    }
}
