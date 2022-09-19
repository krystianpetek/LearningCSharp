static void FibIteracja(int n)
{
    if (n == 0 || n == 1)
        Console.WriteLine(n);
    else if (n > 1)
    {
        Console.WriteLine(0);
        Console.WriteLine(1);
        int fibSuma = 1;
        int fibSumaOdjac1 = 1;
        for (int i = 2; i < n; i++)
        {
            int temp = fibSuma;
            fibSuma = fibSuma + fibSumaOdjac1;
            fibSumaOdjac1 = temp;
            Console.WriteLine(fibSuma);
        }
    }
    else
    {
        Console.WriteLine("Błąd");
    }
}
static int FibRekurencja(int n, int liczba = 0)
{
    if (n == 0)
        return 0;
    else if (n == 1)
        return 1;
    else
        liczba = FibRekurencja(n - 1) + FibRekurencja(n - 2);
    return liczba;
}

Console.Write("Podaj liczbę ciągu Fibonacciego: ");
int n = int.Parse(Console.ReadLine());
Console.WriteLine("Iteracja:");
FibIteracja(n);
Console.WriteLine("Rekurencja:");
int rekurencja = FibRekurencja(n);
Console.WriteLine(rekurencja);