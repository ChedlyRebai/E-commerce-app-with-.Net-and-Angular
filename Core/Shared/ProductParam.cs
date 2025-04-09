using System;

namespace Infrastructure.Shared;

public class ProductParam
{
    public string  Sort { get; set; }
    public int ? CategoryId { get; set; }
    public int MaxPageSize { get; set; } = 20;
    public int _pageSize { get; set; } = 10;

    public int pageSize {
        get {return _pageSize; }
        set{_pageSize = (value > MaxPageSize) ? MaxPageSize : value;}
    }

    public int PageNumber { get; set; }
}
