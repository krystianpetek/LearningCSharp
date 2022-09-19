namespace FactoryMethodOther;

public class LinuxButton : Button
{
    public override string Name { get; set; } = "Linux Button";
    public override string Description { get; set; } = "This class is for creating Linux Button";
    public override void Action()
    {
        Console.WriteLine(Name);
    }
}