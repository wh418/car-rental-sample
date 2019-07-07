using System.Collections.Generic;

namespace CarRental.Common.Foundation.Paging
{
    public class PagedList<T> : IPagedList<T>
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public long Total { get; set; }
        public IList<T> Results { get; set; }
    }
}