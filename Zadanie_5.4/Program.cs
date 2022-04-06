static int[] MnozenieZwrot(int[] tablica, int mnoznik)
{
    int[] wynik = new int[tablica.Length];
    for (int i = 0; i < tablica.Length; i++)
    {
        wynik[i] = tablica[i] * mnoznik;
    }
    return wynik;
}

static void MnozenieWynik(ref int[] tablica, int mnoznik)
{
    for (int i = 0; i < tablica.Length; i++)
    {
        tablica[i] = tablica[i] * mnoznik;
    }
}

int[] tabWejscie = { 1, 4, 6, 8, 2 };
Console.Write("Podaj mnożnik: ");
int mnoznik = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("SPOSOB 1");
int[] wynik = MnozenieZwrot(tabWejscie, mnoznik);
foreach (int i in wynik)
    Console.Write($"{i} ");

Console.WriteLine("\nSPOSOB 2");
MnozenieWynik(ref tabWejscie, mnoznik);
foreach (int a in tabWejscie)
    Console.Write($"{a} ");