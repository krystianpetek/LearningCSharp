Console.Write("Podaj wagę w kilogramach: ");
double waga = Convert.ToDouble(Console.ReadLine());
Console.Write("Podaj wzrost w metrach lub centymetrach: ");
string wczytajWzrost = Console.ReadLine();
if (wczytajWzrost.Contains(","))
{
    wczytajWzrost = wczytajWzrost.Replace(',', '.');
}

double wzrost = Convert.ToDouble(wczytajWzrost);
if (!wzrost.ToString().Contains("."))
{
    wzrost = wzrost / 100;
}
double BMI = waga / (Math.Pow(wzrost, 2));
Console.WriteLine($"Twój wskaźnik BMI wynosi: {Math.Round(BMI, 2)}");