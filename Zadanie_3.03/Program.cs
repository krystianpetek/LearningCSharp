Console.WriteLine("Podaj 3 liczby");
int liczba1 = int.Parse(Console.ReadLine());
int liczba2 = int.Parse(Console.ReadLine());
int liczba3 = int.Parse(Console.ReadLine());
int wieksza = (liczba1 > liczba2) ? liczba1 : liczba2;
if (wieksza > liczba3) Console.WriteLine($"Najwieksza liczba to {wieksza}");
else Console.WriteLine($"Najwieksza liczba to {liczba3}");