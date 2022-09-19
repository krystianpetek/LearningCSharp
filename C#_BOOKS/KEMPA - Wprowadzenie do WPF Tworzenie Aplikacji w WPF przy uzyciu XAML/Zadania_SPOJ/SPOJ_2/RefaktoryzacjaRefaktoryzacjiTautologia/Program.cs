using System;
using System.Collections.Generic;
using System.Text;

namespace RefaktoryzacjaRefaktoryzacjiTautologia
{
    class Program
    {
        static void Main(string[] args)
        {
            // IIqrIIpqIpr
            StringBuilder wynik = new StringBuilder();
            string operatory = "CDIEN";
            int linia = int.Parse(Console.ReadLine());
            for (int i = 0; i < linia; i++)
            {
                string zdanie = Console.ReadLine();
                wynik.AppendLine(Kierowniku(zdanie, operatory));
            }
            Console.WriteLine(wynik);
        }
        public static string Kierowniku(string zdanie, string operatory)
        {
            string wynik = "NO";
            List<char> listaZnakow = PosortowanaListaArgumentow(zdanie);
            int iloscArgumentow = listaZnakow.Count;
            int[,] tablicaLiczb = PrzypisanieWartosciLiczb(iloscArgumentow);
            bool wynikBool = CzyTautologia(zdanie, operatory, tablicaLiczb, listaZnakow);

            if (wynikBool)
                wynik = "YES";
            else
                wynik = "NO";
            return wynik;
        }
        public static List<char> PosortowanaListaArgumentow(string zdanie)
        {
            List<char> listaZnakow = new List<char>();
            foreach (var x in zdanie)
                if (char.IsLower(x) && !listaZnakow.Contains(x))
                    listaZnakow.Add(x);
            listaZnakow.Sort();
            return listaZnakow;
        }
        public static int[,] PrzypisanieWartosciLiczb(int a)
        {
            int b = (int)Math.Pow(2, a);
            int[,] tablicaLiczb = new int[b, a];
            for (int i = 0; i < b; i++)
            {
                string X = Convert.ToString(i, 2).PadLeft(a, '0');
                for (int j = 0; j < a; j++)
                {
                    tablicaLiczb[i, j] = int.Parse(X[j].ToString());
                }
            }
            return tablicaLiczb;
        }
        public static bool CzyTautologia(string zdanie, string operatory, int[,] tablicaLiczb, List<char> listaZnakow)
        {
            bool odpowiedz = false;
            List<char> LZ = new List<char>();
            for (int iloscImplikacji = 0; iloscImplikacji < Math.Pow(2, listaZnakow.Count); iloscImplikacji++)
            {
                LZ = new List<char>(PrzypiszListe(zdanie, listaZnakow, tablicaLiczb, iloscImplikacji));
                int i = zdanie.Length - 1;
                while (i >= 0)
                {
                    if (LZ[i] == '0' || LZ[i] == '1')
                    {
                        i--;
                        continue;
                    }
                    switch (LZ[i])
                    {
                        case 'C':
                            LZ[i] = AND(LZ[i + 1], LZ[i + 2]);
                            LZ.RemoveAt(i + 1);
                            LZ.RemoveAt(i + 1);
                            i--;
                            break;
                        case 'D':
                            LZ[i] = OR(LZ[i + 1], LZ[i + 2]);
                            LZ.RemoveAt(i + 1);
                            LZ.RemoveAt(i + 1);
                            i--;
                            break;
                        case 'I':
                            LZ[i] = Implikacja(LZ[i + 1], LZ[i + 2]);
                            LZ.RemoveAt(i + 1);
                            LZ.RemoveAt(i + 1);
                            i--;
                            break;
                        case 'E':
                            LZ[i] = Rownowaznosc(LZ[i + 1], LZ[i + 2]);
                            LZ.RemoveAt(i + 1);
                            LZ.RemoveAt(i + 1);
                            i--;
                            break;
                        case 'N':
                            LZ[i] = NOT(LZ[i + 1]);
                            LZ.RemoveAt(i + 1);
                            break;
                        default:
                            i--;
                            break;
                    }
                }
                if (LZ[0] != '1')
                {
                    odpowiedz = false;
                    break;
                }
                else
                    odpowiedz = true;
            }
            return odpowiedz;
        }
        public static List<char> PrzypiszListe(string zdanie, List<char> listaZnakow, int[,] tablicaLiczb, int iX)
        {
            List<char> LZ = new List<char>();

            for (int i = 0; i < zdanie.Length; i++)
            {
                if (char.IsLower(zdanie[i]))
                    for (int L = 0; L < listaZnakow.Count; L++)
                    {
                        if (zdanie[i] == listaZnakow[L])
                            LZ.Add(Convert.ToChar(tablicaLiczb[iX, L].ToString()));
                    }
                else
                {
                    LZ.Add(zdanie[i]);
                }
            }
            return LZ;
        }
        static char NOT(int a) => (a == '1') ? '0' : '1';
        static char AND(int a, int b) => (a == '1' && b == '1') ? '1' : '0';
        static char OR(int a, int b) => (a == '1' && b == '1') ? '0' : '1';
        static char Implikacja(int a, int b) => (a == '1' && b == '0') ? '0' : '1';
        static char Rownowaznosc(int a, int b) => (a == b) ? '1' : '0';
    }
}
