namespace Shared.Common;

public class Failure
{
    public string Message { get; init; }

    private Failure(string message) =>
        Message = message;

    public static Failure Create(string message) =>
        new Failure(message);
}
