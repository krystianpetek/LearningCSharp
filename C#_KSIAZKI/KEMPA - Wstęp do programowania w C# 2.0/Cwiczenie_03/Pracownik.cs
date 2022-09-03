public class Pracownik
{
    public static int liczbaPrac;
    public string Nazwisko { get; set; }
    public double Zarobki { get; set; }

    public Pracownik(string naz, double zar)
    {
        liczbaPrac++;
        Nazwisko = naz;
        Zarobki = zar;
    }

    static Pracownik()
    {
        liczbaPrac = 0;
    }

    public void PokazPracownika()
    {
        Console.WriteLine("{0,-15} {1,10}", Nazwisko, Zarobki);
    }
}