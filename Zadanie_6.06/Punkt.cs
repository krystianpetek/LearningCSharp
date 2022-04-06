internal class Punkt
{
    private double X { get; set; }
    private double Y { get; set; }

    public Punkt(double x, double y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return "X: " + X + "".PadRight(5) + "Y: " + Y;
    }

    public static void CzyNaProstej(Punkt[] tablica)
    {
        double AB = (tablica[1].Y - tablica[0].Y) / (tablica[1].X - tablica[0].X);
        double AC = (tablica[2].Y - tablica[0].Y) / (tablica[2].X - tablica[0].X);
        double BC = (tablica[2].Y - tablica[1].Y) / (tablica[2].X - tablica[1].X);

        if (AB == AC && AB == BC)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Punkty leżą na jednej prostej");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Punkty nie leżą na jednej prostej");
        }
    }
}