using Invenire.Common.Errors;
using System.Text.RegularExpressions;

namespace Invenire.Api.Users.Employees.Login;

public record LoginEmployeeResponse
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
        // Password
        new ErrorTranslation
        {
            Pattern = new Regex(@"'password' must not be empty\."),
            Translate = _ => "Heslo nesmí být prázdné."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The length of 'password' must be at least (\d+) characters\. You entered (\d+) characters\."),
            Translate = m => $"Heslo musí mít alespoň {m.Groups[1].Value} {PluralizeChar(int.Parse(m.Groups[1].Value))}. Zadali jste pouze {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The length of 'password' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Heslo musí mít maximálně {m.Groups[1].Value} {PluralizeChar(int.Parse(m.Groups[1].Value))}. Zadali jste {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}."
        },
        // General.
        new ErrorTranslation
        {
            Pattern = new Regex(@"Invalid credentials\."),
            Translate = _ => "Nesprávné přihlašovací údaje."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"Verification is required to proceed with login\."),
            Translate = _ => "Emailová adresa musí být ověřena před přihlášením."
        },
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


