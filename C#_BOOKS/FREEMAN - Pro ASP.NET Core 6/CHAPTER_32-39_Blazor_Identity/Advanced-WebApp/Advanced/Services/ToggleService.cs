using Advanced.Blazor;
using Microsoft.JSInterop;

namespace Advanced.Services;

public class ToggleService
{
    private readonly List<MultiNavLink> components = new List<MultiNavLink>();
    private bool enabled = true;

    public void EnrolComponents(IEnumerable<MultiNavLink> navLinks)
    {
        components.AddRange(navLinks);
    }

    [JSInvokable]
    public bool ToggleComponents()
    {
        enabled = !enabled;
        components.ForEach( component => component.SetEnabled(enabled));
        return enabled;
    }
}
