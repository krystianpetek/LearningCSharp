Console.WriteLine("Podaj wspołczynniki równania kwadratowego");
Console.WriteLine("Podaj A");
double a = double.Parse(Console.ReadLine());
Console.WriteLine("Podaj B");
double b = double.Parse(Console.ReadLine());
Console.WriteLine("Podaj C");
double c = double.Parse(Console.ReadLine());

double delta = Math.Pow(b, 2) - (4 * a * c);
if (delta > 0)
{
    Console.WriteLine("Równanie kwadratowe ma 2 pierwiastki");
}
else if (delta == 0)
{
    Console.WriteLine("Równanie kwadratowe ma 1 pierwiastek");
}
else
{
    Console.WriteLine("Równanie kwadratowe nie ma piewiastków");
}
Console.WriteLine(delta);