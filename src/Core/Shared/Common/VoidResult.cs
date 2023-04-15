namespace Shared.Common;

public class VoidResult
{
    private readonly bool _success;
    private readonly string? _message;

    protected VoidResult(bool success, string? message = null)
    {
        _success = success;
        _message = message;
    }

    public bool IsSuccess => _success;
    public string? ErrorMessage => _message;

    public static VoidResult Success() =>
        new VoidResult(true);

    public static VoidResult Failure(string message)
        => new VoidResult(false, message);

    public static implicit operator VoidResult(Failure failure) =>
        Failure(failure.Message);
}
