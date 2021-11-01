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
                if (wejscie < 1 || wejscie > 35)
                    break;

                string zdanie = Console.ReadLine();
                if (zdanie == "" || zdanie == null)
                    break;

                Console.WriteLine( BUILDER(zdanie));
            }
        }
        static string BUILDER(string zdanie)
        {
            bool wyjscie = true;

            List<char> listaZnakow = new List<char>();
            foreach (char H in zdanie)
                listaZnakow.Add(H);
            List<char> duplikatListyZnakow = new List<char>(listaZnakow);

            List<char> posortowaneArgumenty = new List<char>();
            foreach (char H in listaZnakow)
            {
                if (char.IsLower(H))
                    if (!posortowaneArgumenty.Contains(H))
                        posortowaneArgumenty.Add(H);
            }
            //foreach(var z in listaZnakow)
            //    Console.Write(z);

            int x = 0b_000_001;
            x = x << listaZnakow.Count;
            x--;

            int[,] tablicaLiczb = new int[listaZnakow.Count, x + 1];
            for (int b = 0; b <= x; b++)
            {
                string linia = Do2Wyjscie(b, listaZnakow.Count);
                for (int a = 0; a < tablicaLiczb.GetLength(0); a++)
                    tablicaLiczb[a, b] = int.Parse(linia[a].ToString());
            }

            for (int przejsciaWszystkie = 0; przejsciaWszystkie < x + 1; przejsciaWszystkie++)
            {
                SortedList<char, int> argumentyWartosci = new SortedList<char, int>();
                for (int Xtab = 0; Xtab < posortowaneArgumenty.Count; Xtab++)
                {
                    argumentyWartosci.Add(posortowaneArgumenty[Xtab], tablicaLiczb[Xtab, przejsciaWszystkie]);
                }
                for (int zmianaArgNaWartosc = 0; zmianaArgNaWartosc < listaZnakow.Count; zmianaArgNaWartosc++)
                {
                    if (char.IsLower(duplikatListyZnakow[zmianaArgNaWartosc]))
                        if (argumentyWartosci.ContainsKey(duplikatListyZnakow[zmianaArgNaWartosc]))
                        {
                            string HJ = argumentyWartosci[duplikatListyZnakow[zmianaArgNaWartosc]].ToString();
                            listaZnakow[zmianaArgNaWartosc] = Convert.ToChar(HJ);
                        }
                }

                int wskaznik = 1;
                while (wskaznik > 0 && listaZnakow.Count > 1)
                {
                    wskaznik--;
                    for (int i = 0; i < listaZnakow.Count; i++)
                    {
                        if (!char.IsLetterOrDigit(listaZnakow[i]))
                            break;
                        if (char.IsUpper(listaZnakow[i]))
                        {
                            if (listaZnakow[i] == 'N')
                            {
                                if (char.IsDigit(listaZnakow[i + 1]))
                                {
                                    listaZnakow[i] = czyNegacja(Convert.ToInt32(listaZnakow[i + 1].ToString()));
                                    listaZnakow.RemoveAt(i + 1);
                                    wskaznik++;
                                }
                                else
                                {
                                    wskaznik++;
                                    continue;
                                }
                            }
                            else if (char.IsDigit(listaZnakow[i + 1]) && char.IsDigit(listaZnakow[i + 2]))
                            {
                                switch (listaZnakow[i])
                                {
                                    case 'C':
                                        listaZnakow[i] = czyAnd(Convert.ToInt32(listaZnakow[i + 1].ToString()), Convert.ToInt32(listaZnakow[i + 2].ToString()));
                                        listaZnakow.RemoveAt(i + 1);
                                        listaZnakow.RemoveAt(i + 1);
                                        wskaznik++;
                                        break;
                                    case 'D':
                                        listaZnakow[i] = czyOr(Convert.ToInt32(listaZnakow[i + 1].ToString()), Convert.ToInt32(listaZnakow[i + 2].ToString()));
                                        listaZnakow.RemoveAt(i + 1);
                                        listaZnakow.RemoveAt(i + 1);
                                        wskaznik++;
                                        break;
                                    case 'I':
                                        listaZnakow[i] = czyImplikacja(Convert.ToInt32(listaZnakow[i + 1].ToString()), Convert.ToInt32(listaZnakow[i + 2].ToString()));
                                        listaZnakow.RemoveAt(i + 1);
                                        listaZnakow.RemoveAt(i + 1);
                                        wskaznik++;
                                        break;
                                    case 'E':
                                        listaZnakow[i] = czyRownowazne(Convert.ToInt32(listaZnakow[i + 1].ToString()), Convert.ToInt32(listaZnakow[i + 2].ToString()));
                                        listaZnakow.RemoveAt(i + 1);
                                        listaZnakow.RemoveAt(i + 1);
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
                foreach (char sprawdzenie in listaZnakow)
                {
                    if (sprawdzenie == '0')
                    {
                        wyjscie = false;
                        break;
                    }
                }

                listaZnakow = new List<char>();
                foreach (char H in zdanie)
                    listaZnakow.Add(H);
                posortowaneArgumenty = new List<char>();
                foreach (char H in listaZnakow)
                {
                    if (char.IsLower(H))
                        if (!posortowaneArgumenty.Contains(H))
                            posortowaneArgumenty.Add(H);
                }
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
    }
}