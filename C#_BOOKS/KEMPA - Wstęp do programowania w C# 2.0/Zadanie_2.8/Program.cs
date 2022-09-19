bool x;
int y = 1, z = 1;
x = (y == 1 && z++ == 1);
Console.WriteLine($"{x} {y} {z}");