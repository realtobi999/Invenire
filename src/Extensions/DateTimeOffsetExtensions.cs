namespace Invenire.Extensions;

public static class DateTimeOffsetExtensions
{
    public static string ToUserTimeString(this DateTimeOffset time)
    {
        return time.ToLocalTime().ToString("dd.MM.yyyy HH:mm");
    }

    public static string ToUserTimeString(this DateTimeOffset? time)
    {
        if (!time.HasValue) return string.Empty;
        return time.Value.ToLocalTime().ToString("dd.MM.yyyy HH:mm");
    }
}
