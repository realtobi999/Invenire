using System.Text.RegularExpressions;

namespace Invenire.Common.Errors;

public class ErrorTranslation
{
    public required Regex Pattern { get; init; }
    public required Func<Match, string> Translate { get; init; }
}

public static class ErrorTranslator
{
    public static string Translate(string error, IEnumerable<ErrorTranslation> translations)
    {
        foreach (var translation in translations)
        {
            var match = translation.Pattern.Match(error);
            if (match.Success) return translation.Translate(match);
        }
        return error;
    }
}
