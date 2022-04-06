KandydatNaStudia[] tablica = new KandydatNaStudia[]
            {
                new KandydatNaStudia("Petek",75,68,52),
                new KandydatNaStudia("Merek",53,12,13),
                new KandydatNaStudia("Warchał",3,1,2.5),
                new KandydatNaStudia("Nieznajomy",100,100,100)};

foreach (var x in tablica)
    x.Oblicz();