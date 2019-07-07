namespace CarRental.Common.Foundation.Paging
{
    public interface IPagedFilter
    {
        int Take { get; set; }
        int Skip { get; set; }
    }
}