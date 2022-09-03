double[,] tablica5na5 = new double[5, 5];
Console.WriteLine("Dlugość tablicy to: " + tablica5na5.Length + "\n");

for (int i = 0; i < tablica5na5.GetLength(0); i++)

    for (int j = 0; j < tablica5na5.GetLength(1); j++)
    {
        tablica5na5[i, j] = (new Random()).Next(1, 10);

        if (i == j)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        Console.Write("[" + tablica5na5[i, j] + "]");

        if (i == j)
        {
            Console.ResetColor();
        }

        if (j == tablica5na5.GetLength(1) - 1)
            Console.WriteLine();
    }

Console.WriteLine("\nSuma przekątnej to: ");
double suma = 0;
for (int a = 0; a < tablica5na5.GetLength(0); a++)
{
    for (int b = 0; b < tablica5na5.GetLength(1); b++)
        if (b == a)
        {
            suma = suma + tablica5na5[a, b];
        }
}
Console.WriteLine(suma);