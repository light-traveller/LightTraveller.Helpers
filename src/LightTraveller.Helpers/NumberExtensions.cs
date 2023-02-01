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

    public static bool In(this int value, Range range) => value >= range.Start.Value && value < range.End.Value;
    
    public static bool In(this int value, int minInclusive, int maxInclusive) => value >= minInclusive && value <= maxInclusive;
    public static bool In(this long value, long minInclusive, long maxInclusive) => value >= minInclusive && value <= maxInclusive;
    public static bool In(this float value, float minInclusive, float maxInclusive) => value >= minInclusive && value <= maxInclusive;
    public static bool In(this double value, double minInclusive, double maxInclusive) => value >= minInclusive && value <= maxInclusive;
    public static bool In(this decimal value, decimal minInclusive, decimal maxInclusive) => value >= minInclusive && value <= maxInclusive;

    public static TimeSpan Days(this int value) => TimeSpan.FromDays(value);
    public static TimeSpan Days(this long value) => TimeSpan.FromDays(value);
    public static TimeSpan Days(this float value) => TimeSpan.FromDays(value);
    public static TimeSpan Days(this double value) => TimeSpan.FromDays(value);

    public static TimeSpan Hours(this int value) => TimeSpan.FromHours(value);
    public static TimeSpan Hours(this long value) => TimeSpan.FromHours(value);
    public static TimeSpan Hours(this float value) => TimeSpan.FromHours(value);
    public static TimeSpan Hours(this double value) => TimeSpan.FromHours(value);

    public static TimeSpan Minutes(this int value) => TimeSpan.FromMinutes(value);
    public static TimeSpan Minutes(this long value) => TimeSpan.FromMinutes(value);
    public static TimeSpan Minutes(this float value) => TimeSpan.FromMinutes(value);
    public static TimeSpan Minutes(this double value) => TimeSpan.FromMinutes(value);

    public static TimeSpan Seconds(this int value) => TimeSpan.FromSeconds(value);
    public static TimeSpan Seconds(this long value) => TimeSpan.FromSeconds(value);
    public static TimeSpan Seconds(this float value) => TimeSpan.FromSeconds(value);
    public static TimeSpan Seconds(this double value) => TimeSpan.FromSeconds(value);

    public static TimeSpan Milliseconds(this int value) => TimeSpan.FromMilliseconds(value);
    public static TimeSpan Milliseconds(this long value) => TimeSpan.FromMilliseconds(value);
    public static TimeSpan Milliseconds(this float value) => TimeSpan.FromMilliseconds(value);
    public static TimeSpan Milliseconds(this double value) => TimeSpan.FromMilliseconds(value);

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
