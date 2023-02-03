using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApp.Validation;

public static class ModelStateExtensions
{
    public static void PromotePropertyErrors(this ModelStateDictionary modelState, string propertyName)
    {
        foreach (var error in modelState)
        {
            if (error.Key == propertyName && error.Value.ValidationState == ModelValidationState.Invalid)
            {
                foreach (var e in error.Value.Errors)
                {
                    modelState.AddModelError(string.Empty, e.ErrorMessage);
                }
            }
        }
    }
}
