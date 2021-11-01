using System;
using System.Collections.Generic;
using System.Text;

namespace RefaktoryzacjaTautologii
{
    class Program
    {
        static void Main(string[] args)
        {
            int wejscie = int.Parse(Console.ReadLine());
            for (int i = 0; i < wejscie; i++)
            {
                string zdanie = Console.ReadLine();
                StringBuilder x = new StringBuilder();
                x.Append(BUILDER(zdanie));
                Console.WriteLine(x);
            }

        }
        static string BUILDER(string zdanie)
        {
            bool wyjscie = true;

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

            lista = new List<char>();
            WyswietlArgumenty(zdanie);
            int x = 0b_000_001;
            x = x << LICZBA;
            x--;

            int[,] tablicaLiczb = new int[LICZBA, x + 1];
            for (int b = 0; b <= x; b++)
            {
                string linia = Do2Wyjscie(b, LICZBA);
                for (int a = 0; a < tablicaLiczb.GetLength(0); a++)
                    tablicaLiczb[a, b] = int.Parse(linia[a].ToString());
            }

            List<char> kolekcja2 = new List<char>(kolekcja);
            for (int przejsciaWszystkie = 0; przejsciaWszystkie < x + 1; przejsciaWszystkie++)
            {
                Dictionary<char, int> argumentyWartosci = new Dictionary<char, int>();
                for (int Xtab = 0; Xtab < posortowaneArgumenty.Count; Xtab++)
                {
                    argumentyWartosci.Add(posortowaneArgumenty[Xtab], tablicaLiczb[Xtab, przejsciaWszystkie]);
                }
                for (int zmianaArgNaWartosc = 0; zmianaArgNaWartosc < kolekcja.Count; zmianaArgNaWartosc++)
                {
                    if (char.IsLower(kolekcja2[zmianaArgNaWartosc]))
                        if (argumentyWartosci.ContainsKey(kolekcja2[zmianaArgNaWartosc]))
                        {
                            string HJ = argumentyWartosci[kolekcja2[zmianaArgNaWartosc]].ToString();
                            kolekcja[zmianaArgNaWartosc] = Convert.ToChar(HJ);
                        }
                }

                int wskaznik = 1;
                while (wskaznik > 0 && kolekcja.Count > 1)
                {
                    wskaznik--;
                    for (int i = 0; i < kolekcja.Count; i++)
                    {
                        if (char.IsUpper(kolekcja[i]))
                        {
                            if (kolekcja[i] == 'N')
                            {
                                if (char.IsDigit(kolekcja[i + 1]))
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
                                continue;
                            }
                        }
                        else
                            wskaznik++;
                    }
                    if (wskaznik > 0)
                        wskaznik -= 2;
                }
                foreach (char sprawdzenie in kolekcja)
                {
                    if (sprawdzenie == '0')
                    {
                        wyjscie = false;
                        break;
                    }
                }

                kolekcja = new List<char>();
                foreach (char H in zdanie)
                    kolekcja.Add(H);
                posortowaneArgumenty = new List<char>();
                foreach (char H in kolekcja)
                {
                    if (char.IsLower(H))
                        if (!posortowaneArgumenty.Contains(H))
                            posortowaneArgumenty.Add(H);
                }
                posortowaneArgumenty.Sort();
            }
            if (wyjscie)
                return "YES";
            else
                return "NO";

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
        static string Do2Wyjscie(int a, int b = 2)
        {
            return Convert.ToString(a, toBase: 2).PadLeft(b, '0');
        }
        public static int LICZBA => lista.Count;
        private static List<char> lista = new List<char>();
        static void WyswietlArgumenty(string i)
        {
            foreach (char z in i)
            {
                if (char.IsLower(z))
                {
                    if (!lista.Contains(z))
                        lista.Add(z);

                    lista.Sort();
                }
            }
        }
    }
}
