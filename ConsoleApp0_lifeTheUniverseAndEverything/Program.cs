using System;

namespace ConsoleApp0_lifeTheUniverseAndEverything
{
    class Program
    {
        static void Main(string[] args)
        {
            int liczba = 0;
            do
            {
                liczba = int.Parse(Console.ReadLine());
                if (liczba >= 100)
                {
                    throw new ArgumentException("zle dane");
                    return;
                }
                else
                {
                    if (liczba == 42)
                        continue;
                    else
                        Console.WriteLine(liczba);
                }
            } while (liczba != 42);
        }
    }
}
