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

            BUILDER(zdanie);

        }
        static void BUILDER(string zdanie)
        {
            // lista z pojedynczymi znakami
            List<char> kolekcja = new List<char>();
            foreach (char x in zdanie)
                if (char.IsLower(x))
                    kolekcja.Add('0');
            else
                kolekcja.Add(x);

            // argumenty
            List<char> argumenty = new List<char>();
            foreach (char x in zdanie)
            {
                if (char.IsLower(x))
                {
                    if (!argumenty.Contains(x))
                        argumenty.Add(x);

                    argumenty.Sort();
                }
            }

            int wskaznik = 0;
            for (int i = 0; i < kolekcja.Count; i++)
            {
                if (char.IsUpper(kolekcja[i]))
                {
                    if (char.IsDigit(kolekcja[i + 1]) && char.IsDigit(kolekcja[i + 2]))
                    {
                        switch (kolekcja[i])
                        {
                            case 'C':
                                kolekcja[i + 1] = czyAnd(kolekcja[i + 1], kolekcja[i + 2]);
                                kolekcja.RemoveAt(i);
                                break;
                            case 'D':
                                kolekcja[i + 1] = czyOr(kolekcja[i + 1], kolekcja[i + 2]);
                                kolekcja.RemoveAt(i);
                                break;
                            case 'I':
                                kolekcja[i + 1] = czyImplikacja(kolekcja[i + 1], kolekcja[i + 2]);
                                kolekcja.RemoveAt(i);
                                break;
                            case 'E':
                                kolekcja[i + 1] = czyRownowazne(kolekcja[i + 1], kolekcja[i + 2]);
                                kolekcja.RemoveAt(i);
                                break;
                            case 'N':
                                kolekcja[i] = czyNegacja(kolekcja[i + 1]);
                                break;
                            default:
                                Console.WriteLine("Błąd w syntaxie");
                                break;
                        }
                        if (wskaznik > 0)
                        {
                            i--;
                            wskaznik--;
                        }
                    }
                    else
                    {
                        wskaznik++;
                        continue;
                    }
                }
                else if (char.IsDigit(kolekcja[i]) || char.IsLower(kolekcja[i]))
                {

                }

            }

            foreach (var x in kolekcja)
            {
                Console.Write(x);
            }

        }
        static char czyRownowazne(int a, int b)
        {
            if (a == b)
                return '1';
            else
                return '0';
        }
        static char czyNegacja(int a)
        {
            a = a * (-1);
            return (char)a;
        }
        static char czyImplikacja(int a, int b)
        {
            if (a == 1 && b == 0)
                return '0';
            else
                return '1';
        }
        static char czyAnd(int a, int b)
        {
            if (a == 1 && b == 1)
                return '1';
            else
                return '0';
        }
        static char czyOr(int a, int b)
        {
            if (a == 0 && b == 0)
                return '0';
            else
                return '1';
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
