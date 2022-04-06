int[] tab1 = new int[] { 1, -2, 3, -4, 5, -6, 7, -8, 9, -10 };
int[] tab2 = new int[10];

for (int i = 0; i < tab1.Length; i++)
{
    if (tab1[i] > 0)
    {
        tab2[i] = tab1[i];
    }
}
foreach (int t in tab2)
{
    Console.Write($"{t} ");
}
int x = 0;
tab2 = new int[10];

for (int i = 0; i < tab1.Length; i++)
{
    if (tab1[i] > 0)
    {
        tab2[x] = tab1[i];
        x++;
    }
}

Console.WriteLine();
Console.WriteLine();
foreach (int t in tab2)
{
    Console.Write($"{t} ");
}