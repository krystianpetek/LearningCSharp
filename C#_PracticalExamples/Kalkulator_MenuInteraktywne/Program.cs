using System;

namespace MenuInteraktywne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            string[] lista = new string[] { "1. Dodaj", "2. Odejmij", "3. Pomnóż", "4. Podziel", "5. Modulo" };
            bool[] listaBool = new bool[] { false, false, false, false, false };
            while (true)
            {
                for (int j = 0; j < listaBool.Length; j++)
                {
                    listaBool[j] = false;
                }
                listaBool[i] = true;

                Console.Clear();

                for (int a = 0; a < lista.Length; a++)

                {
                    if (listaBool[a])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(lista[a]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
                var x = Console.ReadKey();
                switch (x.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (i > 0)
                        {
                            i--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (i < 4)
                            i++;
                        break;

                    case ConsoleKey.Escape:
                        return;
                    default:
                        continue;
                }

            }

        }
    }
}
