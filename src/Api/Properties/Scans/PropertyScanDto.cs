using System.Text.Json.Serialization;

namespace Invenire.Api.Properties.Scans;

public record PropertyScanDto
{
    [JsonPropertyName("id")]
    public required Guid Id { get; set; }

    [JsonPropertyName("property_id")]
    public Guid? PropertyId { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public required string? Description { get; set; }

    [JsonPropertyName("status")]
    public required PropertyScanStatusDto Status { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("completed_at")]
    public DateTimeOffset? CompletedAt { get; set; }

    [JsonPropertyName("last_updated_at")]
    public DateTimeOffset? LastUpdatedAt { get; init; }

    [JsonPropertyName("scanned_items_summary")]
    public PropertyScanDtoScannedItemsSummary? ScannedItemsSummary { get; set; }
}

public enum PropertyScanStatusDto
{
    COMPLETED,
    IN_PROGRESS,
}

public record PropertyScanDtoScannedItemsSummary
{
    [JsonPropertyName("total_scanned_items")]
    public required int TotalScannedItems { get; set; }

    [JsonPropertyName("total_items_to_scan")]
    public required int TotalItemsToScan { get; set; }
}