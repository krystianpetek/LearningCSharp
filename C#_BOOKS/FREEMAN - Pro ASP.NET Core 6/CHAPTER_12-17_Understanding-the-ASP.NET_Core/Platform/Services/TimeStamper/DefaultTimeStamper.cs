using Platform.Services.Interfaces;

namespace Platform.Services.TimeStamper;

public class DefaultTimeStamper : ITimeStamper
{
    public string TimeStamp => DateTime.Now.ToShortTimeString();
}
