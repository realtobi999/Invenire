namespace Invenire.Common.Extensions;

public static class StringExtensions
{
    public static TEnum ToEnum<TEnum>(this string value, TEnum dv = default) where TEnum : struct, Enum
    {
        if (string.IsNullOrWhiteSpace(value)) return dv;

        return Enum.TryParse(value, true, out TEnum result) ? result : dv;
    }
}
