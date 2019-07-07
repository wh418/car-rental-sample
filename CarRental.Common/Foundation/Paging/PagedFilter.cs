namespace CarRental.Common.Foundation.Paging
{
    public class PagedFilter : IPagedFilter
    {
        public int Take { get; set; }
        public int Skip { get; set; }

        public PagedFilter()
        {
            Take = PagingConstants.DefaultPageSize;
            Skip = 0;
        }
    }
}