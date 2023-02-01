using LightTraveller.Guards;

namespace LightTraveller.Helpers;

public static class PagingExtensions
{
    /// <summary>
    /// Gets number of pages given row count for each page and total number of rows.
    /// </summary>
    /// <param name="totalRecords">Total number of rows.</param>
    /// <param name="pageSize">Number of rows in each page.</param>
    /// <returns>Number of pages each containing the specified number of rows.</returns>
    public static long GetPageCount(this long totalRecords, int pageSize)
    {
        _ = Guard.ZeroOrNegative(pageSize);

        if (totalRecords <= 0)
            return 0;

        var pages = totalRecords / pageSize;
        return totalRecords % pageSize == 0 ? pages : pages + 1;
    }

    /// <summary>
    /// Gets number of pages given row count for each page and total number of rows.
    /// </summary>
    /// <param name="totalRecords">Total number of rows.</param>
    /// <param name="pageSize">Number of rows in each page.</param>
    /// <returns>Number of pages each containing the specified number of rows.</returns>
    public static int GetPageCount(this int totalRecords, int pageSize)
    {
        _ = Guard.ZeroOrNegative(pageSize);

        if (totalRecords <= 0)
            return 0;

        var pages = totalRecords / pageSize;
        return totalRecords % pageSize == 0 ? pages : pages + 1;
    }
}
