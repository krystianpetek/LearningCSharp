Console.WriteLine("Podaj liczbę całkowitą");
int liczba1 = int.Parse(Console.ReadLine());
Console.WriteLine("Podaj liczbę całkowitą");
int liczba2 = int.Parse(Console.ReadLine());

if (liczba1 % liczba2 == 0)
{
    Console.WriteLine($"{liczba2} jest dzielnikiem {liczba1}");
}
else
{
    Console.WriteLine($"{liczba2} nie jest dzielnikiem {liczba1}");
}