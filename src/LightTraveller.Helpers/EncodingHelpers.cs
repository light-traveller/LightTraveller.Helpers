using LightTraveller.Guards;

namespace LightTraveller.Helpers;

public static class EncodingHelpers
{
    private const string INVALID_BASE32_ERROR = "The input string is not a valid base-32 encoded string.";

    /// <summary>
    /// Encodes a <see cref="byte[]"/> to its equivalent string representation that is encoded using base-32 encoding algorithm.
    /// </summary>
    /// <param name="bytes">An array of 8-bit unsigned integers.</param>
    /// <returns>The string representation of the <see cref="byte[]"/> in base-32.</returns>
    /// <exception cref="ArgumentNullException">The <paramref name="bytes"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">The <paramref name="bytes"/> is an empty array.</exception>
    public static string ToBase32String(this byte[] bytes)
    {
        _ = Guard.NullOrEmpty(bytes);

        var fullBlocks = bytes.Length / 5;
        var overflow = bytes.Length % 5;
        var missing = 0;

        if (overflow > 0)
            missing = 5 - overflow;

        var bits = bytes.Length * 8;
        var segments = (bits / 5) + (bits % 5 != 0 ? 1 : 0);
        var outputLength = fullBlocks * 8 + (overflow > 0 ? 8 : 0);
        var contextData = (bytes, fullBlocks, outputLength, overflow, segments);

        return string.Create(outputLength, contextData, (chars, state) =>
        {
            ReadOnlySpan<char> base32chars = stackalloc[]
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z', '2', '3', '4', '5',
                '6', '7'
            };

            for (int i = 0; i < state.fullBlocks; i++)
            {
                var inputOffset = i * 5;
                var outputOffset = i * 8;

                long val = state.bytes[inputOffset];
                val <<= 8;
                val |= state.bytes[inputOffset + 1];
                val <<= 8;
                val |= state.bytes[inputOffset + 2];
                val <<= 8;
                val |= state.bytes[inputOffset + 3];
                val <<= 8;
                val |= state.bytes[inputOffset + 4];

                chars[outputOffset] = base32chars[(int)(val >> 35 & 0x1F)];
                chars[outputOffset + 1] = base32chars[(int)(val >> 30 & 0x1F)];
                chars[outputOffset + 2] = base32chars[(int)(val >> 25 & 0x1F)];
                chars[outputOffset + 3] = base32chars[(int)(val >> 20 & 0x1F)];
                chars[outputOffset + 4] = base32chars[(int)(val >> 15 & 0x1F)];
                chars[outputOffset + 5] = base32chars[(int)(val >> 10 & 0x1F)];
                chars[outputOffset + 6] = base32chars[(int)(val >> 5 & 0x1F)];
                chars[outputOffset + 7] = base32chars[(int)(val & 0x1F)];
            }

            if (state.overflow > 0)
            {
                var overflowOffset = state.fullBlocks * 5;
                long val2 = state.bytes[overflowOffset];
                
                var i = 0;

                while (i < 5)
                {
                    val2 <<= 8;

                    if (overflowOffset < state.bytes.Length)
                        val2 |= state.bytes[overflowOffset];
                    else
                        val2 |= 0;

                    overflowOffset++;
                    i++;
                }

                var outputOffset = state.fullBlocks * 8;
                var shift = 35;

                while (outputOffset < state.outputLength)
                {
                    chars[outputOffset] = outputOffset < state.segments ? base32chars[(int)(val2 >> shift & 0x1F)] : '=';
                    shift -= 5;
                    outputOffset += 1;
                }
            }
        });
    }

    //public static string ToBase32OI2(this byte[] bytes)
    //{
    //    if (bytes == null)
    //    {
    //        return "";
    //    }

    //    // Check if empty
    //    else if (bytes.Length == 0)
    //    {
    //        return string.Empty;
    //    }

    //    return string.Create((bytes.Length / 5) * 8 + (bytes.Length % 5 > 0 ? 8 : 0), bytes, (chars, state) => 
    //    {
    //        ReadOnlySpan<char> base32chars = stackalloc[]
    //        {
    //            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
    //            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
    //            'U', 'V', 'W', 'X', 'Y', 'Z', '2', '3', '4', '5',
    //            '6', '7'
    //        };

    //        // Position in the input buffer
    //        int inputRow = 0;

    //        // Offset inside a single byte that <bytesPosition> points to (from left to right)
    //        // 0 - highest bit, 7 - lowest bit
    //        int inputOffset = 0;

    //        // Byte to look up in the dictionary
    //        byte outputByte = 0;

    //        // The number of bits filled in the current output byte
    //        int outputOffset = 0;

    //        var i = 0;

    //        // Iterate through input buffer until we reach past the end of it
    //        while (inputRow < state.Length)
    //        {
    //            // Calculate the number of bits we can extract out of current input byte to fill missing bits in the output byte
    //            int bitsAvailable = Math.Min(8 - inputOffset, 5 - outputOffset);

    //            // Make space in the output byte
    //            outputByte <<= bitsAvailable;

    //            // Extract the part of the input byte and move it to the output byte
    //            outputByte |= (byte)(state[inputRow] >> (8 - (inputOffset + bitsAvailable)));

    //            // Update current sub-byte position
    //            inputOffset += bitsAvailable;

    //            // Check overflow
    //            if (inputOffset >= 8)
    //            {
    //                // Move to the next byte
    //                inputRow++;
    //                inputOffset = 0;
    //            }

    //            // Update current base32 byte completion
    //            outputOffset += bitsAvailable;

    //            // Check overflow or end of input array
    //            if (outputOffset >= 5)
    //            {
    //                // Drop the overflow bits
    //                outputByte &= 0x1F;  // 0x1F = 00011111 in binary

    //                // Add current Base32 byte and convert it to character
    //                chars[i] = base32chars[outputByte];
    //                i++;

    //                // Move to the next byte
    //                outputOffset = 0;
    //            }


    //        }

    //        // Check if we have a remainder
    //        if (outputOffset > 0)
    //        {
    //            // Move to the right bits
    //            outputByte <<= (5 - outputOffset);

    //            // Drop the overflow bits
    //            outputByte &= 0x1F;  // 0x1F = 00011111 in binary

    //            // Add current Base32 byte and convert it to character
    //            chars[i] = base32chars[outputByte];
    //            i++;
    //        }

    //        for (var j = chars.Length - i; j < chars.Length; j++)
    //            chars[j] = '=';
    //    });
    //}

    //public static byte[] FromBase32String(this string input, bool ignoreCase = true)
    //{
    //    /********

    //    1. Map input characters, excluding padding characters ('='), to their value in Base32 character table.

    //    2. Each byte representation of the mapped value is a row of encoded data. Only lower 5 bits in encoded data
    //       contain information. We need to extract 8 bits from consecutive 5 bits of input. The bit pattern of the 
    //       masks and needed shift operations to combine masked bits are shown below. To differentiate consecutive masks,
    //       1s and 2s are used.        

    //    |- - -|1 1 1 1 1|  1: 1f << 3                 
    //    |- - -|1 1 1 2 2|  1: 1c >> 2       2: 03 << 6
    //    |- - -|2 2 2 2 2|  1: -             2: 1f << 1
    //    |- - -|2 1 1 1 1|  1: 0f << 4       2: 10 >> 4
    //    |- - -|1 1 1 1 2|  1: 1e >> 1       2: 01 << 7
    //    |- - -|2 2 2 2 2|  1: -             2: 1f << 2
    //    |- - -|2 2 1 1 1|  1: 07 << 5       2: 18 >> 3
    //    |- - -|1 1 1 1 1|  1: 1f -          2: -        

    //    ********/

    //    if (!ValidateBase32String(input, ignoreCase))
    //        throw new ArgumentException(INVALID_BASE32_ERROR);

    //    ReadOnlySpan<char> base32chars = stackalloc[]
    //    {
    //        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
    //        'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
    //        'U', 'V', 'W', 'X', 'Y', 'Z', '2', '3', '4', '5',
    //        '6', '7'
    //    };

    //    // Masks & Shifts
    //    // Negatives values denote right shift
    //    Span<short> ops = stackalloc short[]
    //    {
    //        0x1f, 3, 0x1c, -2, short.MinValue, // short.MinValue is shift/mask delimiter
    //        0x03, 6, 0x1f, 1, 0x10, -4, short.MinValue,
    //        0x0f, 4, 0x1e, -1, short.MinValue,
    //        0x01, 7, 0x1f, 2, 0x18, -3, short.MinValue,
    //        0x07, 5, 0x1f, 0
    //    };

    //    ReadOnlySpan<char> rawData = input;
    //    var indexOfEqual = rawData.IndexOf('=');
    //    var dataLength = indexOfEqual < 0 ? rawData.Length : indexOfEqual;
    //    ReadOnlySpan<char> data = rawData[..dataLength];
    //    var outputLength = dataLength * 5 / 8;
    //    var output = new byte[outputLength];
    //    var dataOffset = 0;
    //    var outputOffset = 0;
    //    var maskBits = 0;
    //    var decoded = 0;
    //    var opIndex = 0;

    //    while (outputOffset < outputLength && dataOffset < dataLength)
    //    {
    //        var code = base32chars.IndexOf(char.ToUpperInvariant(data[dataOffset]));

    //        if (code < 0)
    //        {
    //            throw new InvalidOperationException($"The input string is not a valid Base32 encoded string. Invalid character code: {(int)data[dataOffset]}.");
    //        }

    //        var mask = ops[opIndex];
    //        var shift = ops[opIndex + 1];
    //        code &= mask;

    //        if (shift >= 0)
    //        {
    //            decoded |= code << shift;
    //        }
    //        else
    //        {
    //            decoded |= code >> ~shift + 1;
    //        }

    //        opIndex += 2;

    //        if ((opIndex < ops.Length && ops[opIndex] == short.MinValue) || dataOffset == dataLength - 1)
    //        {
    //            output[outputOffset] = (byte)decoded;
    //            outputOffset++;
    //            opIndex++;
    //            decoded = 0;
    //        }
    //        else if (opIndex >= ops.Length && dataOffset < dataLength)
    //        {
    //            output[outputOffset] = (byte)decoded;
    //            outputOffset++;
    //            opIndex = 0;
    //            decoded = 0;
    //        }

    //        maskBits += BitOperations.PopCount((uint)mask);

    //        // If mask bits are >= (number of bits in an input row) x (number of the row), then
    //        // we have processed all the bits in the input row and should move to the next one.
    //        if (maskBits >= 5 * (dataOffset + 1))
    //            dataOffset++;
    //    }

    //    return output;
    //}

    /// <summary>
    /// Decodes the specified string, which encodes binary data as base-32 digits, to an equivalent 8-bit unsigned integer array.
    /// </summary>
    /// <param name="input">The string to decode.</param>
    /// <param name="ignoreCase">
    /// <para>If <see cref="true"/>, the string characters will be converted to upper-case before encoding; otherwise, </para>
    /// <para>lower-case characters in the input string will cause an <see cref="ArgumentException"/> to be thrown.</para></param>
    /// <returns>An array of 8-bit unsigned integers that is equivalent to the input string.</returns>
    /// <exception cref="ArgumentException">The <paramref name="input"/> is not a valid base-32 string.</exception>
    /// <exception cref="InvalidOperationException">The <paramref name="input"/> is not a valid base-32 string.</exception>
    /// <remarks>
    /// <para>Based on the excellent work of Oleg Ignat (https://olegignat.com/base32/).</para>
    /// <para>Simplicity of this method makes it faster than masking & shifting bits.</para>
    /// </remarks>
    public static byte[] FromBase32String(this string input, bool ignoreCase = true)
    {
        if (!ValidateBase32String(input, ignoreCase))
            throw new ArgumentException(INVALID_BASE32_ERROR);

        ReadOnlySpan<char> base32chars = stackalloc[]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z', '2', '3', '4', '5',
            '6', '7'
        };

        var inputRow = 0;
        var outputRow = 0;
        var inputOffset = 0;
        var outputOffset = 0;

        ReadOnlySpan<char> data = input;
        var indexOfEqual = data.IndexOf('=');
        var inputLength = indexOfEqual < 0 ? data.Length : indexOfEqual;        
        var output = new byte[inputLength * 5 / 8];

        while (outputRow < output.Length)
        {
            var code = base32chars.IndexOf(ignoreCase ? char.ToUpperInvariant(data[inputRow]) : data[inputRow]);

            if (code < 0)
            {
                throw new InvalidOperationException($"{INVALID_BASE32_ERROR}. Invalid character code: {(int)data[inputRow]}.");
            }

            // Calculate the number of bits we can extract from current input character to fill missing bits in the output byte.
            var availableBits = Math.Min(5 - inputOffset, 8 - outputOffset);

            // Make space in the output byte
            output[outputRow] <<= availableBits;

            // Extract the part of the input character and move it to the output byte
            output[outputRow] |= (byte)(code >> (5 - (inputOffset + availableBits)));

            inputOffset += availableBits;

            if (inputOffset >= 5)
            {
                inputRow++;
                inputOffset = 0;
            }

            outputOffset += availableBits;

            if (outputOffset >= 8)
            {
                outputRow++;
                outputOffset = 0;
            }
        }

        return output;
    }

    /// <summary>
    /// Determine whether a string is a valid base-32 encoded string or not.
    /// </summary>
    /// <param name="input">The string to be validated.</param>
    /// <param name="ignoreCase">If <see cref="true"/>, the string characters will be converted to upper-case before validation; otherwise, lower-case characters in the input string will be considered invalid.</param>
    /// <returns><see cref="true"/> if the string is valid; otherwise, <see cref="false"/>.</returns>
    /// <remarks>
    /// <list type="number">
    ///     <listheader>    
    ///         <description>The following conditions make a string invalid</description>
    ///     </listheader>
    ///     <item>
    ///         <description>A string of length zero (an empty string)</description>
    ///     </item>
    ///     <item>
    ///         <description>A string with a length that is not a multiply of 8</description>
    ///     </item>
    ///     <item>
    ///         <description>A padding character appearing in either of the two first positions in the string</description>
    ///     </item>
    ///     <item>
    ///         <description>A character other than capital letters A to Z and numbers 2, 3, 4, 5, 6 and 7. However, if the <paramref name="ignoreCase"/> argument is <see cref="true"/>, lower-case characters will be accepted.</description>
    ///     </item>
    ///     <item>
    ///         <description>A non-padding character appearing after a padding character.</description>
    ///     </item>
    ///     <item>
    ///         <description>Number of padding characters other than 1, 3, 4 or 6</description>
    ///     </item>
    /// </list>
    /// </remarks>
    public static bool ValidateBase32String(this string input, bool ignoreCase = true)
    {
        if (input.Empty())
            return false;

        if (input.Length % 8 != 0)
            return false;

        const char PADDING_CHAR = '=';

        var firstPaddingIndex = input.IndexOf(PADDING_CHAR);

        // Padding character cannot be present in the first two positions.
        if (firstPaddingIndex > -1 && firstPaddingIndex < 2)
        {
            return false;
        }

        ReadOnlySpan<char> base32chars = stackalloc[]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z', '2', '3', '4', '5',
            '6', '7'
        };

        // Invalid characters
        foreach (var character in input)
        {
            var testChar = ignoreCase ? char.ToUpperInvariant(character) : character;

            if (base32chars.IndexOf(testChar) < 0 && testChar != PADDING_CHAR)
            {
                return false;
            }
        }

        // Characters after '=' cannot be anything other than '='.
        if (firstPaddingIndex > 0)
        {
            ReadOnlySpan<char> data = input;

            foreach (var character in data[(firstPaddingIndex + 1)..])
            {
                if (character != PADDING_CHAR)
                {
                    return false;
                }
            }
        }

        // Check number of equals ('=')
        if (stackalloc[] { 0, 2, 3, 5 }.IndexOf(input.LastIndexOf(PADDING_CHAR) - firstPaddingIndex) < 0)
        {
            return false;
        }

        return true;
    }
}
