using System.Text.Json.Serialization;

namespace Invenire.Api.Properties.Items.GenerateCodes;

public record GenerateCodesPropertyItemsRequest
{
    [JsonPropertyName("ids")]
    public required List<Guid> Ids { get; init; }
}
