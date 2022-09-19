static bool Sprawdzanie(double a, double b, double x)
{
    bool wynik = false;

    if (x > a && x < b)
        wynik = true;

    return wynik;
}

Console.WriteLine("Podaj A");
double a = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Podaj B");
double b = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Podaj X");
double x = Convert.ToDouble(Console.ReadLine());

bool wynik = Sprawdzanie(a, b, x);
if (wynik == true)
{
    Console.WriteLine($"Liczba {x} należy do przedziału obustronnie otwartego");
}
else
{
    Console.WriteLine($"Liczba {x} nie należy do przedziału obustronnie otwartego");
}