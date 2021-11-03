using System;
using System.Collections.Generic;

namespace RefaktoryzacjaRefaktoryzacjiTautologia
{
    class Program
    {
        static void Main(string[] args)
        {
            string operatory = "CDIEN";
            int linia = int.Parse(Console.ReadLine());
            for (int i = 0; i < linia; i++)
            {
                string zdanie = Console.ReadLine();
                Console.WriteLine(Kierowniku(zdanie));
            }
        }
        public static string Kierowniku(string zdanie)
        {
            return Convert.ToString(Convert.ToInt32(Math.Pow(2, 2)),2);
        }
    }
}
