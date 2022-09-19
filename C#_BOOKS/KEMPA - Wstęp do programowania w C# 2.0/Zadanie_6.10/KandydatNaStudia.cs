internal struct KandydatNaStudia
{
    private string nazwisko;
    double punktyMatematyka { get; set; }
    double punktyInformatyka { get; set; }
    double punktyJezykObcy { get; set; }

    public KandydatNaStudia(string nazwisko, double M, double I, double O)
    {
        this.nazwisko = nazwisko;
        this.punktyMatematyka = M;
        this.punktyInformatyka = I;
        this.punktyJezykObcy = O;
    }

    public void Oblicz()
    {
        double oblicz = punktyMatematyka * 0.6 + punktyInformatyka * 0.5 + punktyJezykObcy * 0.2;
        Console.WriteLine($"Nazwisko: {this.nazwisko}, liczba punktów: {oblicz}");
    }
}