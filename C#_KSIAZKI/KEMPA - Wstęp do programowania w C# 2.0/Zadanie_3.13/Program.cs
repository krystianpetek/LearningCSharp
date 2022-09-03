Console.Write("Podaj liczbę n: ");
int i = int.Parse(Console.ReadLine());
int x = 0;
int suma = 0;
while (x < i)
{
    x++;

    if (x % 2 == 1)
    {
        suma = suma + x;
    }
    else
        suma = suma - x;
    Console.WriteLine(x);
}
Console.WriteLine(suma);