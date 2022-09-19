static void Mnozenie(ref int[] tablica, int mnoznik)
{
    for (int i = 0; i < tablica.Length; i++)
    {
        tablica[i] = tablica[i] * mnoznik;
    }
}

static void MnozenieString(ref string[] tablica, int mnoznik)
{
    for (int i = 0; i < tablica.Length; i++)
    {
        string ciagMnozony = String.Empty;
        for (int j = 0; j < mnoznik; j++)
        {
            ciagMnozony += tablica[i];
            ciagMnozony += " ";
        }
        tablica[i] = ciagMnozony;
    }
}

int[] tabWejscie = { 1, 4, 6, 8, 2 };
string[] tabStringWejscie = { "ala", "kot", "dom" };
Mnozenie(ref tabWejscie, 5);
MnozenieString(ref tabStringWejscie, 3);
foreach (int a in tabWejscie)
    Console.Write($"{a} ");
Console.WriteLine("");
foreach (string x in tabStringWejscie)
    Console.WriteLine($"{x} ");