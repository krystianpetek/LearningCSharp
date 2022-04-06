internal class Prostopadloscian
{
    private double dlugosc;

    public double DL
    {
        get { return dlugosc; }
        set { dlugosc = value; }
    }

    private double szerokosc;

    public double SZ
    {
        get { return szerokosc; }
        set { szerokosc = value; }
    }

    private double wysokosc;

    public double WY
    {
        get { return wysokosc; }
        set { wysokosc = value; }
    }

    public Prostopadloscian(double x, double y, double z)
    {
        dlugosc = x;
        szerokosc = y;
        wysokosc = z;
    }

    public static void Porownaj(Prostopadloscian a, Prostopadloscian b)
    {
        double Va = a.dlugosc * a.szerokosc * a.wysokosc;
        double Vb = b.dlugosc * b.szerokosc * b.wysokosc;

        Console.WriteLine($"Objętość A = {Va}");
        Console.WriteLine($"Objętość B = {Vb}");
    }

    public double ObliczObjetosc()
    {
        return wysokosc * szerokosc * dlugosc;
    }
}