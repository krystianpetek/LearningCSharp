namespace Zadanie_7._02
{
    internal class Produkt
    {
        public string Symbol { get; set; }
        public string Nazwa { get; set; }
        public int LiczbaSztuk { get; set; }
        public string Magazyn { get; set; }

        public Produkt()
        { }

        public Produkt(string symbol, string nazwa, int liczbaSztuk, string magazyn)
        {
            Symbol = symbol;
            Nazwa = nazwa;
            LiczbaSztuk = liczbaSztuk;
            Magazyn = magazyn;
        }

        public override string ToString()
        {
            return $"{Symbol} {Nazwa} {LiczbaSztuk} {Magazyn}";
        }
    }
}