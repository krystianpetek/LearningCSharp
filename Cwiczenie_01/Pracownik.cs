public class Pracownik
{
    public string nazwisko;
    private double zarobki;

    public Pracownik(string n, double z)
    {
        nazwisko = n;
        zarobki = z;
    }

    public void PokazPracownika()
    {
        Console.WriteLine("{0,-15} {1}", nazwisko, zarobki);
    }
}