var A = new Prostopadloscian(1, 6, 4);
var B = new Prostopadloscian(6, 4.21, 9);

Console.WriteLine(A.ObliczObjetosc());
Console.WriteLine(B.ObliczObjetosc());

B.SZ = 4.5;

Prostopadloscian.Porownaj(A, B);