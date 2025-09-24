using System.Text.Json.Serialization;

namespace Invenire.Api.Properties.Scans;

public record CreatePropertyScanRequestBody
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}
