internal class Odcinek
{
    public static double MyProperty { get; set; }

    public Odcinek(Punkt[] tab)
    {
        MyProperty = Math.Sqrt(Math.Pow(tab[1].X - tab[0].X, 2) + Math.Pow(tab[1].Y - tab[0].Y, 2));
    }

    public static void Wynik()
    {
        Console.WriteLine(MyProperty);
    }
}