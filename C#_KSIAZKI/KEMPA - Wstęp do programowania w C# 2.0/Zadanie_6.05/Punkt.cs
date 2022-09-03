internal class Punkt
{
    private double X { get; set; }
    private double Y { get; set; }

    public Punkt(double x, double y)
    {
        X = x;
        Y = y;
    }

    public void Przesun(double x, double y)
    {
        X = X + x;
        Y = Y + y;
        Console.WriteLine($"Przesunięcie punktu X o {x}");
        Console.WriteLine($"Przesunięcie punktu Y o {y}");
    }

    public void Wyswietl()
    {
        Console.WriteLine($"Punkt X: {X}");
        Console.WriteLine($"Punkt Y: {Y}");
    }
}