namespace Domain.Exceptions;

public class AppBadRequestException : Exception
{
    public Dictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();

    public AppBadRequestException(params string[] messages)
        : base(string.Join(',', messages))
    {
        Errors = messages.ToDictionary(k => k, v => new string[] { v });
    }
}
