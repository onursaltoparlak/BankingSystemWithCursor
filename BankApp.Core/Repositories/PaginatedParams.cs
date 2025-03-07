namespace BankApp.Core.Repositories;

public class PaginatedParams
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }

    public PaginatedParams()
    {
        PageIndex = 0;
        PageSize = 10;
    }

    public PaginatedParams(int pageIndex, int pageSize)
    {
        PageIndex = pageIndex < 0 ? 0 : pageIndex;
        PageSize = pageSize <= 0 ? 10 : pageSize;
    }
} 