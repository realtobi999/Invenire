using System.Text.Json.Serialization;

namespace Invenire.Api.Properties.Suggestions.Update;

public record UpdatePropertySuggestionRequestBody
{
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("payload")]
    public PropertySuggestionPayloadDto? Payload { get; set; }
}
