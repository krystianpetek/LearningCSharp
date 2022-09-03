int licznik = 0;
for (int i = 1; i < 100; i++)
{
    i = i + i; licznik++;
    Console.WriteLine($"Wartość: {i} za {licznik} razem");
}