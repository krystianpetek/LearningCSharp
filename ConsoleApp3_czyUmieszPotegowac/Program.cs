using System;

namespace ConsoleApp3_czyUmieszPotegowac
{
    class Program
    {
        static void Main(string[] args)
        {
            byte D = byte.Parse(Console.ReadLine());
            if (D < 1 || D > 10) return;
            for (int i = 0; i < D; i++)
            {
                string liniaDruga = Console.ReadLine();
                string[] tabLiczb = liniaDruga.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int a = int.Parse(tabLiczb[0]);
                a %= 10;
                int b = int.Parse(tabLiczb[1]);
                if (b % 4 == 0)
                    b = 4;
                else
                    b %= 4;
                int c = a;
                for (int j = 1; j < b; j++)
                {
                    c *= a;
                }
                // PRZYKLAD 1
                char[] ostatnia = c.ToString().ToCharArray();
                Console.WriteLine(ostatnia[ostatnia.Length - 1]);
                // PRZYKLAD 2
                Console.WriteLine(c.ToString().Substring(c.ToString().Length - 1));
                //Przyklad 3
                Console.WriteLine(c%10);
            }
        }

    }
}
