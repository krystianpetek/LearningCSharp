using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_12._02
{
    public class Towar : IDataErrorInfo
    {
        public string Nazwa { get; set; }
        public double Cena { get; set; }

        public string Error { get; }

        public string this[string nazwaWlasciwosciTowaru]
        {
            get
            {
                string komunikat = string.Empty;
                switch (nazwaWlasciwosciTowaru)
                {
                    case "Nazwa":
                        if (string.IsNullOrEmpty(Nazwa))
                            komunikat = "Nazwa musi być wpisana";
                        else if (Nazwa.Length < 3)
                            komunikat = "Nazwa musi mieć minimum 3 znaki!";
                        break;
                    case "Cena":
                        if ((Cena < 0.1) || (Cena > 1000))
                            komunikat = "Cena musi być z zakresu od 0,10 do 1000";
                        break;
                }

                return komunikat;
            }
        }
    }
}
