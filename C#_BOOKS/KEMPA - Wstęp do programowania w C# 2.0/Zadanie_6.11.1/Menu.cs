internal static class Menu
{
    private static string[] pozycjeMenu = { "Kalkulator", "BMI", "Liczby doskonałe", "Koniec", "Opcja 5", "Koniec" };
    private static int aktywnaPozycjaMenu = 0;

    public static void StartMenu()
    {
        Console.Title = "Sztuczki C#";
        Console.CursorVisible = false;
        while (true)
        {
            PokazMenu();
            WybieranieOpcji();
            UruchomOpcje();
            Console.ReadKey();
        }
    }

    private static void PokazMenu()
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(">> Sztuczki i kruczki C# <<<");
        Console.WriteLine();
        for (int i = 0; i < pozycjeMenu.Length; i++)
        {
            if (i == aktywnaPozycjaMenu)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0,-35}", pozycjeMenu[i]);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else
            {
                Console.WriteLine(pozycjeMenu[i]);
            }
        }
    }

    private static void WybieranieOpcji()
    {
        do
        {
            ConsoleKeyInfo klawisz = Console.ReadKey();
            if (klawisz.Key == ConsoleKey.UpArrow)
            {
                aktywnaPozycjaMenu = (aktywnaPozycjaMenu > 0) ? aktywnaPozycjaMenu - 1 : pozycjeMenu.Length - 1;
                PokazMenu();
            }
            else if (klawisz.Key == ConsoleKey.DownArrow)
            {
                aktywnaPozycjaMenu = (aktywnaPozycjaMenu + 1) % pozycjeMenu.Length;
                PokazMenu();
            }
            else if (klawisz.Key == ConsoleKey.Escape)
            {
                aktywnaPozycjaMenu = pozycjeMenu.Length - 1;
                break;
            }
            else if (klawisz.Key == ConsoleKey.Enter)
                break;
        } while (true);
    }

    private static void UruchomOpcje()
    {
        switch (aktywnaPozycjaMenu)
        {
            case 0: Console.Clear(); Kalkulator.Oblicz(); break;
            case 1: Console.Clear(); BMI.Oblicz(); break;
            case 2: Console.Clear(); LiczbyDoskonale.opcjaWBudowie(); break;
            case 3: Console.Clear(); Environment.Exit(0); break;
        }
    }
}