using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zadanie_12._05
{
    public class Produkt : IDataErrorInfo
    {
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
        
        public string Error{

            get
            {
                string komunikat = string.Empty;
                if (Symbol.Substring(0, 1) == "A" && LiczbaSztuk < 10)
                    komunikat = "Wymagana liczba produktów o symbolu A to mininum 10";
                return komunikat;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string komunikat = "";

                switch (columnName)
                {
                    case "Symbol":
                        if (string.IsNullOrEmpty(Symbol))
                            komunikat = "Podaj symbol";
                        else if (!Regex.IsMatch(Symbol,"^[A-Z][A-Z0-9]-[0-9]{2}$"))
                        //else if (!Regex.IsMatch(Symbol,"^[A-Z](\\d|\\w)-\\d\\d+$"))
                            komunikat = "Nieprawidłowy symbol";
                        break;
                    case "LiczbaSztuk":
                        if (LiczbaSztuk < 0 || LiczbaSztuk > 10000)
                            komunikat = "Zakres od 0 do 10000";
                        break;
                }

                return komunikat;
            }
        }
    }
}
