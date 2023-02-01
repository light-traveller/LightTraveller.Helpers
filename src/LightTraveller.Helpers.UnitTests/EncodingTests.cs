using System.Text;

namespace LightTraveller.Helpers.UnitTests;

public class EncodingTests
{
    [Fact]
    public void WithNullByteArray_ToBase32String_Should_ThorwArgumentNull()
    {
        byte[]? input = null;
        Assert.Throws<ArgumentNullException>(() => input!.ToBase32String());
    }

    [Fact]
    public void WithEmptyByteArray_ToBase32String_Should_ThorwArgument()
    {
        byte[] input = Array.Empty<byte>();
        Assert.Throws<ArgumentException>(() => input.ToBase32String());
    }

    [Fact]    
    public void ToBase32String()
    {
        var A = ("A",     "IE======");
        var B = ("AB",    "IFBA====");
        var C = ("ABC",   "IFBEG===");
        var D = ("ABCD",  "IFBEGRA=");
        var E = ("ABCDE", "IFBEGRCF");
        var F = ("ABCDE.01234_FGHIJ-56789", "IFBEGRCFFYYDCMRTGRPUMR2IJFFC2NJWG44DS===");
        Assert.Equal(A.Item2, System.Text.Encoding.ASCII.GetBytes(A.Item1).ToBase32String());
        Assert.Equal(B.Item2, System.Text.Encoding.ASCII.GetBytes(B.Item1).ToBase32String());
        Assert.Equal(C.Item2, System.Text.Encoding.ASCII.GetBytes(C.Item1).ToBase32String());
        Assert.Equal(D.Item2, System.Text.Encoding.ASCII.GetBytes(D.Item1).ToBase32String());
        Assert.Equal(E.Item2, System.Text.Encoding.ASCII.GetBytes(E.Item1).ToBase32String());
        Assert.Equal(F.Item2, System.Text.Encoding.ASCII.GetBytes(F.Item1).ToBase32String());
    }

    [Fact]
    public  void WithInvalidInput_FromBase32String_Should_ThrowArgument()
    {
        Assert.Throws<ArgumentException>(() => "IE====A=".FromBase32String());
    }

    [Fact]
    public void FromBase32String()
    {
        var A = ("A",     "IE======");
        var B = ("AB",    "IFBA====");
        var C = ("ABC",   "IFBEG===");
        var D = ("ABCD",  "IFBEGRA=");
        var E = ("ABCDE", "IFBEGRCF");
        var F = ("ABCDE.01234_FGHIJ-56789", "IFBEGRCFFYYDCMRTGRPUMR2IJFFC2NJWG44DS===");

        Assert.Equal(A.Item1, System.Text.Encoding.ASCII.GetString(A.Item2.FromBase32String()));
        Assert.Equal(B.Item1, System.Text.Encoding.ASCII.GetString(B.Item2.FromBase32String()));
        Assert.Equal(C.Item1, System.Text.Encoding.ASCII.GetString(C.Item2.FromBase32String()));
        Assert.Equal(D.Item1, System.Text.Encoding.ASCII.GetString(D.Item2.FromBase32String()));
        Assert.Equal(E.Item1, System.Text.Encoding.ASCII.GetString(E.Item2.FromBase32String()));
        Assert.Equal(F.Item1, System.Text.Encoding.ASCII.GetString(F.Item2.FromBase32String()));
    }

    [Theory]
    [InlineData("")] // Empty input
    [InlineData("ABCD")] // Invalid length
    [InlineData("=IE=====")] // Padding character in first two positions
    [InlineData("==ABCDEF")] // Padding character in first two positions
    [InlineData("I_======")] // Invalid character
    [InlineData("IE====A=")] // Characters after '=' cannot be anything other than '='.
    [InlineData("IFBEGR==")] // Invalid number of paddings. Acceptable numbers: { 0, 1, 3, 4, 6 }
    [InlineData("IFB=====")] // Invalid number of paddings. Acceptable numbers: { 0, 1, 3, 4, 6 }
    [InlineData("I=======")] // Invalid number of paddings. Acceptable numbers: { 0, 1, 3, 4, 6 }
    public void WithInvalidInput_ValidateBase32String_Should_ReturnFalse(string input)
    {
        Assert.False(EncodingHelpers.ValidateBase32String(input));
    }
}
