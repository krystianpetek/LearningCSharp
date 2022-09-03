// 1.
int[][] tab1 = new int[][] { new int[2], new int[4], new int[3] };

// 2.
int[][] tab2 = new int[3][];
tab2[0] = new int[2];
tab2[1] = new int[4];
tab2[2] = new int[3];

// 3.
int[][] tab3 = { new int[] { 1, 2 }, new int[] { 3, 4, 5, 6 }, new int[] { 7, 8, 9 } };
Console.WriteLine("Wartosci tablicy postrzępionej: ");
Console.WriteLine(tab3[0][0]);
Console.WriteLine(tab3[1][2]);
Console.WriteLine(tab3[2][2]);
Console.WriteLine("Dlugosc tablic: ");
Console.WriteLine(tab3[0].Length);
Console.WriteLine(tab3[1].Length);
Console.WriteLine(tab3[2].Length);

Console.WriteLine();
// 4.
int[][][] tab4 =
    {
                new int[][]
                    {
                        new int[] {1,2},
                        new int[] {3,4,5 }
                    }
            };
Console.WriteLine(tab4[0][1][2]);

Console.WriteLine();
// 5.
int[][,] tab5 = {
                new int[,] {
                    { 1, 2 }, { 3, 4 }
                },
                new int [,]
                {
                    {5,6,7 },{8,9,10 }
                }
            };
Console.WriteLine(tab5[1][0, 2]);

Console.WriteLine();
// 6.
int[][] tab6 =
    {
                new int[] { 1, 2 }, new int[] {3,4,5,6}, new int[] { 7, 8, 9 }
            };

foreach (int[] podtablica in tab6)
{
    foreach (int x in podtablica)
    {
        Console.WriteLine($"{x,2}");
    }
}

//7.
string[][] zespoly =
{
                new string[] {"Adam","Karol"},
                new string[] {"Ola","Ela","Jan"}
            };
Console.WriteLine();
for (int i = 0; i < zespoly.Length; i++)
{
    for (int j = 0; j < zespoly[i].Length; j++)
    {
        Console.WriteLine($"{zespoly[i][j]}");
    }
    Console.WriteLine();
}

// 8.
int[] a = { 11, 22, 33, 44, 55, 66, 77, 88, 99 };
int[] b = new int[10];
Array.Copy(a, 2, b, 3, 5);

foreach (int x in b)
{
    Console.Write($"{x}, ");
}

Console.WriteLine();

// 9.
int[] tab7 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
Array.Reverse(tab7);
foreach (int x in tab7)
{
    Console.Write($"{x} ");
}

Console.WriteLine();

//10.
int[] tab8 = { 4, 2, 6, 23, 1, 3, 7, 0 };
Array.Sort(tab8);
for (int i = 0; i < tab8.Length; i++)
{
    Console.WriteLine(tab8[i]);
}
Console.WriteLine();

// 11.
string[] imiona = { "ala", "ola", "ela", "tola", "ela" };
Console.WriteLine(Array.IndexOf(imiona, "ela"));
Console.WriteLine(Array.IndexOf(imiona, "iza"));
Console.WriteLine(Array.LastIndexOf(imiona, "ola"));

// 12.
char[] tab = { 'p', 'r', 'o', 'g', 'r', 'a', 'm' };
String nowy = new String(tab);
Console.WriteLine(nowy);

// 13.
string tekst = "Ala ma kota";
Console.WriteLine(tekst[0]);
Console.WriteLine(tekst[4]);
Console.WriteLine(tekst[7]);

// 14.
tekst = "Ala nie ma kota";
foreach (char litera in tekst)
    Console.WriteLine(litera);

// 15.
tekst = "Halko, dzwoni Twoja dupa po jebanko";
string odwrocony = "";
for (int i = tekst.Length - 1; i >= 0; i--)
{
    odwrocony += tekst[i];
}
Console.WriteLine(odwrocony);

// 16.
tekst = "Olo może mieć wpierdolo";
int liczbaZnakow = 0;
foreach (char litera in tekst)

    if (litera == 'o')
        liczbaZnakow++;
Console.WriteLine($"Litera o wystąpiła {liczbaZnakow} razy");

// 17.
tekst = "Ala ma kota";
string fragment;
fragment = tekst.Substring(4, 6);
Console.WriteLine(fragment);

// 18.
int wynik;
string tekst1 = "Kowalski";
string tekst2 = "Nowak";
wynik = tekst1.CompareTo(tekst2);
Console.WriteLine(wynik);

// 19.
string tekst3 = "nowak";
wynik = String.Compare(tekst2, tekst3, true);
Console.WriteLine(wynik);

// 20.
string tekstSklejony;
tekst1 = "Ala ma kota";
tekst2 = " i psa";
tekstSklejony = String.Concat(tekst1, tekst2);
Console.WriteLine(tekstSklejony);

// 21.
tekst = "być albo nie być";
Console.WriteLine(tekst.IndexOf("być", 1));

// 22.
tekst = "być albo nie być";
Console.WriteLine(tekst);
Console.WriteLine("szukany tekst \"być\" jest na pozycjach: ");

for (int i = 0; i < tekst.Length; i++)
{
    if (tekst[i] == 'b')
        if (tekst[i + 1] == 'y')
            if (tekst[i + 2] == 'ć')
            {
                Console.Write($"{i} ");
                i = i + 3;
            }
}
Console.WriteLine();
// 23.
tekst = "Ala ma kota";
string nowyTekst;
nowyTekst = tekst.Insert(7, "kanarka i ");
Console.WriteLine(nowyTekst);

static void tabliceDwuwymiarowe()
{
    int[,] tablica2d = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

    Console.WriteLine(tablica2d[2, 0]);
    Console.WriteLine(tablica2d[2, 1]);
    Console.WriteLine(tablica2d[1, 1]);
    Console.WriteLine();

    foreach (int x in tablica2d)
        Console.WriteLine(x);
    Console.ReadKey();

    Console.WriteLine();
    for (int a = 0; a < tablica2d.GetLength(0); a++)
    {
        for (int b = 0; b < tablica2d.GetLength(1); b++)
        {
            Console.Write($"{tablica2d[a, b]} ");
        }
        Console.WriteLine();
    }
}