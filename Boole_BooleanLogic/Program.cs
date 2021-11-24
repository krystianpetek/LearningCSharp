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
            logika.Wyswietl(logika.tablicaWynikowa);
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
            Init(tablicaWynikowa, tablica);
            tablicaWartosci = Wartosciowanie(SortListaSymboli.Count);
            SetArg(tablica);
            Logika();


        }

        private void Logika()
        {
            // ((b --> a) <-> ((! a) --> (! b)))

            for (int i = 0; i < tablicaWynikowa.GetLength(0); i++)
            {
                Queue<char> queue = new Queue<char>();
                Stack<char> stack = new Stack<char>();
                for (int j = 0; j < tablicaWynikowa.GetLength(1); j++)
                {

                    switch (tablicaWynikowa[i, j])
                    {
                        case ' ':
                            break;
                        case '(':
                            stack.Push(tablicaWynikowa[i, j]);
                            break;
                        case ')':
                            char c = stack.Pop();
                            queue.Enqueue(c);
                            stack.Pop();
                            break;
                        case '0':
                        case '1':
                            queue.Enqueue(tablicaWynikowa[i, j]);
                            break;
                        case '-':
                            if (tablicaWynikowa[i, j + 1] == '-' && tablicaWynikowa[i, j + 2] == '>')
                            {
                                tablicaWynikowa[i, j + 1] = '>';
                                stack.Push(tablicaWynikowa[i, j + 1]);
                            }
                            break;
                        case '<':
                            if (tablicaWynikowa[i, j + 1] == '-' && tablicaWynikowa[i, j + 2] == '>')
                            {
                                tablicaWynikowa[i, j + 1] = '<';
                                stack.Push(tablicaWynikowa[i, j + 1]);
                            }
                            break;
                        case '!':
                            stack.Push(tablicaWynikowa[i, j]);
                            break;
                        case '&':
                            stack.Push(tablicaWynikowa[i, j]);
                            break;
                        case '|':
                            stack.Push(tablicaWynikowa[i, j]);
                            break;
                        default:
                            break;
                    }
                }



            }
        }

        private void SetArg(char[] tablica)
        {
            int i = 0;
            while (true)
            {

                if (SortListaSymboli.ContainsKey(tablica[i]))
                {

                    var znakWartosci = tablica[i];
                    var pozycjaWartosci = SortListaSymboli[znakWartosci];
                    for (int k = 0; k < tablicaWynikowa.GetLength(0); k++)
                    {
                        tablicaWynikowa[k, i] = Convert.ToChar(tablicaWartosci[k, pozycjaWartosci].ToString());
                    }
                }
                i++;
                if (i == tablica.Length)
                    break;
            }
        }
        //private void SetArg(char[] tablica)
        //{
        //    int i = 0;
        //    while (true)
        //    {
        //        if (SortListaSymboli.ContainsKey(tablica[i]))
        //        {

        //            var znakWartosci = tablica[i];
        //            var pozycjaWartosci = SortListaSymboli[znakWartosci];
        //            for (int k = 0; k < tablicaWynikowa.GetLength(0); k++)
        //            {
        //                tablicaWynikowa[k, i] = Convert.ToChar(tablicaWartosci[k, pozycjaWartosci].ToString());
        //            }
        //        }
        //        switch (tablica[i])
        //        {
        //            case '!':

        //                for (int k = 0; k < tablicaWynikowa.GetLength(0); k++)
        //                {
        //                    tablicaWynikowa[k, i] = '!';
        //                }
        //                break;
        //            case '-':
        //                if (tablica[i - 1] == '<' && tablica[i + 1] == '>')
        //                {
        //                    for (int k = 0; k < tablicaWynikowa.GetLength(0); k++)
        //                    {
        //                        tablicaWynikowa[k, i] = 'e';
        //                    }
        //                }
        //                else if (tablica[i - 1] == '-' && tablica[i + 1] == '>')
        //                {
        //                    for (int k = 0; k < tablicaWynikowa.GetLength(0); k++)
        //                    {
        //                        tablicaWynikowa[k, i] = 'i';
        //                    }
        //                }
        //                break;
        //            case '|':
        //                for (int k = 0; k < tablicaWynikowa.GetLength(0); k++)
        //                {
        //                    tablicaWynikowa[k, i] = '|';
        //                }
        //                break;
        //            case '&':
        //                for (int k = 0; k < tablicaWynikowa.GetLength(0); k++)
        //                {
        //                    tablicaWynikowa[k, i] = '&';
        //                }
        //                break;
        //        }
        //        i++;
        //        if (i == tablica.Length)
        //            break;
        //    }
        //}

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
        private static void Init(char[,] x, char[] tablica)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)

                    x[i, j] = tablica[j];
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