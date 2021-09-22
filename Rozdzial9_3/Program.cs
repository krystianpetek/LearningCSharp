using System;

namespace Rozdzial9_3
{

    // PRZECIĄŻAJ operatory równości (Equals(), == i !=) w typach bezpośrednich, jeśli sprawdzanie równości jest istotne.

    // OPAKOWYWANIE
    class DisplayFibonacci
    {
        static void Main()
        {
            int totalCount;
            // Celowo używany jest typ ArrayList, aby zilustrować opakowywanie
            System.Collections.ArrayList list =
            new System.Collections.ArrayList();
            Console.Write("Wprowadź liczbę z przedziału od 2 do 1000:");
            totalCount = int.Parse(Console.ReadLine());
            if (totalCount == 7) // „Magiczna” liczba używana w testach
            {
                // Błąd czasu wykonania:
                // list.Add(0); // Potrzebne jest rzutowanie na typ double lub przyrostek 'D'.
                // Niezależnie od wybranego rozwiązania
                // kod CIL jest identyczny.
            }
            else
            {
                list.Add((double)0);
            }
            list.Add((double)0);
            list.Add((double)1);
            for (int count = 2; count < totalCount; count++)
            {
                list.Add(
                    (double)list[count - 1]! +
                    (double)list[count - 2]!);
            }
            foreach (double count in list)
            {
                Console.Write("{0}, ", count);
            }
        }
        // ZLE DZIALA
    }
}
