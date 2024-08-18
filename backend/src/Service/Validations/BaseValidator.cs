using FluentValidation;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Service.Validations;

public abstract class BaseValidator<T> : AbstractValidator<T>
{
    private static readonly string JavaScriptPattern = @"<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>|on\w+=";

    protected BaseValidator()
    {
        ApplyJavaScriptValidationToStringProperties();
    }

    private void ApplyJavaScriptValidationToStringProperties()
    {
        // Get all properties of the model
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // Apply validation to all string properties
        foreach (var property in properties)
        {
            if (property.PropertyType == typeof(string))
            {
                // Create a rule for each string property
                RuleFor(x => (string)property.GetValue(x))
                    .Must(value => !ContainsJavaScript(value))
                    .WithMessage($"{property.Name} Javascript kodu olmamalı.");
            }
        }
    }

    private bool ContainsJavaScript(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return false;
        }

        // Use Regex to check if the string contains JavaScript patterns
        return Regex.IsMatch(value, JavaScriptPattern, RegexOptions.IgnoreCase);
    }
}
