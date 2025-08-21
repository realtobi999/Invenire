using Invenire.Common.Errors;
using System.Text.RegularExpressions;

namespace Invenire.Api.Users.Employees.Register;

public record RegisterEmployeeResponse
{
    // Errors.

    public static readonly List<ErrorTranslation> ErrorTranslations =
    [
        // First Name
        new ErrorTranslation
        {
            Pattern = new Regex(@"'first_name' must not be empty\."),
            Translate = _ => "Křestní jméno nesmí být prázdné."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"'first_name' is not in the correct format\."),
            Translate = _ => "Křestní jméno musí obsahovat pouze malá nebo velká písmena."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The length of 'first_name' must be at least (\d+) characters\. You entered (\d+) characters\."),
            Translate = m => $"Křestní jméno musí mít alespoň {m.Groups[1].Value} {PluralizeChar(int.Parse(m.Groups[1].Value))}. Zadali jste pouze {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The length of 'first_name' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Křestní jméno musí mít maximálně {m.Groups[1].Value} {PluralizeChar(int.Parse(m.Groups[1].Value))}. Zadali jste {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}."
        },
        // Last Name
        new ErrorTranslation
        {
            Pattern = new Regex(@"'last_name' must not be empty\."),
            Translate = _ => "Příjmení nesmí být prázdné."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"'last_name' is not in the correct format\."),
            Translate = _ => "Příjmení musí obsahovat pouze malá nebo velká písmena."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The length of 'last_name' must be at least (\d+) characters\. You entered (\d+) characters\."),
            Translate = m => $"Příjmení musí mít alespoň {m.Groups[1].Value} {PluralizeChar(int.Parse(m.Groups[1].Value))}. Zadali jste pouze {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The length of 'last_name' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Příjmení musí mít maximálně {m.Groups[1].Value} {PluralizeChar(int.Parse(m.Groups[1].Value))}. Zadali jste {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}."
        },
        // Email Address
        new ErrorTranslation
        {
            Pattern = new Regex(@"'email_address' must not be empty\."),
            Translate = _ => "Emailová adresa nesmí být prázdná."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"'email_address' must be unique among all users\."),
            Translate = _ => "Emailová adresa již byla zaregistrována."
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
            Pattern = new Regex(@"'password' is not in the correct format\."),
            Translate = _ => "Heslo musí mít alespoň jedno velké písmeno a číslici."
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
        // Password Confirm
        new ErrorTranslation
        {
            Pattern = new Regex(@"'password_confirm' must match 'password'\."),
            Translate = _ => "Hesla se musí shodovat."
        },
        // General.
        new ErrorTranslation
        {
            Pattern = new Regex(@"An unexpected internal error occurred\."),
            Translate = _ => "Objevila se nečekaná chyba."
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


