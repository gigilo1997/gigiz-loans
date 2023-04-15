namespace Shared.Common;

public class ValueResult<T>
{
    private readonly bool _success;
    private readonly T? _value;
    private readonly string? _message;

    protected ValueResult(T? value, bool success, string? message = null)
    {
        _value = value;
        _success = success;
        _message = message;
    }

    public bool IsSuccess => _success;
    public T? Value => _value;
    public string? ErrorMessage => _message;

    public static ValueResult<T> Success(T value) =>
        new ValueResult<T>(value, true);

    public static ValueResult<T> Failure(string message)
        => new ValueResult<T>(default, false, message);

    public static implicit operator ValueResult<T>(T value) => value;

    public static implicit operator ValueResult<T>(Failure failure) =>
        Failure(failure.Message);

    public static implicit operator T(ValueResult<T> value) =>
        value.Value is not null
            ? Success(value.Value)
            : throw new ArgumentNullException(nameof(value.Value));
}
