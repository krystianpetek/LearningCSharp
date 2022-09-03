internal struct Prostokat
{
    private int Dlugosc { get; set; }
    private int Szerokosc { get; set; }

    public Prostokat(int x, int y)
    {
        Dlugosc = x;
        Szerokosc = y;
    }

    private double powierzchnia()
    {
        return Dlugosc * Szerokosc;
    }

    private double obwod()
    {
        return Dlugosc * 2 + Szerokosc * 2;
    }

    public void Prezentuj()
    {
        Console.WriteLine($"Obwód prostokąta: {obwod()}");
        Console.WriteLine($"Powierzchnia prostokąta: {powierzchnia()}");
    }
}