using System.Net;

namespace Domain.Exceptions;

public class InternalServerException : CustomException
{
    public InternalServerException(string message = "Something went wrong")
        : base(HttpStatusCode.InternalServerError, message)
    {
    }
}
