using System.Diagnostics.CodeAnalysis;

namespace LightTraveller.Helpers;

public static class StringExtensions
{
    /// <summary>
    /// Indicates whether a specified string is null, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns><see cref="true"/> if the value parameter is null or Empty, or if value consists exclusively of white-space characters.</returns>
    public static bool Empty([NotNullWhen(false)] this string? value) => string.IsNullOrWhiteSpace(value);

    /// <summary>
    /// Indicates whether a specified string contains any non-white-space characters.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns><see cref="true"/> if the value parameter is not null, an Empty string or exclusively made of white-space characters.</returns>
    public static bool NotEmpty([NotNullWhen(true)] this string? value) => !string.IsNullOrWhiteSpace(value);

    /// <summary>
    /// Compares two strings for equality using ordinal (binary) sort rules ignoring the case of the characters.
    /// </summary>
    /// <param name="a">The first string instance.</param>
    /// <param name="b">The string to compare to the first instance.</param>
    /// <returns><see cref="true"/> if the two string are equal ignoring case of the characters; otherwise, <see cref="false"/>.</returns>
    public static bool EasyEquals(this string? a, string? b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Returns a value indicating whether a specified substring occurs within another string using ordinal (binary) sort rules ignoring the case of the characters.
    /// </summary>
    /// <param name="first">The string to look into.</param>
    /// <param name="second">The string to seek.</param>
    /// <returns><see cref="true"/> if the second string occurs within the first string, ignoring the case of the characters, or if second is the empty string (""); otherwise, <see cref="false"/>.</returns>
    public static bool EasyContains(this string first, string second) => first.Contains(second, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Determines whether the beginning of the first string instance matches the second string using ordinal (binary) sort rules ignoring the case of the characters.
    /// </summary>
    /// <param name="first">The string whose beginning is to be checked.</param>
    /// <param name="second">The string to compare to the substring at the beginning of the first one.</param>
    /// <returns><see cref="true"/> if second string matches the beginning of the first one, ignoring the case of the characters; otherwise, <see cref="false"/>.</returns>
    public static bool EasyStartsWith(this string first, string second) => first.StartsWith(second, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Determines whether the end of this string instance matches a specified string using ordinal (binary) sort rules ignoring the case of the characters.
    /// </summary>
    /// <param name="first">The string whose end is to be checked.</param>
    /// <param name="second">The string to compare to the substring at the end of the first one.</param>
    /// <returns><see cref="true"/> if second string matches the end of the first one, ignoring the case of the characters; otherwise, <see cref="false"/>.</returns>
    public static bool EasyEndsWith(this string first, string second) => first.EndsWith(second, StringComparison.OrdinalIgnoreCase);
}
