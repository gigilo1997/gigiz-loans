namespace Domain.Exceptions;

public class AppForbiddenException : AppException
{
    public AppForbiddenException()
        : base("Forbidden")
    {
    }

    public AppForbiddenException(string message)
    : base(message)
    {
        Errors.Add(message, new string[] { message });
    }
}
