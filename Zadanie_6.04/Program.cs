
Console.WriteLine("wprowadz poczatkowy stan licznika: ");
int poczatkowy = int.Parse(Console.ReadLine());
Console.WriteLine("wprowadz poczatkowy stan licznika: ");
int biezacy = int.Parse(Console.ReadLine());

ZuzycieEnergii nowa = new ZuzycieEnergii(poczatkowy, biezacy);
nowa.WyswietlPoczatkowy();
checked
{
    int x = int.Parse(Console.ReadLine());
    if (x > nowa.PoczatkowyStan)
    {
        nowa.BiezacyStan = x;
    }
    else
    {
        Console.WriteLine("Błędna wartosc");
        return;
    }
}

nowa.WyswietlBiezacy();
nowa.ZuzytaEnergia();