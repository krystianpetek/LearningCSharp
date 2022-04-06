        MojaKlasa p1 = new MojaKlasa();
        p1.Dana = 5;
        MojaKlasa p2 = p1;
        Console.WriteLine("p1.Dana = {0}", p1.Dana);
        Console.WriteLine("p2.Dana = {0}", p2.Dana);
        p1.Dana = 8;
        Console.WriteLine();
        Console.WriteLine("Wartości po zmianie obiektu p1");
        Console.WriteLine("p1.Dana = {0}", p1.Dana);
        Console.WriteLine("p2.Dana = {0}", p2.Dana);
        Console.ReadKey();

