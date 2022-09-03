Console.Write("Podaj współczynnik A: ");
double A = Convert.ToDouble(Console.ReadLine());
Console.Write("Podaj współczynnik B: ");
double B = Convert.ToDouble(Console.ReadLine());
Console.Write("Podaj współczynnik C: ");
double C = Convert.ToDouble(Console.ReadLine());

double delta = Math.Pow(B, 2) - (4 * A * C);
Console.WriteLine($"Delta jest równa: {Math.Round(delta, 2)}");