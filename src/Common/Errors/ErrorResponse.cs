using System.Text.Json.Serialization;

namespace Invenire.Common.Errors;

public record ErrorResponse
{
    [JsonPropertyName("status")]
    public required int Status { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("detail")]
    public required string Detail { get; init; }

    [JsonPropertyName("errors")]
    public List<string>? Errors { get; init; }

    [JsonPropertyName("instance")]
    public required string Instance { get; init; }
}
