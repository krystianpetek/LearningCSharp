using System;

namespace ConsoleApp10_funWithSequences2
{
    class Program
    {
        // Fun With Sequences Act2

        /* DANE WEJSCIOWE:
         * 5
         * -2 -1 0 1 4
         * 6
         * -3 -2 -1 1 2 3
         */

        static void Main(string[] args)
        {
            //Wczytaj S
            int iloscLiczbS = int.Parse(Console.ReadLine());
            string ciagLiczbS = Console.ReadLine();
            string[] S = ciagLiczbS.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (iloscLiczbS < 2 || iloscLiczbS > 100)
                throw new ArgumentException("Ilość liczb S musi być większa lub równa 2 i mniejsza od 100");

            //Wyczytaj Q
            int iloscLiczbQ = int.Parse(Console.ReadLine());
            string ciagLiczbQ = Console.ReadLine();
            string[] Q = ciagLiczbQ.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (iloscLiczbQ < 2 || iloscLiczbQ > 100)
                throw new ArgumentException("Ilość liczb Q musi być większa lub równa 2 i mniejsza od 100");

            string wynik = "";
            for (int i = 0; i < S.Length; i++)
            {
                for (int j = 0; j < Q.Length; j++)
                {
                    while (j < Q.Length && i<S.Length)
                    {
                        if (S[i] == Q[j])
                        {
                            wynik += $"{S[i]} ";
                            i++;
                        }
                        else
                            break;
                    }
                }
            }
            Console.WriteLine(wynik);
        }
    }
}
