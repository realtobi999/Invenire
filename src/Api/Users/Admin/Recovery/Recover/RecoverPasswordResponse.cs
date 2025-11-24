using System.Text.RegularExpressions;
using Invenire.Common.Errors;

namespace Invenire.Api.Users.Admin.Recovery.Recover;

public record RecoverPasswordResponse
{
    public static readonly List<ErrorTranslation> ErrorTranslations =
    [
        // Password
        new ErrorTranslation
        {
            Pattern = new Regex(@"'new_password' must not be empty\."),
            Translate = _ => "Heslo nesmí být prázdné."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"'new_password' is not in the correct format\."),
            Translate = _ => "Heslo musí mít alespoň jedno velké písmeno a číslici."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The length of 'new_password' must be at least (\d+) characters\. You entered (\d+) characters\."),
            Translate = m => $"Heslo musí mít alespoň {m.Groups[1].Value} {PluralizeChar(int.Parse(m.Groups[1].Value))}. Zadali jste pouze {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The length of 'new_password' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Heslo musí mít maximálně {m.Groups[1].Value} {PluralizeChar(int.Parse(m.Groups[1].Value))}. Zadali jste {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}."
        },
        
        // Password Confirm
        new ErrorTranslation
        {
            Pattern = new Regex(@"'new_password_confirm' must match 'new_password'\."),
            Translate = _ => "Hesla se musí shodovat."
        },

        // General
        new ErrorTranslation
        {
            Pattern = new Regex(@".*"),
            Translate = _ => "Objevila se nečekaná chyba. Zkuste to prosím později."
        }
    ];

    private static string PluralizeChar(int count)
    {
        return count switch
        {
            0 => "znaků",
            1 => "znak",
            >= 2 and <= 4 => "znaky",
            _ => "znaků"
        };
    }
}
