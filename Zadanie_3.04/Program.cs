Console.WriteLine("Podaj liczbę pierwszą");
double liczba1 = double.Parse(Console.ReadLine());
Console.WriteLine("Podaj liczbę drugą");
double liczba2 = double.Parse(Console.ReadLine());
Console.WriteLine("Co chcesz zrobić? + - * / ?");
char znak = char.Parse(Console.ReadLine());
double wynik = 0;
switch (znak)
{
    case '+':
        wynik = liczba1 + liczba2;
        break;

    case '-':
        wynik = liczba1 - liczba2;
        break;

    case '*':
        wynik = liczba1 * liczba2;
        break;

    case '/':
        wynik = liczba1 / liczba2;
        break;
}

Console.WriteLine(wynik);