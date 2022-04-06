Punkt[] tablica = new Punkt[2];
Console.WriteLine("Podaj współrzędną X punktu A: ");
double x = double.Parse(Console.ReadLine());
Console.WriteLine("Podaj współrzędną Y punktu A: ");
double y = double.Parse(Console.ReadLine());
tablica[0] = new Punkt(x, y);
Console.WriteLine("Podaj współrzędną X punktu B: ");
x = double.Parse(Console.ReadLine());
Console.WriteLine("Podaj współrzędną Y punktu B: ");
y = double.Parse(Console.ReadLine());
tablica[1] = new Punkt(x, y);

var Odcinek = new Odcinek(tablica);
Odcinek.Wynik();