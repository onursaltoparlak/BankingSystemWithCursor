using BankApp.Core.Persistence.Paging;

namespace BankApp.Core.Application.Responses;

public class GetListResponse<T>
{
    public IPaginate<T> Items { get; set; }
    public int Index { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public IList<T> Data { get; set; }
    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; }

    public GetListResponse(IPaginate<T> items)
    {
        Items = items;
        Index = items.Index;
        Size = items.Size;
        Count = items.Count;
        Pages = items.Pages;
        Data = items.Items;
        HasPrevious = items.HasPrevious;
        HasNext = items.HasNext;
    }

    public GetListResponse(IPaginate<T> items, int index, int size, int count, int pages, IList<T> data, bool hasPrevious, bool hasNext)
    {
        Items = items;
        Index = index;
        Size = size;
        Count = count;
        Pages = pages;
        Data = data;
        HasPrevious = hasPrevious;
        HasNext = hasNext;
    }
} 