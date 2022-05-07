namespace FactoryMethodOther;

public class WindowsButton : Button
{
    public override string Name { get; set; } = "Windows Button";
    public override string Description { get; set; } = "This class is for creating Windows Button";
    public override void Action()
    {
        Console.WriteLine(Name);
    }
}