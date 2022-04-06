internal class ZuzycieEnergii
{
    public ZuzycieEnergii(int poczatek, int biezacy)
    {
        PoczatkowyStan = poczatek;
        BiezacyStan = biezacy;
    }

    public int PoczatkowyStan
    {
        get;
        private set;
    }

    public int BiezacyStan
    {
        get;
        set;
    }

    public void WyswietlPoczatkowy()
    {
        Console.WriteLine($"Stan poczatkowy licznika: {PoczatkowyStan}");
    }

    public void WyswietlBiezacy()
    {
        Console.WriteLine($"Stan bieżący licznika: {BiezacyStan}");
    }

    public void ZuzytaEnergia()
    {
        Console.WriteLine($"Zużyta energia: {BiezacyStan - PoczatkowyStan}");
    }
}