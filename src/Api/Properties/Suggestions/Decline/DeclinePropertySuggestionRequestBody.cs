using System.Text.Json.Serialization;

namespace Invenire.Api.Properties.Suggestions.Decline;

public record DeclinePropertySuggestionRequestBody
{
    [JsonPropertyName("feedback")]
    public string? Feedback { get; set; }
}
