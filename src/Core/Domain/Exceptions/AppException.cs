namespace Domain.Exceptions;

public abstract class AppException : Exception
{
    public AppException()
    {
    }

    public AppException(string message)
        : base(message)
    {
    }

    public Dictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}
