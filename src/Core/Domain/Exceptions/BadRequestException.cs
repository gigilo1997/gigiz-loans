namespace Domain.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestError[] Errors { get; private set; }

    public BadRequestException(params BadRequestError[] errors)
    {
        Errors = errors ?? Array.Empty<BadRequestError>();
    }

    public record BadRequestError(string PropertyName, string ErrorMessage);
}
