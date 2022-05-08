namespace Zadanie_11._02;

public class Zadanie
{
    public string Nazwa { get; set; }
    public string Opis { get; set; }
    public int Priorytet {get ; set; }
    public override string ToString()
    {
        return $"({Nazwa}) {Opis} Priority:{Priorytet}";
    }
}