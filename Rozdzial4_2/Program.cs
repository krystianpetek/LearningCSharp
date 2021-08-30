using System;

namespace Rozdzial4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // WHILE NA PRZYKLADZIE LICZB FIBONACCIEGO
            decimal current, previous, temp, input;
            input = decimal.Parse(Console.ReadLine());
            current = previous = 1;

            while(current <= input)
            {
                temp = current;
                current = previous + current;
                previous = temp;
                Console.Write(temp + " ");
            }
            Console.WriteLine($"Następna liczba fibonacciego to {current}");

            // FOR
            for (int x = 0, y = 5; ((x <= 5) && (y >= 0)); y--, x++)
            {
                Console.Write($"{ x }{ ((x > y) ? '>' : '<')}{ y }\t");
            }

            // FOREACH
            char[] cells = {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
            Console.Write("Możliwe posunięcia to: ");
            // Wyświetlanie posunięć dopuszczalnych na początku.
            cells[1] = 'X';
            foreach (char cell in cells)
            {
                if (cell != 'O' && cell != 'X')
                {
                    Console.Write($"{ cell } ");
                }
            }
            Console.WriteLine();

            // SWITCH

            bool valid;
            Console.Write("Wprowadz liczbę: 1 - 9: ");
            string input2 = Console.ReadLine();
            switch (input2)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    valid = true;
                    Console.WriteLine("OK");
                    break;
                case "":
                case "quit":
                    valid = true;
                    break;
                default:
                    Console.WriteLine("BŁĄD: Wprowadź wartość z przedziału od 1 do 9. " + "Wciśnij ENTER, by zamknąć program");
                    break;
            }

            string email;
            bool domena = false;
            Console.Write("Wprowadź adres email: ");
            email = Console.ReadLine();
            Console.WriteLine("Domena adresu to: ");
            foreach (var x in email)
            {
                if (x == '@')
                {
                    domena = true;
                    continue;
                }

                if (domena == true)
                {
                    Console.Write($"{x}");
                }
                else
                    continue;
            }

            // DYREKTYWY PREPROCESORA - służą do kontroli kiedy i jak dołączany jest kod

            // #if #endif
            // #if #elif #endif
            // #if #else #endif
            // #define #undef #error #warning #pragma #line
            // #region #endregion
            // #line nowy-wiersz nowy-plik #line default
            // #nullable enable | disable | restore

#if DEBUG // wykluczenie kodu dla wersji C# 2.0 i nowszych ( GDY UZYWANY JEST KOMPILATOR C# 1.0)
            System.Console.Clear();
#endif

#if LINUX
// kod dla linuxa
#elif WINDOWS
// kod dla windowsa
#endif
            // Generowanie błędów i ostrzeżeń
#warning "Dozwolone jest wielokrotne wprowadzenie tego samego ruchu."

            // Wyłączanie komunikatów z ostrzeżeniami
#pragma warning disable CS1030
#pragma warning restore CS1030


        }

    }
}
