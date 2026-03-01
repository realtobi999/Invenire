using Invenire.Common.Errors;
using System.Text.RegularExpressions;

namespace Invenire.Api.Properties.Suggestions.Decline;

public record DeclinePropertySuggestionResponse
{
    // Errors.

    public static readonly List<ErrorTranslation> ErrorTranslations =
    [
        // Feedback
        new ErrorTranslation
        {
            Pattern = new Regex(@"The length of 'feedback' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Text musí mít maximálně {m.Groups[1].Value} {PluralizeChar(int.Parse(m.Groups[1].Value))}. Zadali jste {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}."
        },
        // General.
        new ErrorTranslation
        {
            Pattern = new Regex(@"An unexpected internal error occurred\."),
            Translate = _ => "Objevila se nečekaná chyba."
        },
        // Fallback translation for any unmatched errors.
        new ErrorTranslation
        {
            Pattern = new Regex(@".*"),
            Translate = _ => "Objevila se nečekaná chyba. Zkuste to prosím později."
        }
    ];

    private static string PluralizeChar(int count)
    {
        if (count == 0) return "znaků";
        else if (count == 1) return "znak";
        else if (count <= 4) return "znaky";
        else return "znaků";
    }
}


