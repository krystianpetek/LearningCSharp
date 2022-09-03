Console.WriteLine("Podaj wzor: a, b, c, d, e");
string wzor = Console.ReadLine();

Console.WriteLine("Wprowadź liczbę");

if (wzor == "a" || wzor == "A")
{
    int liczba = int.Parse(Console.ReadLine());
    for (int i = 1; i <= liczba; i++)
    {
        for (int j = 0; j < i; j++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }
    return;
}

if (wzor == "b" || wzor == "B")
{
    int liczba = int.Parse(Console.ReadLine());
    for (int i = liczba; i > 0; i--)
    {
        for (int j = i; j > 0; j--)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }
    return;
}

if (wzor == "c" || wzor == "C")
{
    int liczba = int.Parse(Console.ReadLine());
    for (int i = liczba; i >= 0; i--)
    {
        for (int j = i; j > 0; j--)
        {
            Console.Write(" ");
        }
        if (i != liczba)
            for (int k = i; k < liczba; k++)
            {
                Console.Write("*");
            }
        Console.WriteLine();
    }
    return;
}

if (wzor == "d" || wzor == "D")
{
    int liczba = int.Parse(Console.ReadLine());

    for (int i = 0; i <= liczba; i++)
    {
        for (int j = 0; j < i; j++)
        {
            Console.Write(" ");
        }
        if (i != liczba)
            for (int k = i; k < liczba; k++)
            {
                Console.Write("*");
            }
        Console.WriteLine();
    }
    return;
}

if (wzor == "e" || wzor == "E")
{
    int liczba = int.Parse(Console.ReadLine());

    for (int i = 0; i < liczba; i++)
        Console.Write("*");
    Console.WriteLine();

    for (int x = 1; x < liczba - 1; x++)
    {
        Console.Write("*");
        for (int i = 1; i < liczba - 1; i++)
        {
            Console.Write(" ");
        }
        Console.WriteLine("*");
    }

    for (int i = 0; i < liczba; i++)
    {
        Console.Write("*");
    }
}