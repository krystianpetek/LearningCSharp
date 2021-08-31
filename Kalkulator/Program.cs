using System;

namespace Kalkulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = int.Parse(Console.ReadLine());
            for (int x = 1; x <= i;x++)
            {
                string[] wejscie = Console.ReadLine().Split(" ");
                int? obliczenia = null;

                switch (wejscie[0])
                {
                    case "+":
                        obliczenia = int.Parse(wejscie[1]) + int.Parse(wejscie[2]);
                        break;
                    case "-":
                        obliczenia = int.Parse(wejscie[1]) - int.Parse(wejscie[2]);
                        break;
                    case "*":
                        obliczenia = int.Parse(wejscie[1]) * int.Parse(wejscie[2]);
                        break;
                    case "/":
                        obliczenia = int.Parse(wejscie[1]) / int.Parse(wejscie[2]);
                        break;
                    case "%":
                        obliczenia = int.Parse(wejscie[1]) % int.Parse(wejscie[2]);
                        break;
                }
                Console.WriteLine(obliczenia);
            }

        }
    }
}
