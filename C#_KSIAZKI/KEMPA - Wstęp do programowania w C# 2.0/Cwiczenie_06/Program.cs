DateTime t1 = DateTime.Now;
Console.WriteLine($"Czas początkowy t1: {t1}");
int licznik = 0;
for (int i = 0; i < int.MaxValue; i++)
    licznik++;

Console.WriteLine($"Wartość zmiennej licznik: {licznik}");

DateTime t2 = DateTime.Now;

Console.WriteLine($"Czas końcowy t2: {t2}");
Console.WriteLine($"Róznica t2-t1: {t2 - t1}");
Console.WriteLine($"Dziś jest {t1.DayOfYear} dzień roku");