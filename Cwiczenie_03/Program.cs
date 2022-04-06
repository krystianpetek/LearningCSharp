
Console.WriteLine($"Liczba pracowników {Pracownik.liczbaPrac}");

Pracownik p1 = new Pracownik("Petek", 3300);
p1.Nazwisko = "Kowalski";
p1.Zarobki = 1250.0;
p1.PokazPracownika();

Pracownik p2 = new Pracownik("Nowak", 1340.0);
p2.PokazPracownika();

Console.WriteLine($"Liczba pracowników {Pracownik.liczbaPrac}");