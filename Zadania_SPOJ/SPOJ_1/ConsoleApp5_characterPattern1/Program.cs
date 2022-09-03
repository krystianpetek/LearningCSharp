using System;

namespace ConsoleApp5_characterPattern1
{
    class Program
    {
        static void Kropka() => Console.Write(".");
        static void KropkaNl() => Console.WriteLine(".");
        static void Gwiazdka() => Console.Write("*");
        static void GwiazdkaNl() => Console.WriteLine("*");
        static void NowaLinia() => Console.WriteLine();
        static void Szachownica(int l, int c)
        {
            for (int k = 0;k < l;k++)
            {
                for (int i = 0; i < c; i++)
                {
                    if (i % 2 == 1)
                    {
                        if( k % 2 == 1)
                            Gwiazdka();
                        else
                            Kropka();
                    }
                    else
                    {
                        if (k % 2 == 1)
                            Kropka();
                        else
                            Gwiazdka();
                    }
                }
                NowaLinia();
            }   
        }
        static void Main(string[] args)
        {
            byte t = byte.Parse(Console.ReadLine());
            if (t < 100)
            {
                for (int i = 0; i < t; i++)
                {
                    string linia = Console.ReadLine();
                    string[] liczby = linia.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                                    
                    int l = int.Parse(liczby[0]);
                    int c = int.Parse(liczby[1]);

                    if(l < 100 && l > 0)
                    {
                        if(c < 100 && c > 0)
                            Szachownica(l, c);
                        else
                            throw new ArgumentException("Błędnie wprowadzone dane");
                    }
                    else
                    throw new ArgumentException("Błędnie wprowadzone dane");
                }
            }
            else
                throw new ArgumentException("Błędnie wprowadzone dane");
        }
    }
}
