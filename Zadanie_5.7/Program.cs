static void Oblicz(double x, double n)
{
    double wynik = 0;
    for (int i = 1; i <= n; i++)
    {
        wynik += (x + i);
    }
    Console.WriteLine($"Wynik: {wynik}");
}

Console.WriteLine("Podaj liczbę x");
double x = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Podaj liczbę n");
double n = Convert.ToDouble(Console.ReadLine());

Oblicz(n: n, x: x);
Console.WriteLine();
Oblicz(x, n);