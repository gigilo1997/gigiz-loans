namespace Shared.Common;

public class Failure
{
    public string[] Messages { get; init; }

    private Failure(string[] messages) =>
        Messages = messages ?? Array.Empty<string>();

    public static Failure Create(params string[] messages) =>
        new Failure(messages);
}
