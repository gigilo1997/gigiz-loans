namespace Shared.Extensions;

public static class StringExtensions
{
    public static string? TrimOrNull(this string? value) =>
        !string.IsNullOrWhiteSpace(value) ? value.Trim() : null;
}
