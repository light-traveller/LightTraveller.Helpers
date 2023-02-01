using LightTraveller.Guards;

namespace LightTraveller.Helpers;

public static class NumberExtensions
{
    private static readonly char[] Base64Chars = new[]
    {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
        'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
        'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd',
        'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
        'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
        'y', 'z', '+', '/',
    };

    /// <summary>
    /// Determines if a value falls within a specified range.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="range">The <see cref="System.Range"/> to check.</param>
    /// <returns><see cref="true"/> if the value falls within the specified <see cref="System.Range"/>; otherwise, <see cref="false"/>.</returns>
    public static bool In(this int value, Range range) => value >= range.Start.Value && value < range.End.Value;

    /// <summary>
    /// Determines if an <see cref="int"/> value falls within the range specified by two <see cref="int"/> bounds.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="minInclusive">The inclusive lower bound of the range.</param>
    /// <param name="maxInclusive">The inclusive upper bound of the range.</param>
    /// <returns><see cref="true"/> if the value falls within the range; otherwise, <see cref="false"/>.</returns>
    public static bool In(this int value, int minInclusive, int maxInclusive) => value >= minInclusive && value <= maxInclusive;

    /// <summary>
    /// Determines if a <see cref="long"/> value falls within the range specified by two <see cref="long"/> bounds.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="minInclusive">The inclusive lower bound of the range.</param>
    /// <param name="maxInclusive">The inclusive upper bound of the range.</param>
    /// <returns><see cref="true"/> if the value falls within the range; otherwise, <see cref="false"/>.</returns>
    public static bool In(this long value, long minInclusive, long maxInclusive) => value >= minInclusive && value <= maxInclusive;

    /// <summary>
    /// Determines if a <see cref="float"/> value falls within the range specified by two <see cref="float"/> bounds.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="minInclusive">The inclusive lower bound of the range.</param>
    /// <param name="maxInclusive">The inclusive upper bound of the range.</param>
    /// <returns><see cref="true"/> if the value falls within the range; otherwise, <see cref="false"/>.</returns>
    public static bool In(this float value, float minInclusive, float maxInclusive) => value >= minInclusive && value <= maxInclusive;

    /// <summary>
    /// Determines if a <see cref="double"/> value falls within the range specified by two <see cref="double"/> bounds.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="minInclusive">The inclusive lower bound of the range.</param>
    /// <param name="maxInclusive">The inclusive upper bound of the range.</param>
    /// <returns><see cref="true"/> if the value falls within the range; otherwise, <see cref="false"/>.</returns>
    public static bool In(this double value, double minInclusive, double maxInclusive) => value >= minInclusive && value <= maxInclusive;

    /// <summary>
    /// Determines if a <see cref="decimal"/> value falls within the range specified by two <see cref="decimal"/> bounds.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="minInclusive">The inclusive lower bound of the range.</param>
    /// <param name="maxInclusive">The inclusive upper bound of the range.</param>
    /// <returns><see cref="true"/> if the value falls within the range; otherwise, <see cref="false"/>.</returns>
    public static bool In(this decimal value, decimal minInclusive, decimal maxInclusive) => value >= minInclusive && value <= maxInclusive;

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of days, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of days.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Days(this int value) => TimeSpan.FromDays(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of days, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of days.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Days(this long value) => TimeSpan.FromDays(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of days, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of days, accurate to the nearest millisecond.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Days(this float value) => TimeSpan.FromDays(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of days, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of days, accurate to the nearest millisecond.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Days(this double value) => TimeSpan.FromDays(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of hours, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of hours.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Hours(this int value) => TimeSpan.FromHours(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of hours, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of hours.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Hours(this long value) => TimeSpan.FromHours(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of hours, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of hours accurate to the nearest millisecond.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Hours(this float value) => TimeSpan.FromHours(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of hours, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of hours accurate to the nearest millisecond.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Hours(this double value) => TimeSpan.FromHours(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of minutes, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of minutes.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Minutes(this int value) => TimeSpan.FromMinutes(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of minutes, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of minutes.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Minutes(this long value) => TimeSpan.FromMinutes(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of minutes, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of minutes accurate to the nearest millisecond.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Minutes(this float value) => TimeSpan.FromMinutes(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of minutes, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of minutes accurate to the nearest millisecond.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Minutes(this double value) => TimeSpan.FromMinutes(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of seconds, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of seconds.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Seconds(this int value) => TimeSpan.FromSeconds(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of seconds, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of seconds.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Seconds(this long value) => TimeSpan.FromSeconds(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of seconds, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of seconds accurate to the nearest millisecond.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Seconds(this float value) => TimeSpan.FromSeconds(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of seconds, where the specification is accurate to the nearest millisecond.
    /// </summary>
    /// <param name="value">A number of seconds accurate to the nearest millisecond.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Seconds(this double value) => TimeSpan.FromSeconds(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of milliseconds.
    /// </summary>
    /// <param name="value">A number of milliseconds.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Milliseconds(this int value) => TimeSpan.FromMilliseconds(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of milliseconds.
    /// </summary>
    /// <param name="value">A number of milliseconds.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Milliseconds(this long value) => TimeSpan.FromMilliseconds(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of milliseconds.
    /// </summary>
    /// <param name="value">A number of milliseconds.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Milliseconds(this float value) => TimeSpan.FromMilliseconds(value);

    /// <summary>
    /// Returns a TimeSpan that represents a specified number of milliseconds.
    /// </summary>
    /// <param name="value">A number of milliseconds.</param>
    /// <returns>A <see cref="TimeSpan"/> object that represents the value.</returns>
    public static TimeSpan Milliseconds(this double value) => TimeSpan.FromMilliseconds(value);

    /// <summary>
    /// Changes base of a decimal <see cref="long"/> number to a another base.
    /// </summary>
    /// <param name="value">The <see cref="long"/> number whose base is to be changed.</param>
    /// <param name="targetBase">The new base.</param>
    /// <param name="targetBaseSymbols">Symbols to use as digits in the new base.</param>
    /// <returns>A string showing the number in the new base consisting of characters provided to use as digits.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The base is less than 2 or greater than 64.</exception>
    /// <exception cref="Exception">The number of character used for digits is less than the base.</exception>
    public static string ToBaseN(this long value, int targetBase, params char[] targetBaseSymbols)
    {
        _ = Guard.OutOfRange(targetBase, 2, 64);

        if (targetBaseSymbols.Length == 0)
            targetBaseSymbols = Base64Chars;

        if (targetBase > targetBaseSymbols.Length)
            throw new Exception("Number of the symbols should be greater than or equal to the target base.");

        // 64 will be the worst case size of the buffer
        // when the smallest base (2) and the largest
        // long number (long.MaxValue) are used.
        const int BUFFER_SIZE = 64;

        Span<char> buffer = stackalloc char[BUFFER_SIZE];
        var offset = 0;

        do
        {
            buffer[offset++] = targetBaseSymbols[value % targetBase];
            value /= targetBase;
        }
        while (value > 0);

        buffer[0..offset].Reverse();
        var result = string.Empty;

        unsafe
        {
            fixed (char* p = buffer)
            {
                result = new string(p, 0, offset);
            }
        }

        return result;
    }
}
