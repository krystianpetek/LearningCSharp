public class MojaKlasa
{
    public int Dana { get; set; }

    public MojaKlasa(int d) // konstruktor
    {
        this.Dana = d;
    }

    public MojaKlasa(MojaKlasa kopia) // kopiujący konstruktor
    {
        this.Dana = kopia.Dana;
    }
}