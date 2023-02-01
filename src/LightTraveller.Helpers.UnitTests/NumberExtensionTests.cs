namespace LightTraveller.Helpers.UnitTests;

public class NumberExtensionTests
{
    [Fact]
    public void WithRangeValueWithinRange_In_Should_ReturnTrue()
    {
        Assert.True(5.In(1..10));
    }

    [Fact]
    public void WithRangeValueOutsideRange_In_Should_ReturnFalse()
    {
        Assert.False(0.In(1..10));
        Assert.False(11.In(1..10));
    }

    [Fact]
    public void WithLowerBoundValueOfRange_In_Should_ReturnTrue()
    {
        Assert.True(1.In(1..10));
    }

    [Fact]
    public void WithUpperBoundValueOfRange_In_Should_ReturnFalse()
    {
        Assert.False(10.In(1..10));
    }

    //------------------------------------------------------------

    [Fact]
    public void WithValueWithinRange_In_Should_ReturnTrue()
    {
        Assert.True(5.In(1, 10));
        Assert.True(5L.In(1, 10));
        Assert.True(5F.In(1, 10));
        Assert.True(5D.In(1, 10));
        Assert.True(5M.In(1, 10));
    }

    [Fact]
    public void WithValueOutsideRange_In_Should_ReturnTrue()
    {
        Assert.False(0.In(1, 10));
        Assert.False(11.In(1, 10));

        Assert.False(0L.In(1, 10));
        Assert.False(11L.In(1, 10));
        
        Assert.False(0F.In(1, 10));
        Assert.False(11F.In(1, 10));
        
        Assert.False(0D.In(1, 10));
        Assert.False(11D.In(1, 10));
        
        Assert.False(0M.In(1, 10));
        Assert.False(11M.In(1, 10));
    }

    [Fact]
    public void WithLowerBoundValue_In_Should_ReturnTrue()
    {
        Assert.True(1.In(1, 10));
        Assert.True(1L.In(1, 10));
        Assert.True(1F.In(1, 10));
        Assert.True(1D.In(1, 10));
        Assert.True(1M.In(1, 10));
    }

    [Fact]
    public void WithInclusiveUpperBoundValue_In_Should_ReturnTrue()
    {
        Assert.True(10.In(1, 10));
        Assert.True(10L.In(1, 10));
        Assert.True(10F.In(1, 10));
        Assert.True(10D.In(1, 10));
        Assert.True(10M.In(1, 10));
    }

    //------------------------------------------------------------

    [Fact]
    public void Days()
    {
        TimeSpan expected = TimeSpan.FromDays(2);
        Assert.Equal(expected, 2.Days());
        Assert.Equal(expected, 2L.Days());
        Assert.Equal(expected, 2F.Days());
        Assert.Equal(expected, 2D.Days());
    }

    [Fact]
    public void Hours()
    {
        TimeSpan expected = TimeSpan.FromHours(2);
        Assert.Equal(expected, 2.Hours());
        Assert.Equal(expected, 2L.Hours());
        Assert.Equal(expected, 2F.Hours());
        Assert.Equal(expected, 2D.Hours());
    }

    [Fact]
    public void Minutes()
    {
        TimeSpan expected = TimeSpan.FromMinutes(2);
        Assert.Equal(expected, 2.Minutes());
        Assert.Equal(expected, 2L.Minutes());
        Assert.Equal(expected, 2F.Minutes());
        Assert.Equal(expected, 2D.Minutes());
    }

    [Fact]
    public void Seconds()
    {
        TimeSpan expected = TimeSpan.FromSeconds(2);
        Assert.Equal(expected, 2.Seconds());
        Assert.Equal(expected, 2L.Seconds());
        Assert.Equal(expected, 2F.Seconds());
        Assert.Equal(expected, 2D.Seconds());
    }

    [Fact]
    public void Milliseconds()
    {
        TimeSpan expected = TimeSpan.FromMilliseconds(2);
        Assert.Equal(expected, 2.Milliseconds());
        Assert.Equal(expected, 2L.Milliseconds());
        Assert.Equal(expected, 2F.Milliseconds());
        Assert.Equal(expected, 2D.Milliseconds());
    }

    //------------------------------------------------------------

    [Fact]
    public void WithValidBase_BaseN_ShoudNot_Throw()
    {
        var value = 1000L;
        Assert.Equal("1111101000", value.ToBaseN(2));
        Assert.Equal("1750", value.ToBaseN(8));
        Assert.Equal("3E8", value.ToBaseN(16));
        Assert.Equal("Fe", value.ToBaseN(64));        
    }

    [Fact]
    public void WithInvalidBase_BaseN_Shoud_ThrowOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => 10L.ToBaseN(1));
        Assert.Throws<ArgumentOutOfRangeException>(() => 10L.ToBaseN(65));        
    }
}
