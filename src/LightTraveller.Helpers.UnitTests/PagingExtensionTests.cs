namespace LightTraveller.Helpers.UnitTests;

public class PagingExtensionTests
{
    [Fact]
    public void WithZeroPageSize_GetNumberOfPages_Should_Throw()
    {
        var totalRecords = 100L;
        _ = Assert.Throws<ArgumentException>(() => totalRecords.GetNumberOfPages(pageSize: 0));
    }

    [Fact]
    public void WithNegativePageSize_GetNumberOfPages_Should_Throw()
    {
        var totalRecords = 100L;
        _ = Assert.Throws<ArgumentException>(() => totalRecords.GetNumberOfPages(pageSize: -5));
    }

    [Fact]
    public void WithZeroTotalRecord_GetNumberOfPages_Should_ReturnZero()
    {
        var totalRecords = 0L;
        Assert.Equal(0, totalRecords.GetNumberOfPages(pageSize: 5));
    }

    [Fact]
    public void WithZeroRamainder_GetNumberOfPages_Should_ReturnTotalRecordsDividedByPageSize()
    {
        var totalRecords = 100L;
        Assert.Equal(10, totalRecords.GetNumberOfPages(pageSize: 10));
    }

    [Fact]
    public void WithNonZeroRamainder_GetNumberOfPages_Should_ReturnTotalRecordsDividedByPageSizePlusOne()
    {
        var totalRecords = 101L;
        Assert.Equal(11, totalRecords.GetNumberOfPages(pageSize: 10));
    }
}
