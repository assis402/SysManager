using System.Collections.Generic;
using System.Linq;

namespace SysManager.Application.Contracts
{
    public class PaginationResponse<T> where T : class
    {
        public int _pageSize { get; set; }
        public int _page { get; set; }
        public int _total { get; set; }
        public IEnumerable<T> Items { get; set; }

        public PaginationResponse()
        {
        }

        public PaginationResponse(int pageSize, int page, IEnumerable<T> items)
        {
            _pageSize = pageSize;
            _page = page;
            _total = items.Count();
            Items = items;
        }
    }
}