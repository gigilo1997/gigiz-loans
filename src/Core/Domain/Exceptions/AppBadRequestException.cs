namespace Domain.Exceptions;

public class AppBadRequestException : AppException
{
    public AppBadRequestException(params string[] messages)
        : base(string.Join(',', messages))
    {
        Errors = messages.ToDictionary(k => k, v => new string[] { v });
    }
}
