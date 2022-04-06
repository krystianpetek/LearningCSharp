string linia = Console.ReadLine();
string[] tablicaWyrazow = linia.Split(" ", StringSplitOptions.RemoveEmptyEntries);

Console.WriteLine($"Ilość wyrazów: {tablicaWyrazow.Length}");