public class Pracownik
{
    private string nazwisko;
    private double zarobki;

    public Pracownik(string naz, double zar)
    {
        nazwisko = naz;
        zarobki = zar;
    }

    public override string ToString()
    {
        return String.Format($"{nazwisko,-15} {zarobki,10}");
    }
}