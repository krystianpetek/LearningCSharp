Console.Write("Podaj liczbę elementów tablicy: ");
int liczbN = int.Parse(Console.ReadLine());
Console.WriteLine($"Zadeklarowana wartość to {liczbN} liczb");

int[] tablicaLiczb = new int[liczbN];

for (int i = 0; i < liczbN; i++)
{
    Console.Write($"Podaj {i + 1} liczbę: ");

    try
    {
        int liczba = int.Parse(Console.ReadLine());
        tablicaLiczb[i] = liczba;
    }
    catch (Exception)
    {
        Console.Write("Wprowadzono błędną wartość, podaj ponownie");
        i--;
        Console.WriteLine();
    }
}
Console.WriteLine("W tablicy liczb przechowywane są wartości: ");
foreach (int x in tablicaLiczb)
{
    Console.Write($"{x} ");
}