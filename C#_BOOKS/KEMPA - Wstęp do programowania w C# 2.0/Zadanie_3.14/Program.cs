Console.WriteLine("Podaj liczbę");
int i = int.Parse(Console.ReadLine());

while (i != 1)
{
    int suma = i;
    int liczba = i / 2;
    while (liczba > 0)
    {
        if (i % liczba == 0)
            suma -= liczba;
        liczba--;
    }
    if (suma == 0)
        Console.WriteLine(i);
    i--;
}