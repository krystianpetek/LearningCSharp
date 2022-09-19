char[] ciag = Console.ReadLine().ToCharArray();
for (int i = 0; i < ciag.Length; i++)
{
    int licznikZnakow = 0;
    char znak = ciag[i];
    if (!Char.IsLetterOrDigit(znak))
        continue;
    for (int j = 0; j < ciag.Length; j++)
    {
        if (znak == ciag[j])
        {
            licznikZnakow++;
            ciag[j] = ' ';
        }
    }
    Console.Write($"{znak} - {licznikZnakow}, ");
}