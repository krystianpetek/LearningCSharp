public class Pracownik
{
    public string nazwisko;
    private double zarobki;

    public double Zarobki
    {
        get // akcesor
        {
            return zarobki;
        }
        private set // akcesor
        {
            zarobki = value;
        }
    }

    public void PokazPracownika()
    {
        Console.WriteLine("{0,-15} {1,10}", nazwisko, Zarobki);
    }
}