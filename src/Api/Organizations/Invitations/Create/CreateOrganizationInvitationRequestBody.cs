using System.Text.Json.Serialization;

namespace Invenire.Api.Organizations.Invitations.Create;

public record CreateOrganizationInvitationRequestBody
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("employee_email_address")]
    public string? EmployeeEmailAddress { get; set; }
}