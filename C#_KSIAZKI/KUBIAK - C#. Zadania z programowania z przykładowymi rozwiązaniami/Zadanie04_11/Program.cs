using System;
using System.Collections;
namespace Zadanie04_11
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList x = new ArrayList();
            x.Add(20);
            x.Add(51);
            x.Add(-72);
            x.Add(4);
            x.Add(14);
            x.Add(-4);
            foreach (var z in x)
                Console.Write(z + ", ");
            Console.WriteLine();
            x.Sort();
            foreach (var z in x)
                Console.Write(z + ", ");
            Console.WriteLine();
            x.RemoveAt(1);
            x.Add(10);
            foreach (var z in x)
                Console.Write(z + ", ");
            Console.WriteLine();
            x.Sort();
            foreach (var z in x)
                Console.Write(z + ", ");
            Console.WriteLine();
        }
    }
}
