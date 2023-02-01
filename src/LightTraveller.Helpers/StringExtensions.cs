using System.Diagnostics.CodeAnalysis;

namespace LightTraveller.Helpers;

public static class StringExtensions
{
    public static bool Empty([NotNullWhen(false)] this string? str) => string.IsNullOrWhiteSpace(str);

    public static bool NotEmpty([NotNullWhen(true)] this string? str) => !string.IsNullOrWhiteSpace(str);

    /// <summary>
    /// Compares two strings for equality using ordinal (binary) sort rules ignoring the case of the characters.
    /// </summary>
    /// <returns><see langword="true"/> if the two string are equal ignoring case of the characters; otherwise, <see langword="false"/>.</returns>
    public static bool EasyEquals(this string? a, string? b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
    
    public static bool EasyContains(this string first, string second) => first.Contains(second, StringComparison.OrdinalIgnoreCase);

    public static bool EasyStartsWith(this string first, string second) => first.StartsWith(second, StringComparison.OrdinalIgnoreCase);
    
    public static bool EasyEndsWith(this string first, string second) => first.EndsWith(second, StringComparison.OrdinalIgnoreCase);
}
