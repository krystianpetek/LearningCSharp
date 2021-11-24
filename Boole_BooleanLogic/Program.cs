using System;
using System.Collections.Generic;
namespace Boole_BooleanLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            //((b --> a) <-> ((! a) --> (! b)))
            //  ((y &  a)   -->  (c |c))
            char[] x = Console.ReadLine().ToCharArray(); // całe wejscie w tablicy
            BooleanLogic logika = new BooleanLogic(x);
            logika.Wyswietl(logika.tablicaWartosci);

            
        }





    }
    public class BooleanLogic
    {
        private char[] _tablica { get; }
        private SortedList<char, int> SortListaSymboli { get; } // np. a c y
        private double IloscSymboli { get; } // = 2do2 = 4
        public char[,] tablicaWynikowa { get; set; }
        public int[,] tablicaWartosci { get; set; }
        public BooleanLogic(char[] tablica)
        {
            _tablica = tablica;
            SortListaSymboli = new SortedList<char, int>();
            SetListaSymboli();
            IloscSymboli = Math.Pow(2, SortListaSymboli.Count);
            tablicaWynikowa = new char[(int)IloscSymboli, _tablica.Length];
            Init(tablicaWynikowa);
            tablicaWartosci = Wartosciowanie(SortListaSymboli.Count);
            PRZYPISANIE(tablica);




        }

        private void PRZYPISANIE(char[] tablica)
        {
            int i = 0;
            while (true)
            {
                if (SortListaSymboli.ContainsKey(tablica[i]))
                {
                    var xlicz = tablica[i];
                    var zxlicz = tablica[xlicz];
                    for (int k = 0; k < tablicaWynikowa.GetLength(0); k++)
                    {
                        tablicaWynikowa[i, k] = Convert.ToChar(wartosc[i, zxlicz].ToString());
                    }
                }
                i++;
                if (i == tablica.Length)
                    break;
            }
        }

        private void SetListaSymboli()
        {
            List<char> tempList = new List<char>();
            for (int i = 0; i < _tablica.Length; i++)
            {
                if (char.IsLetter(_tablica[i]))
                {
                    if (!tempList.Contains(_tablica[i]))
                        tempList.Add(_tablica[i]);
                }
            }
            tempList.Sort();
            int N = 0;
            for (int i = 0; i < tempList.Count; i++)
                SortListaSymboli.Add(tempList[i], N++);

        }
        private static void Init(char[,] x)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)

                    x[i, j] = ' ';
            }
        }
        public void Wyswietl(int[,] x)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                    Console.Write(x[i, j]);
                Console.WriteLine();
            }
        }
        public void Wyswietl(char[,] x)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                    Console.Write(x[i, j]);
                Console.WriteLine();
            }
        }
        private int[,] Wartosciowanie(int a)
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




    }

}