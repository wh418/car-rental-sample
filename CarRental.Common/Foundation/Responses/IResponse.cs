namespace CarRental.Common.Foundation.Responses
{
    public interface IResponse
    {
        bool IsSuccessful { get; }

        ResponseStatus Status { get; }
    }

    public interface IResponse<out T> : IResponse
    {
        T Result { get; }
    }
}