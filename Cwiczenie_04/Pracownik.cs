public class Pracownik
{
    public string Nazwisko { get; set; }
    public double Zarobki { get; set; }

    public Pracownik(string naz, double zar)
    {
        Nazwisko = naz;
        Zarobki = zar;
    }

    public void PokazPracownika()
    {
        Console.WriteLine($"{Nazwisko.PadRight(10)} {Zarobki}");
    }

    public static double Sumuj(Pracownik[] tab)
    {
        double suma = 0;
        for (int i = 0; i < tab.Length; i++)
        {
            suma += tab[i].Zarobki;
        }
        return suma;
    }
}