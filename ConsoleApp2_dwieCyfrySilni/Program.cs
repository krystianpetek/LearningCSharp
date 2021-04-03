using System;

namespace ConsoleApp2_dwieCyfrySilni
{
    class Program
    {
        static void Main(string[] args)
        {
            // DWIE CYFRY SILNI
            
            /* DANE WEJSCIOWE:
             * 5
             * 5
             * 7
             * 9
             * 11
             * 13
             */

            string wejscie = Console.ReadLine();
            byte D = byte.Parse(wejscie);
            if (D < 1 || D > 30) return;

            for (int i = 0; i < D; i++)
            {
                string linia = Console.ReadLine();
                uint n = uint.Parse(linia);

                if (n >= 10)
                    Console.WriteLine(0 + " " + 0);

                else
                {
                    ulong count = 1;
                    for (ulong j = 1; j <= n; j++)
                    {
                        count *= j;
                    }
                    char[] znak = count.ToString("00").ToCharArray();
                    Console.WriteLine(znak[znak.Length - 2] + " " + znak[znak.Length - 1]);
                }
            }
            // OBLICZANIE SILNI
            Console.WriteLine("Obliczanie silni");

            string linia2 = Console.ReadLine();
            uint n2 = uint.Parse(linia2);
            ulong count2 = 1;
            for (ulong j = 1; j <= n2; j++)
            {
                count2 *= j;
            }
            Console.WriteLine($"{n2}! = {count2}");


        }

    }
}

