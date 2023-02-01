namespace LightTraveller.Helpers.UnitTests;

public class EnumerableExtensionTests
{
    [Fact]
    public void WithFalsePredicate_None_Shoud_ReturnTrue()
    {
        List<int> list = new() { 1, 2, 3, 4 };
        Assert.True(list.None(i => i > 100));
    }

    [Fact]
    public void WithTruePredicate_None_Shoud_ReturnFalse()
    {
        List<int> list = new() { 1, 2, 3, 4 };
        Assert.False(list.None(i => i < 10));
    }

    //---------------------------------------------------------

    [Fact]
    public void ForEach_Shoud_BeRunForAllItems()
    {
        
        List<int> list = new() { 1, 2, 3 };
        int[] array = new[] { 4, 5, 6 };
               
        List<string> listResult = new();
        List<string> arrayResult = new();

        EnumerableExtensions.ForEach(list, i => listResult.Add((i * 2).ToString()));
        Assert.Equal(new[] { "2", "4", "6" }, listResult);

        EnumerableExtensions.ForEach(array, i => arrayResult.Add((i * 3).ToString()));        
        Assert.Equal(new[] { "12", "15", "18" }, arrayResult);
    }

    //---------------------------------------------------------

    [Fact]
    public void WithNullCollection_IsNullOrEmpty_Should_ReturnTrue()
    {
        int[]? arr = null;
        Assert.True(arr!.IsNullOrEmpty());
    }

    [Fact]
    public void WithEmptyCollection_IsNullOrEmpty_Should_ReturnTrue()
    {
        var arr = Array.Empty<int>();
        Assert.True(arr.IsNullOrEmpty());
    }

    [Fact]
    public void WithNonEmptyCollection_IsNullOrEmpty_Should_ReturnFalse()
    {
        var arr = new int[] { 1 };
        Assert.False(arr.IsNullOrEmpty());
    }
}
