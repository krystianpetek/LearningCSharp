static void Rysuj(int dlugosc, int szerokosc, char znak)
{
    for (int x = 0; x < szerokosc; x++)
    {
        for (int y = 0; y < dlugosc; y++)
            Console.Write(znak);

        Console.WriteLine();
    }
}

Console.Write("Podaj długość: ");
int dlugosc = Convert.ToInt32(Console.ReadLine());
Console.Write("Podaj szerokość: ");
int szerokosc = Convert.ToInt32(Console.ReadLine());
Console.Write("Podaj znak: ");
char znak = Convert.ToChar(Console.ReadLine());

Rysuj(dlugosc, szerokosc, znak);
Console.WriteLine();
Rysuj(szerokosc, dlugosc, znak);