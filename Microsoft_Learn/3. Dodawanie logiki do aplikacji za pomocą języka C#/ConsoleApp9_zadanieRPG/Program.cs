using System;

namespace ConsoleApp9_zadanieRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            // PRZYKLAD 1 (MOJ)
            int zycieGracza = 10;
            int zyciePotwora = 10;
            Random atakLos = new Random();
            int atak = atakLos.Next(1, 11);

            while(zycieGracza > 0 && zyciePotwora > 0)
            {
                atak = atakLos.Next(1, 11);
                zyciePotwora -= atak;
                Console.WriteLine($"Potwór został zaatakowany i stracił {atak} punkty zdrowia, teraz ma {zyciePotwora} punktów zdrowia.");

                if (zyciePotwora <= 0)
                {
                    Console.WriteLine("Gracz zwyciężył");
                    break;
                }

                atak = atakLos.Next(1, 11);
                zycieGracza -= atak;
                Console.WriteLine($"Bohater został zaatakowany i stracił {atak} punkty zdrowia, teraz ma {zycieGracza} punktów zdrowia.");
                
                if (zycieGracza <= 0)
                {
                    Console.WriteLine("Potwór zwyciężył");
                    break;
                }
            }

            // PRZYKLAD 2
            zycieGracza = 10;
            zyciePotwora = 10;
            do
            {
                atak = atakLos.Next(1, 11);
                zyciePotwora -= atak;
                Console.WriteLine($"Potwór został zaatakowany i stracił {atak} punkty zdrowia, teraz ma {zyciePotwora} punktów zdrowia.");
                if (zyciePotwora <= 0) continue;

                atak = atakLos.Next(1, 11);
                zycieGracza -= atak;
                Console.WriteLine($"Bohater został zaatakowany i stracił {atak} punkty zdrowia, teraz ma {zycieGracza} punktów zdrowia.");
                if (zycieGracza <= 0) continue;

            } while (zycieGracza > 0 && zyciePotwora > 0);
            Console.WriteLine(zycieGracza > 0 ? "Gracz zwyciężył" : "Potwór zwyciężył");
        }
    }
}
