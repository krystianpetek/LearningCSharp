using System;

namespace DokumentacjaCSKlasy
{
    internal class Transakcje
    {
        public decimal kwota { get; }
        public DateTime dateTime { get; }
        public string notatka { get;}

        public Transakcje(decimal kwota, DateTime dateTime, string notatka)
        {
            this.kwota = kwota;
            this.dateTime = dateTime;
            this.notatka = notatka;
        }
    }
}