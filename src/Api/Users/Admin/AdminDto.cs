using System.Text.Json.Serialization;

namespace Invenire.Api.Users.Admin;

public record AdminDto
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("organization_id")]
    public Guid? OrganizationId { get; init; }

    [JsonPropertyName("first_name")]
    public required string FirstName { get; init; }

    [JsonPropertyName("last_name")]
    public required string LastName { get; init; }

    [JsonPropertyName("full_name")]
    public required string FullName { get; init; }

    [JsonPropertyName("email_address")]
    public required string EmailAddress { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("last_updated_at")]
    public DateTimeOffset? LastUpdatedAt { get; init; }
}
