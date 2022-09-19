Console.WriteLine("Wprowadz liczbe silni");
int silnia = int.Parse(Console.ReadLine());
int oblicz = 1;
for (int i = 1; i <= silnia; i++)
{
    oblicz = oblicz * i;
    Console.WriteLine($"Liczba: {i} {oblicz}!");
}