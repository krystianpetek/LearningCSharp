using System;
using System.Collections;

namespace Zadanie04_12
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList lista = new ArrayList();
            lista.Add("Tomek");
            lista.Add("Ania");
            lista.Add("Zenek");
            lista.Add("Jarek");
            lista.Add("Kasia");
            lista.Add("Dominika");

            Console.WriteLine("Lista nieposortowana");
            foreach(var x in lista)
            {
                Console.Write(x+", ");
            }
            lista.Sort();
            Console.WriteLine();
            Console.WriteLine("\nLista posortowana");
            foreach(var x in lista)
                Console.Write(x+", ");
            Console.WriteLine();

        }
    }
}
