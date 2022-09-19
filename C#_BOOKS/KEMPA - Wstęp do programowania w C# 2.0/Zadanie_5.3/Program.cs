static void Przesun(ref double a1, ref double a2, double wek1, double wek2)
{
    a1 += wek1;
    a2 += wek2;
}

Console.Write("Podaj współrzędne punktu A: ");
string[] wspolrzedneA = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
double A1 = Convert.ToDouble(wspolrzedneA[0]);
double A2 = Convert.ToDouble(wspolrzedneA[1]);
string wek = "3, 2";
string[] wspolrzedneWek = wek.Split(",", StringSplitOptions.RemoveEmptyEntries);
double Wek1 = Convert.ToDouble(wspolrzedneWek[0]);
double Wek2 = Convert.ToDouble(wspolrzedneWek[1]);
Przesun(ref A1, ref A2, Wek1, Wek2);

Console.WriteLine($"{A1}, {A2}");