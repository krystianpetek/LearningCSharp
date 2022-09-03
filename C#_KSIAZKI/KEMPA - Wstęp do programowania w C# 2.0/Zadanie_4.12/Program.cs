string tekst = "W parę godzin później, gdy noc zbierała się do odejścia,\n" +
                            "Puchatek obudził się nagle z uczuciem dziwnego przygnębienia.\n" +
                            "To uczucie dziwnego przygnębienia miewał już nieraz i wiedział,\n" +
                            "co ono oznacza. Był głodny. Więc poszedł do spiżarni,\n" +
                            "wgramolił się na krzesełko, sięgnął na górną półkę, ale nic nie znalazł.";

string[] TEKST = tekst.Split("\n");
int i;
for (i = 0; i < TEKST.Length; i++)
{
    Console.WriteLine(TEKST[i]);
    int licznik = 0;
    for (; licznik < TEKST[i].Length; licznik++) ;
    Console.WriteLine($"Liczba znaków: {licznik}");
}
Console.WriteLine($"\nLiczba wierszy: {i}");