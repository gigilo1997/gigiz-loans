namespace Shared.Common;

public class PaginatedList<T>
{
    public List<T> Items { get; private set; }
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }
    public int TotalCount { get; private set; }
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        Items = items;
        TotalCount = count;
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling((double)count / (double)pageSize);
    }
}
