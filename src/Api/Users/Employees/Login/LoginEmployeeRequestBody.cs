using System.Text.Json.Serialization;

namespace Invenire.Api.Users.Employees.Login;

public record LoginEmployeeRequestBody
{
    [JsonPropertyName("email_address")]
    public string EmailAddress { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}