Console.WriteLine("Podaj swoją średnią");
double srednia = double.Parse(Console.ReadLine());
if (srednia < 2.0 | srednia > 5.0)
{
    Console.WriteLine("Nie kwalfikujesz się");
    return;
}
else if (srednia >= 2.0 & srednia < 4) Console.WriteLine("Kwota stypendium to: 0,00zł");
else if (srednia >= 4 && srednia < 4.8) Console.WriteLine("Kwota stypendium to: 350,00 zł");
else Console.WriteLine("Kwota stypendium to: 550,00zł");