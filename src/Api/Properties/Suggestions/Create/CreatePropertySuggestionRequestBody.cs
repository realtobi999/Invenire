using System.Text.Json.Serialization;

namespace Invenire.Api.Properties.Suggestions.Create;

public record CreatePropertySuggestionRequestBody
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("payload")]
    public PropertySuggestionPayloadDto? Payload { get; set; }
}
