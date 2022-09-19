
public class DoorEvent : EventArgs
{
    public DoorEvent(bool drzwiOtwarte)
    {
        this.drzwiOtwarte = drzwiOtwarte;
    }
    public bool drzwiOtwarte { get; set; } = false;
}

class Door
{
    public delegate void DoorChangeState(object sender, DoorEvent doorEvent);
    public event EventHandler<DoorEvent> ChangeDoorState;

    protected virtual void OnDoorStateChanged()
    {
        if (ChangeDoorState != null)
        {
            ChangeDoorState(this, new DoorEvent(_otwarteDrzwi));
        }
    }
    public bool OtwarteDrzwi
    {
        get
        {
            return _otwarteDrzwi;
        }
        set
        {
            if (value != _otwarteDrzwi)
            {
                _otwarteDrzwi = value;
                OnDoorStateChanged();
            }
        }
    }
    private bool _otwarteDrzwi = false;
}

class Phone
{
    bool _door = false;
    public void PowiadomienieODrzwiach(object sender, DoorEvent doorEvent)
    {
        if (doorEvent.drzwiOtwarte != _door)
        {
            _door = doorEvent.drzwiOtwarte;
            Console.WriteLine($"Drzwi otwarte: {_door}");
        }
    }

    public static void Main()
    {
        Door door = new Door();
        Phone phone = new Phone();
        door.ChangeDoorState += phone.PowiadomienieODrzwiach;

        door.OtwarteDrzwi = true;
    }
}