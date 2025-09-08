using System.Text.Json.Serialization;

namespace Invenire.Api.Organizations.Invitations.IndexByEmployee;

public record IndexByEmployeeOrganizationInvitationResponse
{
    [JsonPropertyName("data")]
    public required List<OrganizationInvitationDto> Data { get; set; }

    [JsonPropertyName("limit")]
    public required int Limit { get; set; }

    [JsonPropertyName("offset")]
    public required int Offset { get; set; }

    [JsonPropertyName("total_count")]
    public required int TotalCount { get; set; }
}
