using System.Text.RegularExpressions;
using Invenire.Common.Errors;

namespace Invenire.Api.Properties.Items.GenerateCodes;

public record GenerateCodesPropertyItemsResponse
{
    public static readonly List<ErrorTranslation> ErrorTranslations =
    [
        new ErrorTranslation
        {
            Pattern = new Regex(@"'size' must not be empty\."),
            Translate = _ => "Velikost nesmí být prázdná."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"'size' must be greater than or equal to '(\d+)'\."),
            Translate = m => $"Velikost musí být větší než {m.Groups[1].Value} pixelů."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"'size' must be less than or equal to '(\d+)'\."),
            Translate = m => $"Velikost musí být menší než {m.Groups[1].Value} pixelů."
        },
        // Fallback translation for any unmatched errors.
        new ErrorTranslation
        {
            Pattern = new Regex(@".*"),
            Translate = _ => "Objevila se nečekaná chyba. Zkuste to prosím později."
        }
    ];
}
