namespace FactoryMethodOther;

public class WindowsDialogBox : DialogBox
{
    public override Button CreateButton()
    {
        return new WindowsButton();
    }
}