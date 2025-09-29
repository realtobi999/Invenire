using System.Text.Json.Serialization;

namespace Invenire.Api.Properties.Scans.Update;

public record UdpatePropertyScanRequestBody
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string? Description { get; set; } = string.Empty;
}