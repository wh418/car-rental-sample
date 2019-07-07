using System.Collections.Generic;

namespace CarRental.Common.Foundation.Paging
{
    public interface IPagedList<T>
    {
        int Take { get; set; }
        int Skip { get; set; }
        long Total { get; set; }

        IList<T> Results { get; set; }
    }
}