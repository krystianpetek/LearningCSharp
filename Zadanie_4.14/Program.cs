string[] tablica = new string[5];
for (int i = 0; i < tablica.Length; i++)
{
    tablica[i] = Console.ReadLine();
}

for (int j = 0; j < tablica.Length; j++)
{
    string[] tablica2 = tablica[j].Split("-", StringSplitOptions.RemoveEmptyEntries);
    Console.WriteLine($"Od daty zakupu {tablica2[0].ToUpper()} mineło {DateTime.Now.Year - int.Parse(tablica2[1])} lata");
}