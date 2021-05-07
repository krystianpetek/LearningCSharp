using System;

namespace ConsoleApp15_StringLED
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj komunikat do wypisania: ");
            char[] ciag = Console.ReadLine().ToCharArray();
            Console.Write("Podaj znak którym będzie zapisany komunikat: ");
            char z = Console.ReadLine()[0];
            Console.Write("Podaj znak który będzie separatorem: ");
            char s = Console.ReadLine()[0];
            Console.Write("Podaj kolor w jakim ma się wyświetlić napis: ");
            System.ConsoleColor kolorWyjscia = Kolorki.Kolor();

            for (int x = 0; x < 7; x++)
            {
                for (int i = 0; i < ciag.Length; i++)
                {
                    char[] znak = Znaki.PrzypiszTablice(ciag[i], x, z, s);
                    for (int j = 0; j < 5; j++)
                    {
                        if (znak[j] == ' ')
                            j++;
                        if (znak[j] == z)
                        {
                            Console.ForegroundColor = kolorWyjscia;
                            if (kolorWyjscia == ConsoleColor.Black)
                                Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(znak[j]);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                            Console.Write(znak[j]);
                    }
                    Console.Write(s);
                }
                Console.WriteLine();
            }
        }
    }
}
