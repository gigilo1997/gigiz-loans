using System.Net;

namespace Domain.Exceptions;

public class ForbiddenException : CustomException
{
    public ForbiddenException(string message = "Forbidden")
        : base(HttpStatusCode.Forbidden, message)
    {
    }
}
