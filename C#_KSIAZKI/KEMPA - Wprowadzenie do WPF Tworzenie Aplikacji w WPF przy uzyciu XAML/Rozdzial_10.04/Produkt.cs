namespace Rozdzial_10._04
{
    internal class Produkt
    {
        public Produkt()
        {
        }

        public string Symbol { get; set; }
        public string Nazwa { get; set; }
        public int LiczbaSztuk { get; set; }
        public string Magazyn { get; set; }

        public Produkt(string symbol, string nazwa, int liczbaSztuk, string magazyn)
        {
            Symbol = symbol;
            Nazwa = nazwa;
            LiczbaSztuk = liczbaSztuk;
            Magazyn = magazyn;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Symbol, Nazwa, LiczbaSztuk, Magazyn);
        }
    }
}