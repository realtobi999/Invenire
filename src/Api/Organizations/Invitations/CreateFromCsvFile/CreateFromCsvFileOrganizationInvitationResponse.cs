using Invenire.Common.Errors;
using System.Text.RegularExpressions;

namespace Invenire.Api.Organizations.Invitations.CreateFromCsvFile;

public class CreateFromCsvFileOrganizationInvitationResponse
{
    public static readonly List<ErrorTranslation> ErrorTranslations =
    [
        // File
        new ErrorTranslation
        {
            Pattern = new Regex(@"'stream' must be readable\."),
            Translate = _ => "Soubor se nepodařilo přečíst."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"'stream' must not be empty\."),
            Translate = _ => "Soubor nesmí být prázdný."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The file is corrupted or in a bad format\."),
            Translate = _ => "Formát souboru je nesprávný. Ujistěte se, že soubor obsahuje platné CSV pozvánky."
        },

        // Invitation - Description
        new ErrorTranslation
        {
            Pattern = new Regex(@"Invitation (.+): The length of 'description' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Pozvánka {NormalizeIdentifier(m.Groups[1].Value)}: Text musí mít maximálně {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}. Zadali jste {m.Groups[3].Value} {PluralizeChar(int.Parse(m.Groups[3].Value))}."
        },

        // Invitation - Employee email address
        new ErrorTranslation
        {
            Pattern = new Regex(@"Invitation (.+): 'employee_email_address' is not a valid email address\."),
            Translate = m => $"Pozvánka {NormalizeIdentifier(m.Groups[1].Value)}: Emailová adresa není ve správném formátu."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"Invitation (.+): Either 'employee_email_address' or 'employee_id' must be provided\."),
            Translate = m => $"Pozvánka {NormalizeIdentifier(m.Groups[1].Value)}: Emailová adresa nesmí být prázdná."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"Invitation (.+): The length of 'employee_email_address' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Pozvánka {NormalizeIdentifier(m.Groups[1].Value)}: Emailová adresa musí mít maximálně {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}. Zadali jste {m.Groups[3].Value} {PluralizeChar(int.Parse(m.Groups[3].Value))}."
        },

        // Employee
        new ErrorTranslation
        {
            Pattern = new Regex(@"The employee was not found in the system\. \(key - (.*)\)"),
            Translate = m => $"Pozvánka {NormalizeIdentifier(m.Groups[1].Value)}: Zaměstnanec s touto emailovou adresou neexistuje."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The employee was not found in the system\."),
            Translate = _ => "Zaměstnanec s touto emailovou adresou neexistuje."
        },

        // Invitation conflicts
        new ErrorTranslation
        {
            Pattern = new Regex(@"The organization already has a invitation for the employee\. \(key - (.*)\)"),
            Translate = m => $"Pozvánka {NormalizeIdentifier(m.Groups[1].Value)}: Tento zaměstnanec už byl pozvaný."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The organization already has a invitation for the employee\."),
            Translate = _ => "Tento zaměstnanec už byl pozvaný."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The organization's number of invitations exceeded the limit \(max (\d+)\)\."),
            Translate = m => $"Počet pozvánek překročil povolený limit (max {m.Groups[1].Value})."
        },

        // Admin / Organization
        new ErrorTranslation
        {
            Pattern = new Regex(@"The admin was not found in the system\."),
            Translate = _ => "Administrátor nebyl v systému nalezen."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The admin doesn't own a organization\."),
            Translate = _ => "Administrátor nemá vytvořenou organizaci."
        },

        // General
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

    private static string NormalizeIdentifier(string value)
    {
        return string.IsNullOrWhiteSpace(value) || value == "MISSING_IDENTIFIER"
            ? "(bez emailové adresy)"
            : $"({value})";
    }
}
