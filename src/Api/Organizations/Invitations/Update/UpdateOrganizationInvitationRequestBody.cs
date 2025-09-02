using System.Text.Json.Serialization;

namespace Invenire.Api.Organizations.Invitations.Update;

public record UpdateOrganizationInvitationRequestBody
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
