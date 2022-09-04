class Heater
{
    public Heater(float temp)
    {
        temperature = temp;
    }
    private float temperature { get; set; }
    public void OnTemperatureChanged(float temp)
    {
        if (temp < temperature)
            Console.WriteLine("Heater: On");
        else
            Console.WriteLine("Heater: Off");
    }
}
class Cooler
{
    public Cooler(float temp)
    {
        temperature = temp;
    }
    private float temperature { get; set; }

    public void OnTemperatureChanged(float temp)
    {
        if (temp > temperature)
            Console.WriteLine("Cooler: On");
        else
            Console.WriteLine("Cooler: Off");
    }
}
class Thermostat
{
    public Action<float>? OnTemperatureChange { get; set; }
    private float _CurrentTemperature { get; set; }
    public float CurrentTemperature
    {
        get { return _CurrentTemperature; }
        set
        {
            if (value != CurrentTemperature)
            {
                _CurrentTemperature = value;
                Action<float>? onTemperatureChange = OnTemperatureChange;

                if (onTemperatureChange != null)
                {
                    List<Exception> exceptionCollection = new List<Exception>();
                    foreach (Delegate handler in onTemperatureChange.GetInvocationList())
                    {
                        try
                        {
                            ((Action<float>)handler).Invoke(value);
                        }
                        catch (Exception ex)
                        {
                            exceptionCollection.Add(ex);
                        }
                    }
                    if (exceptionCollection.Count > 0)
                        throw new AggregateException("There were exceptions thrown by OnTemperatureChange Event subscribers.", exceptionCollection);
                }
            }
        }
    }
}
class Program
{
    static void MainOld()
    {
        Thermostat thermostat = new Thermostat();
        Heater heater = new Heater(60);
        Cooler cooler = new Cooler(80);

        Action<float> delegate1;
        Action<float> delegate2;
        Action<float>? delegate3;

        delegate1 = heater.OnTemperatureChanged;
        delegate2 = cooler.OnTemperatureChanged;

        Console.WriteLine("Invoke both delegates:");
        delegate3 = delegate1 + delegate2;
        delegate3(90);

        Console.WriteLine("Invoke only delegate2");
        delegate3 -= delegate1;
        delegate3!(30);
    }

    static void Main()
    {
        Thermostat thermostat = new Thermostat();
        Heater heater = new Heater(60);
        Cooler cooler = new Cooler(80);
        string temperature;

        thermostat.OnTemperatureChange += heater.OnTemperatureChanged;
        thermostat.OnTemperatureChange += cooler.OnTemperatureChanged;

        Console.WriteLine("Enter temperature:");
        temperature = Console.ReadLine();
        thermostat.CurrentTemperature = int.Parse(temperature);
    }
}