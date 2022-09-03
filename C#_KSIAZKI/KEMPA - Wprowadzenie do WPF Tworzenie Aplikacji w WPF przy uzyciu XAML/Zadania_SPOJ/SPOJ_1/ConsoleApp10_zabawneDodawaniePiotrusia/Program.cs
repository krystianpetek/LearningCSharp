using System;

namespace ConsoleApp10_zabawneDodawaniePiotrusia
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int liczba = int.Parse(Console.ReadLine());
                if (liczba > 0 && liczba < 81)
                {
                    int dlugoscLiczby = liczba.ToString().Length;
                    string dobraLiczba = liczba.ToString();
                    string odwroconaLiczba = "";
                    for (int x = dlugoscLiczby - 1; x > -1; x--)
                    {
                        odwroconaLiczba += dobraLiczba[x];
                    }
                    if (dobraLiczba == odwroconaLiczba)
                        Console.WriteLine($"{dobraLiczba} 0");
                    else
                    {
                        int licznikOdwrocen = 0;
                        while (dobraLiczba != odwroconaLiczba)
                        {
                            liczba = Convert.ToInt32(dobraLiczba) + Convert.ToInt32(odwroconaLiczba);
                            dlugoscLiczby = liczba.ToString().Length;
                            dobraLiczba = liczba.ToString();
                            odwroconaLiczba = "";
                            for (int x = dlugoscLiczby - 1; x > -1; x--)
                            {
                                odwroconaLiczba += dobraLiczba[x];
                            }

                            licznikOdwrocen++;
                            Console.WriteLine($"{dobraLiczba} {licznikOdwrocen}");
                        }
                    }
                }
                else
                    Console.WriteLine("BŁĄD");
            }
        }
    }
}
