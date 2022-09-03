string[] miesiace = new string[13];

#region MIESIACE

miesiace[1] = "styczeń";
miesiace[2] = "luty";
miesiace[3] = "marzec";
miesiace[4] = "kwiecień";
miesiace[5] = "maj";
miesiace[6] = "czerwiec";
miesiace[7] = "lipiec";
miesiace[8] = "sierpień";
miesiace[9] = "wrzesień";
miesiace[10] = "październik";
miesiace[11] = "listopad";
miesiace[12] = "grudzień";

#endregion MIESIACE

Console.WriteLine("Podaj datę w formacie DD-MM-RRRR");
var data = Console.ReadLine();

//if (data != String.Format("{00-00-0000}", data))
// Console.WriteLine("tak");

string[] rozbicieDaty = data.Split("-", StringSplitOptions.RemoveEmptyEntries);

int sprawdzMiesiac = Convert.ToInt32(rozbicieDaty[1]);

for (int i = 1; i < miesiace.Length; i++)
{
    if (sprawdzMiesiac == i)
        Console.WriteLine(miesiace[i]);
}