using LightTraveller.Guards;

namespace LightTraveller.Helpers;

public static class PagingExtensions
{
    public static long GetNumberOfPages(this long totalRecords, int pageSize)
    {
        _ = Guard.ZeroOrNegative(pageSize);

        if (totalRecords <= 0)
            return 0;

        var pages = totalRecords / pageSize;
        return totalRecords % pageSize == 0 ? pages : pages + 1;
    }
}
