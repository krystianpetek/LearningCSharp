Console.WriteLine("Podaj wagę w kg");
double waga = double.Parse(Console.ReadLine());
Console.WriteLine("Podaj wzrost w metrach");
double wzrost = double.Parse(Console.ReadLine());

double BMI = waga / (Math.Pow(wzrost, 2));

if (BMI < 18.5)
{
    if (BMI < 16.0) Console.WriteLine("Wygłodzenie");
    else if (BMI >= 16.0 && BMI < 17.0) Console.WriteLine("Wychudzenie");
    else Console.WriteLine("Niedowaga");
}
else if (BMI >= 25.0)
    if (BMI < 30)
        Console.WriteLine("Nadwaga");
    else if (BMI >= 30.0 && BMI < 35)
        Console.WriteLine("Otyłość I stopnia");
    else if (BMI >= 35 && BMI < 40)
        Console.WriteLine("Otyłość II stopnia");
    else Console.WriteLine("Otyłość III stopnia");
else
    Console.WriteLine("Wartość prawidłowa");