namespace Shared.Common;

public class VoidResult : IResult
{
    private readonly bool _success;
    private readonly string[] _messages;

    protected VoidResult(bool success, params string[] messages)
    {
        _success = success;
        _messages = messages ?? Array.Empty<string>();
    }

    public bool IsSuccess => _success;
    public string[] ErrorMessages => _messages;

    public static VoidResult Success() =>
        new VoidResult(true);

    public static VoidResult Failure(params string[] messages)
        => new VoidResult(false, messages);

    public static implicit operator VoidResult(Failure failure) =>
        Failure(failure.Messages);
}
