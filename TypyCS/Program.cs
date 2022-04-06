using TypyCS;

Int32 r = 5;
Console.WriteLine(r);

var x = new
{
    imie = "Krystian",
    wiek = 23,
    pensja = 3300,
    zatrudniony = true
};


Console.WriteLine(x);
Console.WriteLine(x.GetType().ToString());

var osoba = ("Petek", 23, true);
var osoba2 = (nazwisko : "Petek", wiek: 23, zatrudniony: true);
Console.WriteLine($"nazwisko: {osoba.Item1}, wiek: {osoba.Item2}");
Console.WriteLine($"nazwisko: {osoba2.nazwisko}, wiek: {osoba2.wiek}");

(double lat, double lon) wspGeoFilipa17 = (50.068226, 19.941119);
Console.WriteLine($"{nameof(wspGeoFilipa17)}: {wspGeoFilipa17.lat}, {wspGeoFilipa17.lon}");


(int min, int max) MinMax(params int[] liczby)
{
    int minimum, maximum;
    minimum = maximum = liczby[0];
    foreach(int x in liczby)
    {
        if(x< minimum ) minimum = x;
        if(x> maximum ) maximum = x;
    }
    return (minimum, maximum);
}

(int A, int B) = MinMax(2, 1, 6, 3, 1);
Console.WriteLine($"minimum = {A}, maximum = {B}");

var (a, b) = MinMax(2, 1, 6, 3, 1);
Console.WriteLine($"minimum = {a}, maximum = {b}");

Ulamek ulamek = new Ulamek();
ulamek = 3;
Console.WriteLine(ulamek);

ulamek = new Ulamek(10,3);
Console.WriteLine((int)ulamek);