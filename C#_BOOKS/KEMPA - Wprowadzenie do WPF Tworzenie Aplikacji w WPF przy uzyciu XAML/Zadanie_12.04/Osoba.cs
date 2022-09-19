using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Zadanie_12._04;

public class Osoba :IDataErrorInfo
{
    public string Nazwisko { get; set; }
    public string Imiona { get; set; }
    public string Pesel { get; set; }
    public string KodPocztowy { get; set; }

    public string Error { get; }

    public string this[string nazwaWlasciwosciOsoby]
    {
        get
        {
            string komunikat = String.Empty;

            switch (nazwaWlasciwosciOsoby)
            {
                case "Nazwisko":
                    if (string.IsNullOrEmpty(Nazwisko))
                        komunikat = "Nazwisko musi być wpisane!";
                    else if (!Regex.IsMatch(Nazwisko, "^[A-Z][a-z]+(-[A-Z][a-z]+){0,2}$"))
                        komunikat = "Nazwisko z dużej litery i minimum 2 znaki!";
                    break;
                case "Imiona":
                    if (string.IsNullOrEmpty(Imiona))
                        komunikat = "Należy wpisać imię lub imiona!";
                    else if (!Regex.IsMatch(Imiona, "^[A-Z][a-z]+(\\s[A-Z][a-z]+)*$"))
                        komunikat = "Imiona z dużej literi i minimum 2 znaki";
                    break;

                case "Pesel":
                    if(String.IsNullOrEmpty(Pesel))
                        komunikat = "Pesel musi być wpisany!";
                    else if (!Regex.IsMatch(Pesel, "^\\d{11}$"))
                        komunikat = "Numer PESEL musi mieć 11 znaków";
                    break;
                case "KodPocztowy":
                    if (string.IsNullOrEmpty(KodPocztowy))
                        komunikat = "Kod pocztowy musi być wpisany!";
                    else if (!Regex.IsMatch(KodPocztowy, "^[0-9]{2}-[0-9]{3}$"))
                        komunikat = "Kod pocztowy ma mieć format 00-000";
                    break;
            }
            return komunikat;
        }
    }
}