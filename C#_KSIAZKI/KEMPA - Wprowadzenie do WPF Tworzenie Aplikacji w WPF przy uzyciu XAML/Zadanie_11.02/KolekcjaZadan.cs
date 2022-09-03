using System.Collections.ObjectModel;

namespace Zadanie_11._02;

public class KolekcjaZadan : ObservableCollection<Zadanie>
{
    public KolekcjaZadan()
    {
        Add(new Zadanie
            {
                Nazwa = "Zamówienie",
                Opis = "Zamówić 100 długopisów żelowych",
                Priorytet = 1
            }
        );
        Add(new Zadanie
            {
                Nazwa = "Zaproszenie",
                Opis = "Zaprosić kontrahentów na pokaz nowego produktu",
                Priorytet = 2
            }
        );
        Add(new Zadanie
            {
                Nazwa = "Sprzątanie",
                Opis = "Posprzątać magazyn",
                Priorytet = 3
            }
        );
        
    }
}