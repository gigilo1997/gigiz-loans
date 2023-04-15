using System.Net;

namespace Domain.Exceptions;

public class NotFoundException : CustomException
{
    public NotFoundException(string message = "Resource not found")
        : base(HttpStatusCode.NotFound, message)
    {
    }
}
