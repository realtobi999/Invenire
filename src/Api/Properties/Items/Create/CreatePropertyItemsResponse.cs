using Invenire.Common.Errors;
using System.Text.RegularExpressions;

namespace Invenire.Api.Properties.Items.Create;

public record CreatePropertyItemsResponse
{
    public static readonly List<ErrorTranslation> ErrorTranslations =
    [

        // Items
        new ErrorTranslation
        {
            Pattern = new Regex(@"'items' must not be empty\."),
            Translate = _ => "Seznam položek nesmí být prázdný."
        },

        // Employee
        new ErrorTranslation
        {
            Pattern = new Regex(@"The employee was not found in the system\. \(key - (.+)\)"),
            Translate = m => $"Zaměstnanec {NormalizeInventoryNumber(m.Groups[1].Value)}: Zaměstnanec s tímto identifikátorem nebyl nalezen."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"The employee isn't part of the organization\. \(key - (.+)\)"),
            Translate = m => $"Zaměstnanec {NormalizeInventoryNumber(m.Groups[1].Value)}: Zaměstnanec s tímto identifikátorem není součástí vaší organizace."
        },

        // Inventory number
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): 'inventory_number' must not be empty\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Inventarizační číslo nesmí být prázdné."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): The length of 'inventory_number' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Inventarizační číslo musí mít maximálně {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}. Zadali jste {m.Groups[3].Value} {PluralizeChar(int.Parse(m.Groups[3].Value))}."
        },

        // Registration number
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): 'registration_number' must not be empty\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Evidenční číslo nesmí být prázdné."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): The length of 'registration_number' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Evidenční číslo musí mít maximálně {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}. Zadali jste {m.Groups[3].Value} {PluralizeChar(int.Parse(m.Groups[3].Value))}."
        },

        // Name
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): 'name' must not be empty\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Název nesmí být prázdný."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): The length of 'name' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Název musí mít maximálně {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}. Zadali jste {m.Groups[3].Value} {PluralizeChar(int.Parse(m.Groups[3].Value))}."
        },

        // Price
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): 'price' must be greater than or equal to '0'\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Cena musí být větší nebo rovna 0."
        },

        // Serial number
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): The length of 'serial_number' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Sériové číslo musí mít maximálně {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}. Zadali jste {m.Groups[3].Value} {PluralizeChar(int.Parse(m.Groups[3].Value))}."
        },

        // Date of purchase
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): 'date_of_purchase' must not be empty\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Datum pořízení nesmí být prázdné."
        },

        // Location (room / building / additional note)
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): 'room' must not be empty\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Místnost nesmí být prázdná."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): The length of 'room' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Místnost musí mít maximálně {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}. Zadali jste {m.Groups[3].Value} {PluralizeChar(int.Parse(m.Groups[3].Value))}."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): 'building' must not be empty\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Budova nesmí být prázdná."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): The length of 'building' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Budova musí mít maximálně {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}. Zadali jste {m.Groups[3].Value} {PluralizeChar(int.Parse(m.Groups[3].Value))}."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): The length of 'additional_note' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Poznámka k lokaci musí mít maximálně {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}. Zadali jste {m.Groups[3].Value} {PluralizeChar(int.Parse(m.Groups[3].Value))}."
        },

        // Description
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): The length of 'description' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Popis musí mít maximálně {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}. Zadali jste {m.Groups[3].Value} {PluralizeChar(int.Parse(m.Groups[3].Value))}."
        },

        // Document number
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): 'document_number' must not be empty\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Číslo dokladu nesmí být prázdné."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): The length of 'document_number' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Číslo dokladu musí mít maximálně {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}. Zadali jste {m.Groups[3].Value} {PluralizeChar(int.Parse(m.Groups[3].Value))}."
        },

        // General
        new ErrorTranslation
        {
            Pattern = new Regex(@"An unexpected internal error occurred\."),
            Translate = _ => "Objevila se nečekaná chyba."
        },
        new ErrorTranslation
        {
            Pattern = new Regex(@"Request body is missing or invalid\."),
            Translate = _ => "Formát souboru je nesprávný. Ujistěte se, že všechny povinné pole jsou vyplněny."
        }

    ];

    private static string PluralizeChar(int count)
    {
        if (count == 1) return "znak";
        else if (count >= 2 && count <= 4) return "znaky";
        return "znaků";
    }

    private static string NormalizeInventoryNumber(string value)
    {
        return value == "MISSING_INVENTORY_NUMBER"
            ? "(bez inventarizačního čísla)"
            : $"({value})";
    }
}
