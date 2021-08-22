using System;
using System.Diagnostics;

namespace Rozdzial4
{
    class Program
    {
        static void Main(string[] args)
        {
            // OPERATORY

            int difference = 4 - 2;
            decimal debt = -26457079712930.80M;
            int licznik, mianownik, iloraz, reszta;
            Console.WriteLine("Wprowadź licznik: ");
            licznik = int.Parse(Console.ReadLine());
            Console.WriteLine("Wprowadź mianownik: ");
            mianownik = int.Parse(Console.ReadLine());
            iloraz = licznik / mianownik;
            reszta = licznik % mianownik;
            Console.WriteLine($"{licznik} / {mianownik} = {iloraz}, reszta {reszta}");

            short predkoscWiatru = 42;
            Console.WriteLine($"Pierwszy most Tacoma w Waszyngtonie został\nzniszczony przez wiatr wiejący z prędkością {predkoscWiatru} mil na godzinę");

            int n = '3' + '4';
            char c = (char)n;
            Console.WriteLine(c);

            int distance = 'f' - 'c';
            Console.WriteLine(distance);

            decimal decimalNumber = 4.2M;
            double doubleNumber1 = 0.1F * 42F;
            double doubleNumber2 = 0.1D * 42D;
            float floatNumber = 0.1F * 42F;
            Trace.Assert(decimalNumber != (decimal)doubleNumber1);
            Console.WriteLine($"{decimalNumber} != {(decimal)doubleNumber1}");
            Trace.Assert((double)decimalNumber != doubleNumber1);
            Console.WriteLine($"{(double)decimalNumber} != {doubleNumber1}");
            Trace.Assert((float)decimalNumber != floatNumber);
            Console.WriteLine($"(float){(float)decimalNumber}M != {floatNumber}F");
            // Trace.Assert(doubleNumber1 != (double)floatNumber);
            Console.WriteLine($"{doubleNumber1} != {(double)floatNumber}");
            Trace.Assert(doubleNumber1 != doubleNumber2);
            Console.WriteLine($"{doubleNumber1} != {doubleNumber2}");
            Trace.Assert(floatNumber != doubleNumber2);
            Console.WriteLine($"{floatNumber}F != {doubleNumber2}D");
            Trace.Assert((double)4.2F != 4.2D);
            Console.WriteLine($"{(double)4.2F} != {4.2D}");
            Trace.Assert(4.2F != 4.2D);
            Console.WriteLine($"{4.2F}F != {4.2D}D");

            // UNIKAJ w instrukcjach warunkowych porównań wartości binarnych typów
            // zmiennoprzecinkowych.Powinieneś albo odjąć od siebie dwie wartości i sprawdzić,
            // czy różnica między nimi jest mniejsza niż wartość progowa, albo zastosować
            // typ decimal.

            float N = 0f;
            Console.WriteLine(N / 0); // dzielenie float przez 0 zawsze daje NaN
                                      // to samo w przypadku System.Math.Sqrt(-1) pierwiastek z ujemnej liczby daje NaN

            Console.WriteLine(-1f / 0); // Wyświetla: –Infinity
            Console.WriteLine(3.402823E+38f * 2f); // Wyświetla: Infinity


            // ZŁOŻONE OPERATORY PRZYPISANIA
            int x = 123;
            x = x + 2;
            x += 2;
            x -= 2;
            x /= 2;
            x *= 2;
            x %= 10;
            Console.WriteLine(x);
            // INKREMENATACJA I DEKREMENTACJA
            int spaceCount = 10;
            spaceCount = spaceCount + 1;
            spaceCount += 1;
            spaceCount++;

            // DEKREMENTACJA W PĘTLI
            char current;
            current = 'z';
            do
            {
                Console.Write($"{current} = {(int)current} ");
                current--;
            } while (current >= 'a');

            Console.WriteLine(); // Wypisanie UNICODE w FOR
            for (int i = 0;i<255;i++) // UNICODE
            {
                Console.Write($"{(char)i} ");    
            }

            Console.WriteLine();// POST i PRE inkrementacja
            int count = 123;
            int result;
            result = count++;
            Console.WriteLine($"result = {result} i count = {count}");
            result = ++count;
            Console.WriteLine($"result = {result} i count = {count}");
            
            //144
        }
    }
}
