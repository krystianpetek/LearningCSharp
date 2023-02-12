using Advanced.Blazor;

namespace Advanced.Services;

public class ToggleService
{
    private List<MultiNavLink> components = new List<MultiNavLink>();
    private bool enabled = true;

    public void EnrolComponents(IEnumerable<MultiNavLink> navLinks)
    {
        components.AddRange(navLinks);
    }

    public bool ToggleComponents()
    {
        enabled = !enabled;
        components.ForEach( component => component.SetEnabled(enabled));
        return enabled;
    }
}
