using System;

namespace SZ_Equals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object a1 = "Jaka jest różnica pomiędzy Equals i ==";
            object a2 = new string("Jaka jest różnica pomiędzy Equals i ==".ToCharArray());

            string b = "sss";
            string c = "sss";

            Console.WriteLine(b == c);
            Console.WriteLine(b.Equals(c));
            Console.WriteLine("-----");

            Console.WriteLine(a1 == a2);
            Console.WriteLine(a1.Equals(a2));
            Console.WriteLine("-----");
        }
    }
}
