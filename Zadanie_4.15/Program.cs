string tekstWejsciowy = Console.ReadLine().ToUpper();
string haslo = "GADERYPOLUKI";
string zaszyfrowaneHaslo = string.Empty;
for (int i = 0; i < tekstWejsciowy.Length; i++)
{
    for (int znajdz = 0; znajdz < haslo.Length; znajdz++)
    {
        if (tekstWejsciowy[i] == haslo[znajdz])
        {
            if (znajdz % 2 == 0)
            {
                zaszyfrowaneHaslo += haslo[znajdz + 1];
                break;
            }
            else if (znajdz % 2 == 1)
            {
                zaszyfrowaneHaslo += haslo[znajdz - 1];
                break;
            }
        }
        else
            if (znajdz == haslo.Length - 1)
            zaszyfrowaneHaslo += tekstWejsciowy[i];
    }
}
Console.WriteLine(zaszyfrowaneHaslo);