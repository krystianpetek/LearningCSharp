using System;

namespace ConsoleApp15_StringLED
{
    class Kolorki
    {
        /// <summary>
        /// Funkcja przyjmuje ciąg znaków koloru i analizuje jaki kolor wybrać
        /// </summary>
        /// <returns>Zwraca kolor jakim ma być wypisany wynik</returns>
        public static ConsoleColor Kolor()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"\nblack");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($" blue");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($" cyan");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($" gray");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($" green");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($" magenta");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($" red");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" white");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" yellow\n");
            System.ConsoleColor kolorWyjscia = new ConsoleColor();

            Console.ForegroundColor = ConsoleColor.Gray;
            string kolor = Console.ReadLine().ToUpper();
            switch (kolor)
            {
                case "BLACK":
                    kolorWyjscia = ConsoleColor.Black;
                    break;
                case "BLUE":
                    kolorWyjscia = ConsoleColor.Blue;
                    break;
                case "CYAN":
                    kolorWyjscia = ConsoleColor.Cyan;
                    break;
                case "GRAY":
                    kolorWyjscia = ConsoleColor.Gray;
                    break;
                case "GREEN":
                    kolorWyjscia = ConsoleColor.Green;
                    break;
                case "MAGENTA":
                    kolorWyjscia = ConsoleColor.Magenta;
                    break;
                case "RED":
                    kolorWyjscia = ConsoleColor.Red;
                    break;
                case "WHITE":
                    kolorWyjscia = ConsoleColor.White;
                    break;
                case "YELLOW":
                    kolorWyjscia = ConsoleColor.Yellow;
                    break;
                default:
                    kolorWyjscia = ConsoleColor.Gray;
                    Console.WriteLine("Wprowadzono zły kolor, wybieram wartość domyślną");
                    break;
            }
            return kolorWyjscia;
        }
    }
}
