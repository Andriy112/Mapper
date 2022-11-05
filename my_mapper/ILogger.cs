namespace Mapper
{
    public interface ILogger<T>
    {
        void LogInformation(string message);
        Exception LogException(Exception exception);
    }
}
