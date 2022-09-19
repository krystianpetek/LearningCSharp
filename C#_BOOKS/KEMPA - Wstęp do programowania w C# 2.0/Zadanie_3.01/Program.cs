Console.WriteLine("podaj rok");
int rok = int.Parse(Console.ReadLine());

if (rok % 4 == 0 && rok % 100 != 0 || rok % 400 == 0)
{
    Console.WriteLine("Podany rok jest przestępny");
}
else Console.WriteLine("Podany rok nie jest przestępny");