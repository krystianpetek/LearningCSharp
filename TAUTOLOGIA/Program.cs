using System;
using System.Collections.Generic;

namespace TAUTOLOGIA
{
    class Program
    {
        static void Main(string[] args)
        {
            string zdanie = "IIpqDpNp";
            zdanie = "IIqrIIpqIpr";

            WyswietlArgumenty(zdanie);
            int x = 0b_000_001;
            x = x << LICZBA;
            x--;

            //x = x + x+1;
            //Console.WriteLine();
            //Iteracja(x);

            int[,] tablicaLiczb = new int[LICZBA, x + 1];

            // PRZYPISANIE
            for (int b = 0; b <= x; b++)
            {
                string linia = Do2Wyjscie(b, LICZBA);
                for (int a = 0; a < tablicaLiczb.GetLength(0); a++)
                {
                    tablicaLiczb[a, b] = int.Parse(linia[a].ToString());
                }
            }

            // WYSWIETLIENIE 
            for (int b = 0; b <= x; b++)
            {
                for (int a = 0; a < tablicaLiczb.GetLength(0); a++)
                {
                    Console.Write(tablicaLiczb[a, b]);
                }
                Console.WriteLine();
            }
        }

        static void Iteracja(int x)
        {
            for (int i = 0; i <= x; i++)
            {
                Console.Write($"{i} - ");
                Do2(i, LICZBA);
            }
        }

        static void Do2(int a, int b = 2)
        {
            Console.WriteLine("Liczba: {0}", Convert.ToString(a, toBase: 2).PadLeft(b, '0'));
            string konwersja = Convert.ToString(a, toBase: 2).PadLeft(b, '0');

        }
        static string Do2Wyjscie(int a, int b = 2)
        {
            string konwersja = Convert.ToString(a, toBase: 2).PadLeft(b, '0');
            return konwersja;
        }

        static void Dopisz(char x)
        {
            if (!lista.Contains(x))
                lista.Add(x);

            lista.Sort();
        }

        public static int LICZBA => lista.Count;
        private static List<char> lista = new List<char>();

        static void WyswietlArgumenty(string i)
        {
            foreach (char z in i)
            {
                if (char.IsLower(z))
                {
                    Dopisz(z);
                }
            }

            Console.Write("Argumenty: ");
            foreach (var z in lista)
            {
                Console.Write($"{z} ");
            }
            Console.WriteLine();
        }
    }
}
