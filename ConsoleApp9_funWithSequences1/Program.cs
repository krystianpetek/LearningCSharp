using System;

namespace ConsoleApp9_funWithSequences1
{
    class Program
    {
        // Fun With Sequences Act1

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
                string wyswietl = "";
                for (int j = 0; j < Q.Length; j++)
                {
                    while (true)
                    {
                        if (j < Q.Length)
                        {
                            if (S[i] == Q[j])
                            {
                                i++;
                                continue;
                            }
                            else
                            j++;
                        }
                        else
                            break;
                    }
                    wyswietl += $"{S[i]} ";
                }
                wynik += wyswietl;
            }
            Console.WriteLine(wynik);
        }
    }
}
