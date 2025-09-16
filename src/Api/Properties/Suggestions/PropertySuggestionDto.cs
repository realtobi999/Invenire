using Invenire.Api.Users.Employees;
using System.Text.Json.Serialization;
using Invenire.Api.Properties.Items.Create;
using Invenire.Api.Properties.Items.Update;

namespace Invenire.Api.Properties.Suggestions;

public record PropertySuggestionDto
{
    [JsonPropertyName("id")]
    public required Guid Id { get; set; }

    [JsonPropertyName("employee_id")]
    public required Guid? EmployeeId { get; set; }

    [JsonPropertyName("employee")]
    public EmployeeDto Employee { get; set; } = new EmployeeDto();

    [JsonPropertyName("property_id")]
    public required Guid? PropertyId { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public required string? Description { get; set; }

    [JsonPropertyName("feedback")]
    public required string? Feedback { get; set; }

    [JsonPropertyName("payload")]
    public PropertySuggestionDtoPayload? Payload { get; set; }

    [JsonPropertyName("status")]
    public required PropertySuggestionDtoStatus Status { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("resolved_at")]
    public required DateTimeOffset? ResolvedAt { get; set; }

    [JsonPropertyName("last_updated_at")]
    public required DateTimeOffset? LastUpdatedAt { get; set; }
}

public enum PropertySuggestionDtoStatus
{
    APPROVED = 0,
    PENDING = 1,
    DECLINED = 2,
}

public record PropertySuggestionDtoPayload
{
    [JsonPropertyName("delete_commands")]
    public required List<Guid> DeleteCommands { get; set; } = [];

    [JsonPropertyName("create_commands")]
    public required List<CreatePropertyItemRequest> CreateCommands { get; set; } = [];

    [JsonPropertyName("update_commands")]
    public required List<UpdatePropertyItemRequest> UpdateCommands { get; set; } = [];
}
