using System.Text.RegularExpressions;
using Invenire.Common.Errors;

namespace Invenire.Api.Properties.Items.ExportToJson;

public class ExportToJsonPropertyItemResponse
{
    public static readonly List<ErrorTranslation> ErrorTranslations =
    [
        // Fallback translation for any unmatched errors.
        new ErrorTranslation
        {
            Pattern = new Regex(@".*"),
            Translate = _ => "Objevila se nečekaná chyba. Zkuste to prosím později."
        }
    ];
}
