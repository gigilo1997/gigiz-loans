using System.Net;

namespace Domain.Exceptions;

public class CustomException : Exception
{
    public IEnumerable<string> Messages { get; }
    public HttpStatusCode StatusCode { get; }

    public CustomException(
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
        params string[] messages)
        : base(messages?.FirstOrDefault())
    {
        StatusCode = statusCode;
        Messages = messages?.AsEnumerable() ?? Enumerable.Empty<string>();
    }

    public bool HasMultipleErrors => Messages.Count() > 1;
}
