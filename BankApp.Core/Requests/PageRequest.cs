namespace BankApp.Core.Requests;

public class PageRequest
{
    private int _pageIndex;
    private int _pageSize;

    public int PageIndex
    {
        get => _pageIndex;
        set => _pageIndex = value < 0 ? 0 : value;
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value < 1 ? 10 : value;
    }

    public PageRequest()
    {
        _pageIndex = 0;
        _pageSize = 10;
    }

    public PageRequest(int pageIndex, int pageSize)
    {
        _pageIndex = pageIndex < 0 ? 0 : pageIndex;
        _pageSize = pageSize < 1 ? 10 : pageSize;
    }
} 