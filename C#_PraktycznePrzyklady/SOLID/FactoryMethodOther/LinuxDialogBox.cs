namespace FactoryMethodOther;

public class LinuxDialogBox : DialogBox
{
    public override Button CreateButton()
    {
        return new LinuxButton();
    }
}