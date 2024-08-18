using System.Reflection;
using System.Text.RegularExpressions;

namespace AutoServiceTracking.Shared.Security.Xss;

public static class XssHelper
{
    private static readonly string JavaScriptPattern = @"<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>|on\w+=";

    public static void ContainsJavaScriptProperties<T>(T obj) where T : class
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            if (property.PropertyType == typeof(string))
            {
                var value = (string)property.GetValue(obj);
                if (value != null && ContainsJavaScript(value))
                {
                    throw new InvalidOperationException($"Property '{property.Name}' contains JavaScript code.");
                }
            }
        }
    }

    private static bool ContainsJavaScript(string input)
    {
        return Regex.IsMatch(input, JavaScriptPattern, RegexOptions.IgnoreCase);
    }
}