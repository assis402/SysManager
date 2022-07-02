using System.Collections.Generic;
using System.Linq;

namespace SysManager.Application.Contracts
{
    public class PaginationResponse<T> where T: class
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public IEnumerable<T> Items { get; set; }

        public PaginationResponse(int pageSize, int page, IEnumerable<T> items)
        {
            PageSize = pageSize;
            Page = page;
            Total = items.Count();
            Items = items;
        }
    }
}