using System.Text.Json.Serialization;

namespace Invenire.Api.Organizations.Create;

public record CreateOrganizationRequestBody
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
