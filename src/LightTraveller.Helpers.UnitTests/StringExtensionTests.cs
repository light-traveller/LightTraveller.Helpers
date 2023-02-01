namespace LightTraveller.Helpers.UnitTests;

public class StringExtensionTests
{
    [Fact]
    public void WithNullString_Empty_Should_RetuenTrue()
    {
        string? str = null;
        Assert.True(str.Empty());
    }

    [Fact]
    public void WithEmptyString_Empty_Should_RetuenTrue()
    {
        var str = string.Empty;
        Assert.True(str.Empty());
    }

    [Fact]
    public void WithNonEmptyString_Empty_Should_RetuenFalse()
    {
        var str = "a string";
        Assert.False(str.Empty());
    }

    //---------------------------------------------------------

    [Fact]
    public void WithNonEmptyString_NotEmpty_Should_RetuenTrue()
    {
        var str = "a string";
        Assert.True(str.NotEmpty());
    }

    [Fact]
    public void WithNullString_NotEmpty_Should_RetuenFalse()
    {
        string? str = null;
        Assert.False(str.NotEmpty());
    }

    [Fact]
    public void WithEmptyString_NotEmpty_Should_RetuenFalse()
    {
        var str = string.Empty;
        Assert.False(str.NotEmpty());
    }

    //---------------------------------------------------------

    [Fact]
    public void WithEqualAndDifferentCaseStrings_EasyEquals_Should_RetuenTrue()
    {
        var a = "A sample string";
        var b = "a Sample STRING";
        Assert.True(a.EasyEquals(b));
    }

    [Fact]
    public void WithEqualAndDifferentCaseStrings_EasyContains_Should_RetuenTrue()
    {
        var a = "A sample string";
        var b = "SAMPLE";
        Assert.True(a.EasyContains(b));
    }

    [Fact]
    public void WithEqualAndDifferentCaseStrings_EasyStartsWith_Should_RetuenTrue()
    {
        var a = "A sample string";
        var b = "a SAMPLE";
        Assert.True(a.EasyStartsWith(b));
    }

    [Fact]
    public void WithEqualAndDifferentCaseStrings_EasyEndsWith_Should_RetuenTrue()
    {
        var a = "A sample string";
        var b = "STRING";
        Assert.True(a.EasyEndsWith(b));
    }
}
