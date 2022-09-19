using System;
using System.Collections.Generic;

namespace SZYield
{
    internal class Program
    {
        static List<int> mojaLista = new List<int>();
        static void Main(string[] args)
        {
            FillList();
            foreach (var x in Total())
            {
                Console.WriteLine(x);
            }
        }
        static void FillList()
        {
            mojaLista.Clear();
            for (int i = 1; i < 8; i++)
                mojaLista.Add(i);
        }
        // custom iteration
        static IEnumerable<int> Filter()
        {
            foreach (var item in mojaLista)
                if (item > 3)
                    yield return item;
        }

        // stateful iteration, zliczanie liczb ktory pamięta stan
        static IEnumerable<int> Total()
        {
            int totalNumber = 0;
            foreach (var item in mojaLista)
            {
                totalNumber += item;
                yield return totalNumber;
            }
        }
    }
}
