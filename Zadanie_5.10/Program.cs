static int Oblicz(int n)
{
    if (n <= 1) return (1);
    else return (n + Oblicz(n - 1));
}

Console.WriteLine(Oblicz(5));