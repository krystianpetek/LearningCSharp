using System;

public class Program
{
    static void Main()
	{
		long t, n, ps, cut;
		t = long.Parse(Console.ReadLine());

		for(int i=0; i<t; i++)
        {
			ps = 1;
			cut = 0;
			n = long.Parse(Console.ReadLine());
			while (ps < n)
            {
				cut++;
				ps += cut;
            }
			Console.WriteLine($"{cut}\n");
		}
	}
}