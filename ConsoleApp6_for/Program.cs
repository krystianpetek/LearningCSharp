using System;

namespace ConsoleApp6_for
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            for (i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            for ( i = 10; i >= 0; i--)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            for ( i = 0; i < 10; i += 3)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            for (i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                if (i == 7) break;
            }

            Console.WriteLine();
            string[] names = { "Alex", "Eddie", "David", "Michael" };
            for (i = names.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(names[i]);
            }
            Console.WriteLine();
            for (int j = 0; j < names.Length; j++)
            {
                Console.WriteLine(names[j]);
            }

            Console.WriteLine();
            for (i = 0; i < names.Length; i++)
            {
                if (names[i] == "David")
                    names[i] = "Sammy";
            }
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
