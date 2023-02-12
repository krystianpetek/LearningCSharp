using Advanced.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Advanced.Blazor.Forms;

public class DeptStateValidator : OwningComponentBase<DataContext>
{
    public DataContext OwnDataContext => Service;

    [Parameter]
    public long DepartmentId { get; set; }

    [Parameter]
    public string? State { get; set; }

    [CascadingParameter]
    public EditContext? CurrentEditContext { get; set; }

    private string? DeptName { get; set; }
    private IDictionary<long, string>? LocationStates { get; set; }

    protected override void OnInitialized()
    {
        if(CurrentEditContext != null)
        {
            ValidationMessageStore store = new ValidationMessageStore(CurrentEditContext);
            CurrentEditContext.OnFieldChanged += (object? sender, FieldChangedEventArgs fieldChangedEventArgs) =>
            {
                string name = fieldChangedEventArgs.FieldIdentifier.FieldName;
                if(name == "DepartmentId" || name == "LocationId")
                {
                    Validate(CurrentEditContext.Model as Person, store);
                }
            };
        }
    }

    protected override void OnParametersSet()
    {
        DeptName = OwnDataContext.Departments.Find(DepartmentId)?.Name;
        LocationStates = OwnDataContext.Locations.ToDictionary(location => location.LocationId, location => location.State);
    }

    private void Validate(Person? person, ValidationMessageStore store)
    {
        if(person?.DepartmentId == DepartmentId &&
                LocationStates != null &&
                (!LocationStates.ContainsKey(person.LocationId) || 
                LocationStates[person.LocationId] != State))
        {
            store.Add(CurrentEditContext!.Field("LocationId"), $"{DeptName} staff must be in: {State}");
        }
        else
        {
            store.Clear();
        }
        CurrentEditContext?.NotifyValidationStateChanged();
    }
}
