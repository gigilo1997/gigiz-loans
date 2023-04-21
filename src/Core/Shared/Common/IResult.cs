namespace Shared.Common;

public interface IResult
{
    bool IsSuccess { get; }
    string[] ErrorMessages { get; }
}
