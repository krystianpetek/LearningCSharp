using System;
using System.Diagnostics;

namespace ConsoleApp2._1_dwieCyfrySilni
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong Silnia(ulong n)
            {
                ulong silnia = 1;
                for (ulong i = 1; i <= n; i++)
                {
                    silnia = checked(silnia * i);
                }
                return silnia;
            }
            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine($"{i.ToString("00")}! = { Silnia((ulong)i):N0}");
            }
            // Console.WriteLine($21}! = {Silnia((ulong)21)}");

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int D = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= D; i++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(Oblicz(n));
            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
        }

        public static string Oblicz(int n)
        {
            int cyfraOstatnia = 0;
            int cyfraPrzedostatnia = 0;

            switch (n)
            {
                case 0: cyfraOstatnia = 1; break;
                case 1: cyfraOstatnia = 1; break;
                case 2: cyfraOstatnia = 2; break;
                case 3: cyfraOstatnia = 6; break;
                case 4: cyfraOstatnia = 4; cyfraPrzedostatnia = 2; break;
                case 5: cyfraPrzedostatnia = 2; break;
                case 6: cyfraPrzedostatnia = 2; break;
                case 7: cyfraPrzedostatnia = 4; break;
                case 8: cyfraPrzedostatnia = 2; break;
                case 9: cyfraPrzedostatnia = 8; break;
            }
            return cyfraPrzedostatnia + " " + cyfraOstatnia;
        }
    }
}