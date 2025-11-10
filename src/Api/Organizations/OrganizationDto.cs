using Invenire.Api.Users.Admin;
using Invenire.Api.Users.Employees;
using System.Text.Json.Serialization;
using Invenire.Api.Organizations.Invitations;
using Invenire.Api.Properties;

namespace Invenire.Api.Organizations;

public record OrganizationDto
{
    [JsonPropertyName("id")]
    public required Guid Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("last_updated_at")]
    public DateTimeOffset? LastUpdatedAt { get; set; }

    [JsonPropertyName("admin")]
    public AdminDto? Admin { get; set; }

    [JsonPropertyName("property")]
    public PropertyDto? Property { get; set; }

    [JsonPropertyName("employees")]
    public List<EmployeeDto>? Employees { get; set; }

    [JsonPropertyName("invitations")]
    public List<OrganizationInvitationDto>? Invitations { get; set; }
}
