using Invenire.Common.Errors;
using System.Text.RegularExpressions;

namespace Invenire.Api.Properties.Scans.Update;

public record UpdatePropertyScanResponse
{
    // Errors.

    public static readonly List<ErrorTranslation> ErrorTranslations =
    [
        // Name.
        new ErrorTranslation
        {
            Pattern = new Regex(@"'name' must not be empty\."),
            Translate = _ => "Název nesmí být prázdný."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The length of 'name' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Název musí mít maximálně {m.Groups[1].Value} {PluralizeChar(int.Parse(m.Groups[1].Value))}. Zadali jste {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}."
        },

        // Description.
        new ErrorTranslation
        {
            Pattern = new Regex(@"The length of 'decription' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Název musí mít maximálně {m.Groups[1].Value} {PluralizeChar(int.Parse(m.Groups[1].Value))}. Zadali jste {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}."
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
