using System;

namespace ConsoleApp9_characterPattern3
{
    class Program
    {
        static void Linia()
        {
            Console.Write("*");
            Console.Write("*");
            Console.Write("*");
        }
        static void LiniaSrodek()
        {
            Console.Write("*");
            Console.Write(".");
            Console.Write(".");
        }
        static void GwiazdkaNL() => Console.WriteLine("*");
        public static void Pattern(int l, int c)
        {
            for (int i = 0; i < l; i++)
            {
                for (int pierwsza = 0; pierwsza < c; pierwsza++)
                {
                    Linia();
                    if (pierwsza == c-1)
                        GwiazdkaNL();
                }
                for (int druga = 0; druga < c; druga++)
                {
                    LiniaSrodek();
                    if (druga == c - 1)
                        GwiazdkaNL();
                }
                for (int trzecia = 0; trzecia < c; trzecia++)
                {
                    LiniaSrodek();
                    if (trzecia == c - 1)
                        GwiazdkaNL();
                }
            }
            for (int czwarta = 0; czwarta < c; czwarta++)
            {
                Linia();
                if (czwarta == c - 1)
                    GwiazdkaNL();
            }
        }
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                string linia = Console.ReadLine();
                string[] liczby = linia.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int l = int.Parse(liczby[0]);
                int c = int.Parse(liczby[1]);

                Pattern(l, c);
            }
        }
    }
}

