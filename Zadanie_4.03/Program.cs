Console.Write("Podaj liczbę elementów tablicy: ");
int liczbN = int.Parse(Console.ReadLine());
Console.WriteLine($"Zadeklarowana wartość to {liczbN} liczb");

int[] tablicaLiczb = new int[liczbN];
int sumaSrednia = 0;
int sumaDodatnich = 0;
for (int i = 0; i < liczbN; i++)
{
    Console.Write($"Podaj {i + 1} liczbę: ");

    try
    {
        int liczba = int.Parse(Console.ReadLine());
        tablicaLiczb[i] = liczba;
        sumaSrednia += liczba;
        if (liczba > 0)
            sumaDodatnich++;
    }
    catch (Exception)
    {
        Console.Write("Wprowadzono błędną wartość, podaj ponownie");
        i--;
        Console.WriteLine();
    }
}
int sprawdzana = tablicaLiczb[0];
int indeksSprawdzana = 0;
for (int i = 1; i < tablicaLiczb.Length; i++)
{
    if (tablicaLiczb[i] > sprawdzana)
    {
        sprawdzana = tablicaLiczb[i];
        indeksSprawdzana = i;
    }
}

Console.WriteLine($"Wartość największego elementu tablicy to {sprawdzana} znajduje się na {indeksSprawdzana} pozycji.");

sprawdzana = tablicaLiczb[0];
indeksSprawdzana = 0;
for (int i = 1; i < tablicaLiczb.Length; i++)
{
    if (tablicaLiczb[i] < sprawdzana)
    {
        sprawdzana = tablicaLiczb[i];
        indeksSprawdzana = i;
    }
}

Console.WriteLine($"Wartość najmniejszego elementu tablicy to {sprawdzana} znajduje się na {indeksSprawdzana} pozycji.");

double srednia = sumaSrednia * 1.0 / liczbN;
Console.WriteLine($"Średnia liczb to: {srednia}");
Console.WriteLine($"Suma dodatnich liczb: {sumaDodatnich}");