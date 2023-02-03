using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Validation;

public class PrimaryKeyAttribute : ValidationAttribute
{
    public Type? ContextType { get; set; }
    public Type? DataType { get; set; }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(ContextType != null && DataType != null)
        {
            DbContext? dbContext = validationContext.GetRequiredService(ContextType) as DbContext;

            if (dbContext != null && dbContext.Find(DataType, value) == null)
                return new ValidationResult(ErrorMessage ?? "Enter an existing key value");
        }

        return ValidationResult.Success;
    }
}
