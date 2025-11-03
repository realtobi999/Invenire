using System.Text.Json.Serialization;
using Invenire.Api.Properties.Items.Create;
using Invenire.Api.Properties.Items.Update;
using Invenire.Api.Users.Employees;

namespace Invenire.Api.Properties.Suggestions;

public record PropertySuggestionDto
{
    [JsonPropertyName("id")]
    public required Guid Id { get; set; }

    [JsonPropertyName("employee_id")]
    public Guid? EmployeeId { get; set; }

    [JsonPropertyName("employee")]
    public EmployeeDto Employee { get; set; } = new EmployeeDto();

    [JsonPropertyName("property_id")]
    public Guid? PropertyId { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("feedback")]
    public string? Feedback { get; set; }

    [JsonPropertyName("payload")]
    public PropertySuggestionPayloadDto? Payload { get; set; }

    [JsonPropertyName("status")]
    public required PropertySuggestionDtoStatus Status { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("resolved_at")]
    public DateTimeOffset? ResolvedAt { get; set; }

    [JsonPropertyName("last_updated_at")]
    public DateTimeOffset? LastUpdatedAt { get; set; }
}

public enum PropertySuggestionDtoStatus
{
    APPROVED = 0,
    PENDING = 1,
    DECLINED = 2,
}

public record PropertySuggestionPayloadDto
{
    [JsonPropertyName("delete_commands")]
    public required List<Guid> DeleteCommands { get; set; } = [];

    [JsonPropertyName("create_commands")]
    public required List<CreatePropertyItemRequest> CreateCommands { get; set; } = [];

    [JsonPropertyName("update_commands")]
    public required List<UpdatePropertyItemRequestBody> UpdateCommands { get; set; } = [];
}
