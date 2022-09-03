using System;

namespace ConsoleApp13_stringMerge
{
    class Program
    {
        public static void stringMerge(char[] pierwszyCiag, char[] drugiCiag)
        {
            string wynik = "";
            int dlugoscTablic;
            if (pierwszyCiag.Length > drugiCiag.Length)
                dlugoscTablic = drugiCiag.Length;
            else
                dlugoscTablic = pierwszyCiag.Length;
            for (int x = 0; x < dlugoscTablic; x++)
                wynik += pierwszyCiag[x].ToString() + drugiCiag[x].ToString();
            Console.WriteLine(wynik);
        }
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                string linia = Console.ReadLine();
                string[] wejscie = linia.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                char[] pierwszyCiag = wejscie[0].ToCharArray();
                char[] drugiCiag = wejscie[1].ToCharArray();

                stringMerge(pierwszyCiag, drugiCiag);
            }
        }
    }
}
