using System.Net;

namespace Domain.Exceptions;

public class UnauthorizedException : CustomException
{
    public UnauthorizedException(string message = "Unauthorized")
        : base(HttpStatusCode.Unauthorized, message)
    {
    }
}
