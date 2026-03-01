using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Invenire.Api.Users.Employees;

public record EmployeeDto
{
    [SetsRequiredMembers]
    public EmployeeDto()
    {
        Id = Guid.Empty;
        OrganizationId = null;
        FirstName = string.Empty;
        LastName = string.Empty;
        FullName = string.Empty;
        EmailAddress = string.Empty;
        CreatedAt = DateTimeOffset.MinValue;
        LastUpdatedAt = null;
    }

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
    public required string EmailAddress { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("last_updated_at")]
    public DateTimeOffset? LastUpdatedAt { get; init; }

    public static EmployeeDto CloneThis(EmployeeDto employee)
    {
        return new EmployeeDto
        {
            Id = employee.Id,
            OrganizationId = employee.OrganizationId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            FullName = employee.FullName,
            EmailAddress = employee.EmailAddress,
            CreatedAt = employee.CreatedAt,
            LastUpdatedAt = employee.LastUpdatedAt
        };
    }

    public virtual bool Equals(EmployeeDto? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Id == other.Id &&
                OrganizationId == other.OrganizationId &&
                FirstName == other.FirstName &&
                LastName == other.LastName &&
                FullName == other.FullName &&
                EmailAddress == other.EmailAddress &&
                CreatedAt == other.CreatedAt &&
                LastUpdatedAt == other.LastUpdatedAt;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, OrganizationId, FirstName, LastName, FullName, EmailAddress, CreatedAt, LastUpdatedAt);
    }
}
