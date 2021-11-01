using System;
using System.Collections.Generic;

namespace TAUTOLOGIA
{
    class Program
    {
        static void Main(string[] args)
        {
            string zdanie = "Ezz";
            BUILDER(zdanie);

        }
        static void BUILDER(string zdanie)
        {
            // lista z pojedynczymi znakami
            List<char> kolekcja = new List<char>();
            foreach (char H in zdanie)
                kolekcja.Add(H);

            // LISTA Z POSORTOWANYMI ARGUMENTAMI
            List<char> posortowaneArgumenty = new List<char>();
            foreach (char H in kolekcja)
            {
                if (char.IsLower(H))
                    if (!posortowaneArgumenty.Contains(H))
                        posortowaneArgumenty.Add(H);
            }
            posortowaneArgumenty.Sort();
            //WYSWIETLENIE ARGUMENTOW
            foreach (var H in posortowaneArgumenty)
                Console.Write(H);
            Console.WriteLine();


            WyswietlArgumenty(zdanie);
            int x = 0b_000_001;
            x = x << LICZBA;
            x--;
            // tablica wartosci
            int[,] tablicaLiczb = new int[LICZBA, x + 1];
            for (int b = 0; b <= x; b++)
            {
                string linia = Do2Wyjscie(b, LICZBA);
                for (int a = 0; a < tablicaLiczb.GetLength(0); a++)
                    tablicaLiczb[a, b] = int.Parse(linia[a].ToString());
            }

            Console.WriteLine("Wyswietlenie kolekcji poczatkowej");
            foreach (var H in kolekcja)
                Console.Write(H);
            Console.WriteLine();

            List<char> kolekcja2 = new List<char>(kolekcja);
            for (int przejsciaWszystkie = 0; przejsciaWszystkie < x + 1; przejsciaWszystkie++)
            {
                // arugumenty i przypisanie im wartości
                Dictionary<char, int> argumentyWartosci = new Dictionary<char, int>();
                for (int Xtab = 0; Xtab < posortowaneArgumenty.Count; Xtab++)
                {
                    argumentyWartosci.Add(posortowaneArgumenty[Xtab], tablicaLiczb[Xtab, przejsciaWszystkie]);
                }
                foreach (var z in argumentyWartosci)
                    Console.Write(z);
                Console.WriteLine();


                for (int zmianaArgNaWartosc = 0; zmianaArgNaWartosc < kolekcja.Count; zmianaArgNaWartosc++)
                {
                    if (char.IsLower(kolekcja2[zmianaArgNaWartosc]))
                        if (argumentyWartosci.ContainsKey(kolekcja2[zmianaArgNaWartosc]))
                        {
                            string HJ = argumentyWartosci[kolekcja2[zmianaArgNaWartosc]].ToString();
                            kolekcja[zmianaArgNaWartosc] = Convert.ToChar(HJ);
                        }
                }
                Console.WriteLine("Przed operacjami");
                foreach (var H in kolekcja)
                    Console.Write(H);
                Console.WriteLine();

                int wskaznik = 1;
                while (wskaznik > 0 && kolekcja.Count > 1)
                {
                    wskaznik--;
                    for (int i = 0; i < kolekcja.Count; i++)
                    {
                        if (char.IsUpper(kolekcja[i]))
                        {

                            if(kolekcja[i] == 'N')
                            {

                                if(char.IsDigit(kolekcja[i+1]))
                                {
                                    kolekcja[i] = czyNegacja(Convert.ToInt32(kolekcja[i + 1].ToString()));
                                    kolekcja.RemoveAt(i + 1);
                                    wskaznik++;
                                }
                                else
                                {
                                    wskaznik++;
                                    continue;
                                }
                            }
                            else if (char.IsDigit(kolekcja[i + 1]) && char.IsDigit(kolekcja[i + 2]))
                            {

                                switch (kolekcja[i])
                                {
                                    case 'C':
                                        kolekcja[i] = czyAnd(Convert.ToInt32(kolekcja[i + 1].ToString()), Convert.ToInt32(kolekcja[i + 2].ToString()));
                                        kolekcja.RemoveAt(i + 1);
                                        kolekcja.RemoveAt(i + 1);
                                        wskaznik++;
                                        break;
                                    case 'D':
                                        kolekcja[i] = czyOr(Convert.ToInt32(kolekcja[i + 1].ToString()), Convert.ToInt32(kolekcja[i + 2].ToString()));
                                        kolekcja.RemoveAt(i + 1);
                                        kolekcja.RemoveAt(i + 1);
                                        wskaznik++;
                                        break;
                                    case 'I':
                                        kolekcja[i] = czyImplikacja(Convert.ToInt32(kolekcja[i + 1].ToString()), Convert.ToInt32(kolekcja[i + 2].ToString()));
                                        kolekcja.RemoveAt(i + 1);
                                        kolekcja.RemoveAt(i + 1);
                                        wskaznik++;
                                        break;
                                    case 'E':
                                        kolekcja[i] = czyRownowazne(Convert.ToInt32(kolekcja[i + 1].ToString()), Convert.ToInt32(kolekcja[i + 2].ToString()));
                                        kolekcja.RemoveAt(i + 1);
                                        kolekcja.RemoveAt(i + 1);
                                        wskaznik++;
                                        break;
                                    default:
                                        Console.WriteLine("Błąd w syntaxie");
                                        break;
                                }

                            }
                            else
                            {
                                wskaznik++;
                                //Console.WriteLine("Pomiń + dodaj wskaznik " + wskaznik + "i: " + i);
                                continue;
                            }


                        }

                        else
                        {
                            wskaznik++;
                            //Console.WriteLine("Pomiń + dodaj wskaznik " + wskaznik + "i: " + i);

                        }

                        foreach (var z in kolekcja)
                            Console.Write(z);
                        Console.WriteLine();
                    }

                    if (wskaznik > 0)
                        wskaznik -= 2;

                }
                kolekcja = new List<char>();
                foreach (char H in zdanie)
                    kolekcja.Add(H);
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
            string x = (a * (-1)).ToString();
            if (x == "0")
                return '1';
            else
                return '0';
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
