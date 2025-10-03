using System.Text.Json.Serialization;

namespace Invenire.Api.Users.Employees.Update;

public record UpdateEmployeeRequestBody
{
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = string.Empty;
}