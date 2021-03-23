using System;

namespace ThirdAPP_Decision
{
    class Program
    {
        static void Main(string[] args)
        {
            string wiadomosc = "Szybki brązowy lis przeskakuje nad leniwym psem.";
            bool rezultat = wiadomosc.Contains("psem");
            Console.WriteLine(rezultat);

            if(wiadomosc.Contains("lis"))
            {
                Console.WriteLine("Co mówi lis?\n");
            }

            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Random kostka = new Random();
            int rzut1 = kostka.Next(1, 7);
            int rzut2 = kostka.Next(1, 7);
            int rzut3 = kostka.Next(1, 7);
            int wynik = rzut1 + rzut2 + rzut3;
            
            /*
            //Losowanie do momentu wylosowania
            int licznik = 0;
            do
            {
                licznik++;
                rzut1 = kostka.Next(1, 7);
                rzut2 = kostka.Next(1, 7);
                rzut3 = kostka.Next(1, 7);
                wynik = rzut1 + rzut2 + rzut3;
                Console.WriteLine($"Losowanie numer: {licznik} wynik: {wynik}");
            } while (wynik != 18);
            */

            if ((rzut1 == rzut2) || (rzut2 == rzut3) || (rzut3 == rzut1))
            {
                if ((rzut1 == rzut2) && (rzut2 == rzut3))
                {
                    Console.WriteLine($"Wylosowano:\n{rzut1}\n{rzut2}\n{rzut3}");
                    Console.WriteLine("BONUS: 6\n");
                    wynik += 6;
                }
                else
                {
                    Console.WriteLine($"Wylosowano:\n{rzut1}\n{rzut2}\n{rzut3}");
                    Console.WriteLine("BONUS: 2\n");
                    wynik += 2;

                }
            }
            else
            {
                Console.WriteLine($"Wylosowano:\n{rzut1}\n{rzut2}\n{rzut3}\n");
            }

            if (wynik >= 16)
            {
                Console.WriteLine($"Suma: {wynik}, Wygrałeś samochód!");
            }
            else if(wynik >= 10)
            {
                Console.WriteLine($"Suma: {wynik}, Wygrałeś laptopa!");
            }
            else if(wynik == 7)
            {
                Console.WriteLine($"Suma: {wynik}, Wygrałeś wycieczkę!");
            }
            else
            {
                Console.WriteLine($"Suma: {wynik}, Wygrałeś nagrodę pocieszenia, czyli nic");
            }
        }
    }
}
