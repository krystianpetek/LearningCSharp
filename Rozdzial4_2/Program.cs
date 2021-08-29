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
        
            
        }

    }
}
