using System.Text.Json.Serialization;
using Invenire.Api.Users.Employees;

namespace Invenire.Api.Organizations.Invitations;

public class OrganizationInvitationDto
{
    [JsonPropertyName("id")]
    public required Guid Id { get; set; }

    [JsonPropertyName("organization_id")]
    public Guid? OrganizationId { get; set; }

    public OrganizationDto? OrganizationDto { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("last_updated_at")]
    public DateTimeOffset? LastUpdatedAt { get; set; }

    [JsonPropertyName("employee")]
    public required EmployeeDto? Employee { get; set; }
}
