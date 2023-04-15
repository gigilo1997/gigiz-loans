using System.Net;

namespace Domain.Exceptions;

public class BadRequestException : CustomException
{
    public BadRequestException(string message = "Bad Request")
        : base(HttpStatusCode.BadRequest, message)
    {
    }

    public BadRequestException(params string[] messages)
        : base(HttpStatusCode.BadRequest, messages)
    {
    }
}
