string tekst = "Kiedy idzie się po miód z balonikiem, to trzeba się starać, " +
                            "żeby pszczoły nie wiedziały, po co się idzie – odpowiedział Puchatek";

string[] podzielone = tekst.Split(" ", StringSplitOptions.RemoveEmptyEntries);
for (int i = 0; i < podzielone.Length; i++)
{
    string linia = podzielone[i];
    int licznik = 0;
    for (int j = 0; j < podzielone.Length; j++)
    {
        if (linia == "")
            continue;
        if (linia == podzielone[j])
        {
            podzielone[j] = "";
            licznik++;
        }
    }
    if (licznik > 1)
        Console.Write($"{linia} - {licznik} razy, ");
}