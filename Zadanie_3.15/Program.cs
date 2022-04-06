int wyplata = 10;
int jeden = 1;
int dwa = 2;
int trzy = 5;

for (int x = 0; x <= 10; x++)
{
    for (int y = 0; y <= 5; y++)
    {
        for (int z = 0; z <= 2; z++)
        {
            if (x * 1 + y * 2 + z * 5 == 10)
            {
                Console.WriteLine($"złotowka {x} dwojka {y} piatka {z}");
            }
        }
    }
}