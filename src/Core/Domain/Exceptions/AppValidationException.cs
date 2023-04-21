using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Exceptions;

public class AppValidationException : Exception
{
    public Dictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();

    public AppValidationException()
        : base("One or more validation failures have occurred.")
    {
    }

    public AppValidationException(params KeyValuePair<string, string>[] errors)
        : base("One or more validation failures have occurred.")
    {
        Errors = errors.GroupBy(e => e.Key)
            .ToDictionary(k => k.Key, v => v.Select(e => e.Value).ToArray());
    }

    public AppValidationException(string error)
        : base(error)
    {
        Errors.Add(error, new string[] { error });
    }
}
