using System;
using System.Collections;
using System.Collections.Generic;
namespace Boole_BooleanLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            //((b --> a) <-> ((! a) --> (! b)))
            //  ((y &  a)   -->  (c |c))
            
            while (true)
            {
                string x = Console.ReadLine();
                if (x == null || x == "")
                    break;
                char[] z = x.ToCharArray(); // całe wejscie w tablicy
                BooleanLogic logika = new BooleanLogic(z);
                logika.Wyswietl(logika.tablicaWynikowa);
            }
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

        private void Logika() { 

            for (int i = 0; i < tablicaWynikowa.GetLength(0); i++)
            {
                Queue<char> queue = new Queue<char>();
                Stack<char> stack = new Stack<char>();
                Queue<int> KolejkaZnaku = new Queue<int>();
                Stack<string> stackZnaku = new Stack<string>();
                for (int j = 0; j < tablicaWynikowa.GetLength(1); j++)
                {

                    switch (tablicaWynikowa[i, j])
                    {
                        case ' ':
                            break;
                        case '(':
                            stack.Push(tablicaWynikowa[i, j]);
                            stackZnaku.Push(tablicaWynikowa[i, j].ToString());
                            break;
                        case ')':
                            char c = stack.Pop();
                            queue.Enqueue(c);
                            stack.Pop();
                            KolejkaZnaku.Enqueue(Convert.ToInt32(stackZnaku.Pop().ToString()));
                            stackZnaku.Pop();
                            break;
                        case '0':
                        case '1':
                            queue.Enqueue(tablicaWynikowa[i, j]);
                            break;
                        case '-':
                            
                            while(tablicaWynikowa[i, j + 1] != '-')
                            {
                                j++;
                            }
                                tablicaWynikowa[i, j + 1] = '>';
                                stack.Push(tablicaWynikowa[i, j + 1]);
                                stackZnaku.Push((j + 1).ToString());
                            j++;
                            break;
                        case '<':
                            while (tablicaWynikowa[i, j + 1] != '-')
                            {
                                j++;
                            }
                                tablicaWynikowa[i, j + 1] = '<';
                                stack.Push(tablicaWynikowa[i, j + 1]);
                                stackZnaku.Push((j + 1).ToString());
                            j++;
                            break;
                        case '!':
                            stack.Push(tablicaWynikowa[i, j]);
                            stackZnaku.Push(j.ToString());

                            break;
                        case '&':
                            stack.Push(tablicaWynikowa[i, j]);
                            stackZnaku.Push(j.ToString());
                            break;
                        case '|':
                            stack.Push(tablicaWynikowa[i, j]);
                            stackZnaku.Push(j.ToString());
                            break;
                        default:
                            break;
                    }
                }

                Stack<char> stosIntow = new Stack<char>();
                char a, b;

                while (queue.Count > 0)
                {
                    if (queue.Peek() == '0' || queue.Peek() == '1')
                    {
                        stosIntow.Push(queue.Dequeue());
                    }
                    else
                    {
                        switch (queue.Peek())
                        {
                            case '>':
                                queue.Dequeue();
                                b = stosIntow.Pop();
                                a = stosIntow.Pop();
                                if (a == '1' && b == '0')
                                {
                                    tablicaWynikowa[i, KolejkaZnaku.Dequeue()] = '0';
                                    stosIntow.Push('0');
                                }
                                else
                                {
                                    tablicaWynikowa[i, KolejkaZnaku.Dequeue()] = '1';
                                    stosIntow.Push('1');

                                }
                                break;

                            case '<':
                                queue.Dequeue();
                                b = stosIntow.Pop();
                                a = stosIntow.Pop();
                                if (a == '1' && b == '1' || a == '0' && b == '0')
                                {
                                    tablicaWynikowa[i, KolejkaZnaku.Dequeue()] = '1';
                                    stosIntow.Push('1');

                                }
                                else
                                {
                                    tablicaWynikowa[i, KolejkaZnaku.Dequeue()] = '0';
                                    stosIntow.Push('0');

                                }
                                break;

                            case '&':
                                queue.Dequeue();
                                b = stosIntow.Pop();
                                a = stosIntow.Pop();
                                if (a == '1' && b == '1')
                                {
                                    tablicaWynikowa[i, KolejkaZnaku.Dequeue()] = '1';
                                    stosIntow.Push('1');

                                }
                                else
                                {
                                    tablicaWynikowa[i, KolejkaZnaku.Dequeue()] = '0';
                                    stosIntow.Push('0');

                                }
                                break;

                            case '|':
                                queue.Dequeue();
                                b = stosIntow.Pop();
                                a = stosIntow.Pop();
                                if (a == '0' && b == '0')
                                {
                                    tablicaWynikowa[i, KolejkaZnaku.Dequeue()] = '0';
                                    stosIntow.Push('0');

                                }
                                else
                                {
                                    tablicaWynikowa[i, KolejkaZnaku.Dequeue()] = '1';
                                    stosIntow.Push('1');

                                }
                                break;

                            case '!':
                                queue.Dequeue();
                                a = stosIntow.Pop();
                                if (a == '1')
                                {
                                    tablicaWynikowa[i, KolejkaZnaku.Dequeue()] = '0';
                                    stosIntow.Push('0');

                                }
                                else
                                {
                                    tablicaWynikowa[i, KolejkaZnaku.Dequeue()] = '1';
                                    stosIntow.Push('1');

                                }
                                break;
                        }
                    }
                }
                stosIntow.Clear();
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
                    if (x[i, j] == '0' || x[i, j] == '1')
                        Console.Write(x[i, j]);
                    else
                        Console.Write(' ');
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