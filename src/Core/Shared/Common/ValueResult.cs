namespace Shared.Common;

public class ValueResult<T> : IResult
{
    private readonly bool _success;
    private readonly T? _value;
    private readonly string[] _messages;

    protected ValueResult(T? value, bool success, params string[] messages)
    {
        _value = value;
        _success = success;
        _messages = messages ?? Array.Empty<string>();
    }

    public bool IsSuccess => _success;
    public T? Value => _value;
    public string[] ErrorMessages => _messages;

    public static ValueResult<T> Success(T value) =>
        new ValueResult<T>(value, true);

    public static ValueResult<T> Failure(params string[] messages)
        => new ValueResult<T>(default, false, messages);

    public static implicit operator ValueResult<T>(T value) => Success(value);

    public static implicit operator ValueResult<T>(Failure failure) =>
        Failure(failure.Messages);

    public static implicit operator T(ValueResult<T> value) =>
        value.Value is not null
            ? value.Value
            : throw new ArgumentNullException(nameof(value.Value));
}
