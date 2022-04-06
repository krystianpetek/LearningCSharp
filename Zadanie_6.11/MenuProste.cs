using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_6._11
{
    internal class MenuProste
    {
        public static void StartMenuProste()
        {
            Console.Title = "Proste menu";

            while (true)
            {
                Console.Clear();
                Console.WriteLine(">>> Wybierz jedną z opcji od 1-4 lub ESC aby zakończyć <<<");
                Console.WriteLine("1 - Kalkulator");
                Console.WriteLine("2 - BMI");
                Console.WriteLine("3 - Liczby Doskonałe");
                Console.WriteLine("4 - Koniec");

                ConsoleKeyInfo klawisz = Console.ReadKey();
                switch (klawisz.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            Console.Clear();
                            Kalkulator.Oblicz();
                            break;
                        }
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            Console.Clear();
                            BMI.Oblicz();
                            break;
                        }
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        {
                            Console.Clear();
                            Console.Write("Opcja w budowie!");
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.Escape:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default: break;
                }
            }
        }
    }
}
