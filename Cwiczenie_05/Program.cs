
MojaKlasa p1 = new MojaKlasa(5);

MojaKlasa p2 = new(p1);

Console.WriteLine($"p1.Dana = {p1.Dana}");
Console.WriteLine($"p2.Dana = {p2.Dana}");

p1.Dana = 8;

Console.WriteLine();
Console.WriteLine("Wartości po zmianie obiektu p1");

Console.WriteLine($"p1.Dana = {p1.Dana}");
Console.WriteLine($"p2.Dana = {p2.Dana}");