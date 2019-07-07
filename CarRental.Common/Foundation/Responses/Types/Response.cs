namespace CarRental.Common.Foundation.Responses.Types
{
    public class Response : IResponse
    {
        public bool IsSuccessful => Status == ResponseStatus.Success || Status == ResponseStatus.SuccessButWarnings;
        public ResponseStatus Status { get; set; }
    }

    public class Response<T> : IResponse<T>
    {
        public bool IsSuccessful => Status == ResponseStatus.Success || Status == ResponseStatus.SuccessButWarnings;
        public ResponseStatus Status { get; set; }
        public T Result { get; set; }
    }
}