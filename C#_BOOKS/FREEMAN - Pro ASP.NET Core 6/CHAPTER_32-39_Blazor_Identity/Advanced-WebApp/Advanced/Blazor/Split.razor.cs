using Advanced.Models;
using Microsoft.AspNetCore.Components;

namespace Advanced.Blazor;

public partial class Split
{
    [Inject]
    public DataContext? DataContext { get; set; }

    public IEnumerable<string> Names => DataContext?.People.Select(person => person.Firstname) ?? Enumerable.Empty<string>();
}
