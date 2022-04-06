static int SumaCyfr(int liczba)
{
    char[] liczbaString = liczba.ToString().ToCharArray();
    liczba = 0;
    for (int i = 0; i < liczbaString.Length; i++)
    {
        liczba += int.Parse(liczbaString[i].ToString());
    }
    return liczba;
}
Console.Write("Wprowadź liczbę: ");
int liczba = Convert.ToInt32(Console.ReadLine());

Console.WriteLine(SumaCyfr(liczba));