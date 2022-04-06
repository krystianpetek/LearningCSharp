Punkt[] tablica = new Punkt[3];
for (int i = 0; i < 3; i++)
{
    Console.WriteLine("Podaj x i y");
    double x = double.Parse(Console.ReadLine());
    double y = double.Parse(Console.ReadLine());
    tablica[i] = new Punkt(x, y);
}
foreach (var x in tablica)
    Console.WriteLine(x.ToString());

Console.WriteLine();
Punkt.CzyNaProstej(tablica);