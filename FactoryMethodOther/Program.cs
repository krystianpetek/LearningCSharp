using FactoryMethodOther;

List<DialogBox> listDialogBoxes = new List<DialogBox>()
{
    new LinuxDialogBox(), new WindowsDialogBox(), new WindowsDialogBox()
};

foreach(DialogBox box in listDialogBoxes)
    box.CreateButton().Action();