using System;

namespace ConsoleApp6_characterPattern2
{
    class Program
    {
        static void Kropka() => Console.Write(".");
        static void KropkaNl() => Console.WriteLine(".");
        static void Gwiazdka() => Console.Write("*");
        static void GwiazdkaNl() => Console.WriteLine("*");
        static void NowaLinia() => Console.WriteLine();

        public static void ProstokatWypelniony(int l, int c)
        {

            //PIERWSZA LINIA
            for (int i = 0; i < c; i++)
                Gwiazdka();
            NowaLinia();


            // SRODEK
            for (int i = 1; i < l - 1; i++)
            {
                Gwiazdka();
                for (int j = 1; j < c - 1; j++)
                    Kropka();
                if (c > 1)
                    GwiazdkaNl();
                else
                    NowaLinia();
            }

            // OSTATNIA LINIA
            if (l == 1)
            {
                return;
            }
            else
            {
                for (int i = 0; i < c; i++)
                    Gwiazdka();
                NowaLinia();
                NowaLinia();
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
                if (l > 0)
                {
                    if (c > 0)
                        ProstokatWypelniony(l, c);
                    else
                        throw new ArgumentException("Błędnie wprowadzone dane");
                }
                else
                    throw new ArgumentException("Błędnie wprowadzone dane");
            }
        }
    }
}
