namespace Zadanie_6._11
{
    internal static class Kalkulator
    {
        public static void Oblicz()
        {
            Console.Clear();
            var exitKalk = 0;
            while (exitKalk == 0)
            {
                Console.WriteLine("Podaj pierwszą liczbę: ");
                var x = int.Parse(Console.ReadLine());
                Console.WriteLine("Podaj drugą liczbę: ");
                var y = int.Parse(Console.ReadLine());
                Console.WriteLine("Podaj znak +  -  *  /");
                var z = Console.ReadLine();
                double wynik = 0;
                switch (z)
                {
                    case "+":
                        wynik = x + y;
                        Console.WriteLine($"Wynik: { wynik} ");
                        break;

                    case "-":
                        wynik = x - y;
                        Console.WriteLine($"Wynik: { wynik} ");
                        break;

                    case "*":
                        wynik = x * y;
                        Console.WriteLine($"Wynik: { wynik} ");
                        break;

                    case "/":
                        wynik = x / y;
                        Console.WriteLine($"Wynik: { wynik} ");
                        break;

                    default:
                        Console.WriteLine("Podaj prawidłowo dane");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
                exitKalk = 1;
            }
        }
    }
}