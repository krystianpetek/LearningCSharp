int[] tablicaLiczb = new int[100];

for (int i = 0; i < tablicaLiczb.Length; i++)
    tablicaLiczb[i] = Losowanie();

for (int x = 0; x < tablicaLiczb.Length; x++)
{
    int liczba = CzyPierwsza(tablicaLiczb[x]);
    if (liczba != 0)
        Console.WriteLine($"{liczba} występuje na {x} pozycji");
}

/// <summary>
/// Losuje liczby pseudolosowe
/// </summary>
/// <returns>Zwraca wylosowaną liczbę</returns>
static int Losowanie()
{
    Random losowanie = new Random();
    int wylosowana = losowanie.Next(2, 1000);
    return wylosowana;
}
/// <summary>
/// Sprawdza czy liczba jest pierwsza
/// </summary>
/// <param name="pierwsza">Liczba pierwsza</param>
/// <returns>Zwraca liczbę pierwszą</returns>
static int CzyPierwsza(int pierwsza)
{
    int licznik = 0;
    for (int i = 1; i < pierwsza - 1; i++)
        if (pierwsza % i == 0)
            licznik++;

    if (licznik > 1)
        return 0;
    else
        return pierwsza;
}