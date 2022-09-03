string[,] dniTygodnia;
dniTygodnia = new string[7, 3]; // pamiętaj o zmianie rozmiaru tablicy

#region Polski

dniTygodnia[0, 0] = "poniedzialek";
dniTygodnia[1, 0] = "wtorek";
dniTygodnia[2, 0] = "środa";
dniTygodnia[3, 0] = "czwartek";
dniTygodnia[4, 0] = "piątek";
dniTygodnia[5, 0] = "sobota";
dniTygodnia[6, 0] = "niedziela";

#endregion Polski

#region Angielski

dniTygodnia[0, 1] = "monday";
dniTygodnia[1, 1] = "tuesday";
dniTygodnia[2, 1] = "wednesday";
dniTygodnia[3, 1] = "thursday";
dniTygodnia[4, 1] = "friday";
dniTygodnia[5, 1] = "saturday";
dniTygodnia[6, 1] = "sunday";

#endregion Angielski

#region Niemiecki

dniTygodnia[0, 2] = "montag";
dniTygodnia[1, 2] = "dienstag";
dniTygodnia[2, 2] = "mittwoch";
dniTygodnia[3, 2] = "donnerstag";
dniTygodnia[4, 2] = "freitag";
dniTygodnia[5, 2] = "samstag";
dniTygodnia[6, 2] = "sonntag";

#endregion Niemiecki

Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}\n", "polski", "angielski", "niemiecki"));
for (int i = 0; i < dniTygodnia.GetLength(0); i++)
{
    for (int j = 0; j < dniTygodnia.GetLength(1); j++)
    {
        Console.Write(String.Format("{0,-15}", dniTygodnia[i, j]));
    }
    Console.WriteLine();
}