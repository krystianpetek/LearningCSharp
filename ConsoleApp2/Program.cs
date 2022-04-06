static int silnia(int x)
{
    if (x <= 1) return 1;
    else
        return x * silnia(x - 1);
}
Console.WriteLine(silnia(7) - silnia(4));