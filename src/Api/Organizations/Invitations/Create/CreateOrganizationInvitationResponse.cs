using Invenire.Common.Errors;
using System.Text.RegularExpressions;

namespace Invenire.Api.Organizations.Invitations.Create;

public record CreateOrganizationInvitationResponse
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
        // Employee Email Address
        new ErrorTranslation
        {
            Pattern = new Regex(@"'employee_email_address' is not a valid email address\."),
            Translate = _ => "Emailová adresa není ve správném formátu."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"Either 'employee_email_address' or 'employee_id' must be provided\."),
            Translate = _ => "Emailová adresa nesmí být prázdná."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The length of 'employee_email_address' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Emailová adresa musí mít maximálně {m.Groups[1].Value} {PluralizeChar(int.Parse(m.Groups[1].Value))}. Zadali jste {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}."
        },
        // General.
        new ErrorTranslation
        {
            Pattern = new Regex(@"An unexpected internal error occurred\."),
            Translate = _ => "Objevila se nečekaná chyba."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The employee was not found in the system\."),
            Translate = _ => "Zaměstnanec s touto emailovou adresou neexistuje."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The organization already has a invitation for the employee\."),
            Translate = _ => "Tento zaměstnanec už byl pozvaný."
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


