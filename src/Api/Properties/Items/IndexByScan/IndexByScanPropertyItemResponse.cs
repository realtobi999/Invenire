using System.Text.Json.Serialization;

namespace Invenire.Api.Properties.Items.IndexByScan;

public class IndexByScanPropertyItemResponse
{
    [JsonPropertyName("data")]
    public required List<PropertyItemDto> Data { get; set; }

    [JsonPropertyName("limit")]
    public required int Limit { get; set; }

    [JsonPropertyName("offset")]
    public required int Offset { get; set; }

    [JsonPropertyName("total_count")]
    public required int TotalCount { get; set; }
}
