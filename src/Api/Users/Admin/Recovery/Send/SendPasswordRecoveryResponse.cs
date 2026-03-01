using System.Text.RegularExpressions;
using Invenire.Common.Errors;

namespace Invenire.Api.Users.Admin.Recovery.Send;

public record SendPasswordRecoveryResponse
{
    // Errors.

    public static readonly List<ErrorTranslation> ErrorTranslations =
    [
        // Email Address
        new ErrorTranslation
        {
            Pattern = new Regex(@"'email_address' must not be empty\."),
            Translate = _ => "Emailová adresa nesmí být prázdná."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"'email_address' is not a valid email address\."),
            Translate = _ => "Emailová adresa není ve správném formátu."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The length of 'email_address' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Emailová adresa musí mít maximálně {m.Groups[1].Value} {PluralizeChar(int.Parse(m.Groups[1].Value))}. Zadali jste {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}."
        },

        // General.
        new ErrorTranslation
        {
            Pattern = new Regex(@"The admin was not found in the system."),
            Translate = _ => "Admin s touto adresou nebyl nalezen."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The employee was not found in the system."),
            Translate = _ => "Zaměstnanec s touto adresou nebyl nalezen."
        },
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
