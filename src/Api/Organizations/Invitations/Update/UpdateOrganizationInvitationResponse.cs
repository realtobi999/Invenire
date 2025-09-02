using System.Text.RegularExpressions;
using Invenire.Common.Errors;

namespace Invenire.Api.Organizations.Invitations.Update;

public record UpdateOrganizationInvitationResponse
{
    // Errors.

    public static readonly List<ErrorTranslation> ErrorTranslations =
    [
        // Description
        new ErrorTranslation
        {
            Pattern = new Regex(@"The length of 'description' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Text musí mít maximálně {m.Groups[1].Value} {PluralizeChar(int.Parse(m.Groups[1].Value))}. Zadali jste {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}."
        },
        // General.
        new ErrorTranslation
        {
            Pattern = new Regex(@"An unexpected internal error occurred\."),
            Translate = _ => "Objevila se nečekaná chyba."
        },
    ];

    private static string PluralizeChar(int count)
    {
        if (count == 0) return "znaků";
        else if (count == 1) return "znak";
        else if (count <= 4) return "znaky";
        else return "znaků";
    }
}


