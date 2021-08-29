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


            // 179
        }

    }
}
