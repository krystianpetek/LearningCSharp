using System;

namespace ConsoleApp8_while
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int current = 0;
            do
            {
                current = random.Next(1, 11);
                Console.WriteLine(current);
            } while (current != 7);

            Console.WriteLine();
            current = random.Next(1, 11);
            while (current >= 3)
            {
                Console.WriteLine(current);
                current = random.Next(1, 11);
            }
            Console.WriteLine($"Last number: {current}");

            Console.WriteLine();
            current = random.Next(1, 11);
            do
            {

                Console.WriteLine(current);
                current = random.Next(1, 11);
                if (current >= 8) continue;
            } while (current != 7);

            Console.WriteLine($"Last number: {current}");

        }
    }
}
