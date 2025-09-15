using System.Text.Json.Serialization;

namespace Invenire.Api.Properties.Items.Delete;

public record DeletePropertyItemsRequest
{
    [JsonPropertyName("ids")]
    public required List<Guid> Ids { get; init; }
}
