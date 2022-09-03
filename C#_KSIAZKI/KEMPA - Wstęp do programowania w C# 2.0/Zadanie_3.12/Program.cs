int licznik = 0;
int liczba = 0;
do
{
    liczba = int.Parse(Console.ReadLine());
    licznik++;
}
while (liczba != 0);
Console.WriteLine($"Ilość wprowadzonych liczb: {licznik}");