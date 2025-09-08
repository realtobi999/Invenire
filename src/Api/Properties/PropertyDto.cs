using System.Text.Json.Serialization;

namespace Invenire.Api.Properties;

public record PropertyDto
{
    [JsonPropertyName("id")]
    public required Guid Id { get; set; }

    [JsonPropertyName("organization_id")]
    public required Guid? OrganizationId { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("last_updated_at")]
    public required DateTimeOffset? LastUpdatedAt { get; set; }

    [JsonPropertyName("items_summary")]
    public PropertyDtoItemsSummary? ItemsSummary { get; set; }

    [JsonPropertyName("scans_summary")]
    public PropertyDtoScansSummary? ScansSummary { get; set; }

    [JsonPropertyName("suggestions_summary")]
    public PropertyDtoSuggestionsSummary? SuggestionsSummary { get; set; }
}

public record PropertyDtoItemsSummary
{
    [JsonPropertyName("total_items")]
    public required int TotalItems { get; set; }

    [JsonPropertyName("total_value")]
    public required double TotalValue { get; set; }

    [JsonPropertyName("average_price")]
    public required double AveragePrice { get; set; }

    [JsonPropertyName("average_age")]
    public required double AverageAge { get; set; }
}

public record PropertyDtoScansSummary
{
    [JsonPropertyName("total_scans")]
    public required int TotalScans { get; set; }
}

public class PropertyDtoSuggestionsSummary
{
    [JsonPropertyName("total_suggestions")]
    public required int TotalSuggestions { get; set; }
}