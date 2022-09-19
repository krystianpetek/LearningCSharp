internal class Prostokat
{
    private double dlugosc { get; set; }
    private double szerokosc { get; set; }
    public static int i = 1;

    public Prostokat(double dl, double sz)
    {
        dlugosc = dl;
        szerokosc = sz;
    }

    private string Powierzchnia()
    {
        double oblicz = dlugosc * szerokosc;
        return $"Powierzchnia prostokąta: {Math.Round(oblicz, 2)}";
    }

    private string Obwod()
    {
        double oblicz = dlugosc * 2 + szerokosc * 2;
        return $"Obwód prostokąta: {Math.Round(oblicz, 2)}";
    }

    public void Prezentuj()
    {
        Console.WriteLine($"{i}. {Obwod()}\n{i}. {Powierzchnia()}");
        Console.WriteLine();
        i++;
    }
}