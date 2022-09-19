internal static class BMI
{
    public static void Oblicz()
    {
        Console.Clear();
        Console.WriteLine("Podaj wagę(kg): ");
        double x = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj wzrost(cm): ");
        double y = int.Parse(Console.ReadLine());
        double oblicz = x / ((y / 100) * (y / 100));
        Console.WriteLine($"Twoje BMI to: {oblicz:F2}");
    }
}