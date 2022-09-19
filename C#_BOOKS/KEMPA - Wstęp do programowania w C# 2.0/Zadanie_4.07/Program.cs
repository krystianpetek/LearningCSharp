int[,] macierzA = new int[2, 3];
int[,] macierzB = new int[2, 3];

//Pętla przypisania Macierzy A
Console.WriteLine("Przypisanie wartości do macierzy A");
for (int A1 = 0; A1 < macierzA.GetLength(0); A1++)
{
    for (int A2 = 0; A2 < macierzA.GetLength(1); A2++)
    {
        Console.Write($"Podaj index A{A1 + 1}{A2 + 1} macierzy A: ");
        try
        {
            int a = int.Parse(Console.ReadLine());

            macierzA[A1, A2] = a;
        }
        catch (FormatException)
        {
            Console.WriteLine("Wartość inna niż liczba całkowita, wprowadź ponownie");
            A2--;
        }
    }
}
Console.WriteLine("Macierz A");
// Wyświetlenie macierzy A
for (int wyswietlA1 = 0; wyswietlA1 < macierzA.GetLength(0); wyswietlA1++)
{
    for (int wyswietlA2 = 0; wyswietlA2 < macierzA.GetLength(1); wyswietlA2++)
    {
        Console.Write($"[{macierzA[wyswietlA1, wyswietlA2]}]");
        if (wyswietlA2 == macierzA.GetLength(0))
            Console.WriteLine();
    }
}
//Pętla przypisania Macierzy B
Console.WriteLine("Przypisanie wartości do macierzy B");
for (int B1 = 0; B1 < macierzB.GetLength(0); B1++)
{
    for (int B2 = 0; B2 < macierzB.GetLength(1); B2++)
    {
        Console.Write($"Podaj index B{B1 + 1}{B2 + 1} macierzy B: ");
        try
        {
            int a = int.Parse(Console.ReadLine());

            macierzB[B1, B2] = a;
        }
        catch (FormatException)
        {
            Console.WriteLine("Wartość inna niż liczba całkowita, wprowadź ponownie");
            B2--;
        }
    }
}

//Wyświetlenie macierzy B
Console.WriteLine("Macierz B");
for (int wyswietlB1 = 0; wyswietlB1 < macierzB.GetLength(0); wyswietlB1++)
{
    for (int wyswietlB2 = 0; wyswietlB2 < macierzB.GetLength(1); wyswietlB2++)
    {
        Console.Write($"[{macierzB[wyswietlB1, wyswietlB2]}]");
        if (wyswietlB2 == macierzB.GetLength(0))
            Console.WriteLine();
    }
}

//Dodawanie macierzy (A + B) = C
int[,] macierzC = new int[2, 3];
for (int x = 0; x < macierzC.GetLength(0); x++)
{
    for (int y = 0; y < macierzC.GetLength(1); y++)
    {
        macierzC[x, y] = macierzA[x, y] + macierzB[x, y];
    }
}

// Wyswietlenie macierzy C = (A + B)
Console.WriteLine("\nMacierz C = A + B");
for (int wyswietlC1 = 0; wyswietlC1 < macierzC.GetLength(0); wyswietlC1++)
{
    for (int wyswietlC2 = 0; wyswietlC2 < macierzC.GetLength(1); wyswietlC2++)
    {
        Console.Write($"[{macierzC[wyswietlC1, wyswietlC2]}]");
        if (wyswietlC2 == macierzC.GetLength(0))
            Console.WriteLine();
    }
}