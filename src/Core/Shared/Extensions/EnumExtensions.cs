namespace Shared.Extensions;

public static class EnumExtensions
{
    public static string ToEnumString<T>(this T value)
        where T : Enum
        => Enum.GetName(typeof(T), value) ?? string.Empty;
}
