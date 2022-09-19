Console.Write("Podaj liczbę elementów tablicy: ");
int liczbN = int.Parse(Console.ReadLine());
Console.WriteLine($"Zadeklarowana wartość to {liczbN} liczb");

int[] tab1 = new int[liczbN];
int[] tab2 = new int[liczbN];

for (int i = 0; i < tab1.Length; i++)
{
    try
    {
        tab1[i] = int.Parse(Console.ReadLine());
    }
    catch (Exception)
    {
        i--;
        Console.WriteLine("Zła wartość, wprowadz ponownie");
    }
}

for (int i = 0; i < tab1.Length; i++)
{
    if (i == tab1.Length - 1)
        tab2[0] = tab1[i];
    Array.Copy(tab1, 0, tab2, 1, tab1.Length - 1);
}

Console.WriteLine("Tablica 1: ");
foreach (int x in tab1)
    Console.Write($"{x} ");

Console.WriteLine();
Console.WriteLine("Tablica 2: ");
foreach (int x in tab2)
    Console.Write($"{x} ");