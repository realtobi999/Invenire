using System.Text.Json.Serialization;

namespace Invenire.Api.Properties.Suggestions.IndexByAdmin;

public class IndexByAdminPropertySuggestionResponse
{
    [JsonPropertyName("data")]
    public required List<PropertySuggestionDto> Data { get; set; }

    [JsonPropertyName("limit")]
    public required int Limit { get; set; }

    [JsonPropertyName("offset")]
    public required int Offset { get; set; }

    [JsonPropertyName("total_count")]
    public required int TotalCount { get; set; }
}
