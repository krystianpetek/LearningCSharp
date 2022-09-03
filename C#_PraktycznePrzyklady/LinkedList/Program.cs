using System;
using System.Collections.Generic;
namespace _15._LinkedList
{
    class Program
    {

        static void Main(string[] args)
        {
            LinkedList<int> listaLinkowana = new LinkedList<int>();
            listaLinkowana.AddLast(32);
            listaLinkowana.AddLast(132);
            listaLinkowana.AddLast(322);
            Console.WriteLine(listaLinkowana.Last.Previous.Previous.Value);
            Console.WriteLine();
            foreach (var x in listaLinkowana)
                Console.WriteLine(x);
            Console.WriteLine();
            Console.WriteLine(listaLinkowana.Contains(32));
            listaLinkowana.AddBefore(listaLinkowana.Find(132), 55);

            foreach (var x in listaLinkowana)
                Console.WriteLine(x);
            Console.WriteLine();
            listaLinkowana.Remove(32);

            foreach (var x in listaLinkowana)
                Console.WriteLine(x);
        }
    }
}
