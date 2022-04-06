internal struct Kwadrat
{
    private int bok;
    private ConsoleColor kolor;

    public Kwadrat(int bok1, ConsoleColor kolor1)
    {
        bok = bok1;
        kolor = kolor1;
    }

    public void RysujKwadrat()
    {
        Console.ForegroundColor = kolor;
        for (int i = 1; i <= bok; i++)
        {
            for (int j = 1; j <= bok; j++)

                Console.Write("*");
            Console.WriteLine();
        }
    }
}