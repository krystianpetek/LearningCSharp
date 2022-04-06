Console.Write("Podaj temperaturę w stopniach Celsjusza:");
string wejscie = Console.ReadLine();
if (wejscie.Contains(","))
{
    wejscie = wejscie.Replace(',', '.');
}
double celsjusz = Convert.ToDouble(wejscie);
double fahrenheit = (celsjusz * 9) / 5 + 32;
Console.WriteLine("Temperatura w Fahrenheitach: " + Math.Round(fahrenheit, 2));