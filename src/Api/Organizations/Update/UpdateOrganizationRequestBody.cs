using System.Text.Json.Serialization;

namespace Invenire.Api.Organizations.Update;

public record UpdateOrganizationRequestBody
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
