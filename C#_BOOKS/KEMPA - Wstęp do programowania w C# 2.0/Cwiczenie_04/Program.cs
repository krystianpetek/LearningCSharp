//Pracownik[] tab = new Pracownik[3];
//tab[0] = new Pracownik("Petek", 1250.0);
//tab[1] = new Pracownik("Zemlik", 1340.0);
//tab[2] = new Pracownik("Kosarski", 2210.0);

Pracownik[] tab = { new Pracownik("Petek", 1250.0),
                                new Pracownik("Zemlik", 1340.0),
                                new Pracownik("Kosarski", 2210.0)};

//foreach(Pracownik p in tab)
//    p.PokazPracownika();

for (int i = 0; i < tab.Length; i++)
    tab[i].PokazPracownika();

Console.WriteLine($"Suma {Pracownik.Sumuj(tab)}");