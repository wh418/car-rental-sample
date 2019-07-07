namespace CarRental.Common
{
    public interface IFactory<out T>
    {
        T Create();
    }
}