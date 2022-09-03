static double Temperatura(double fahrentheit)
{
    double celsjusz;

    celsjusz = (5.0 / 9) * (fahrentheit - 32);

    return celsjusz;
}

Console.WriteLine($"{Temperatura(Convert.ToDouble(Console.ReadLine()))} stopni Celsiusza");