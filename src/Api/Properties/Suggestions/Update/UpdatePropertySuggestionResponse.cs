using Invenire.Common.Errors;
using System.Text.RegularExpressions;

namespace Invenire.Api.Properties.Suggestions.Update;

public record UpdatePropertySuggestionResponse
{
    public static readonly List<ErrorTranslation> ErrorTranslations =
    [
        // Description.
        new ErrorTranslation
        {
            Pattern = new Regex(@"The length of 'description' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Název musí mít maximálně {m.Groups[1].Value} {PluralizeChar(int.Parse(m.Groups[1].Value))}. Zadali jste {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}."
        },

        // Items.Inventory number
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

        // Items.Registration number
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

        // Items.Name
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

        // Items.Price
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): 'price' must be greater than or equal to '0'\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Cena musí být větší nebo rovna 0."
        },

        // Items.Serial number
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): The length of 'serial_number' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Sériové číslo musí mít maximálně {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}. Zadali jste {m.Groups[3].Value} {PluralizeChar(int.Parse(m.Groups[3].Value))}."
        },

        // Items.Date of purchase
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): 'date_of_purchase' must not be empty\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Datum pořízení nesmí být prázdné."
        },

        // Items.Location (room / building / additional note)
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

        // Items.Description
        new ErrorTranslation
        {
            Pattern = new Regex(@"Item (.+): The length of 'description' must be (\d+) characters or fewer\. You entered (\d+) characters\."),
            Translate = m => $"Položka {NormalizeInventoryNumber(m.Groups[1].Value)}: Popis musí mít maximálně {m.Groups[2].Value} {PluralizeChar(int.Parse(m.Groups[2].Value))}. Zadali jste {m.Groups[3].Value} {PluralizeChar(int.Parse(m.Groups[3].Value))}."
        },

        // Items.Document number
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
        // Fallback translation for any unmatched errors.
        new ErrorTranslation
        {
            Pattern = new Regex(@".*"),
            Translate = _ => "Objevila se nečekaná chyba. Zkuste to prosím později."
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
