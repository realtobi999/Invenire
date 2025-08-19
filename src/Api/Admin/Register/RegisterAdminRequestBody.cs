using System.Text.Json.Serialization;

namespace Invenire.Api.Admin.Register;

public class RegisterAdminRequestBody
{
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("email_address")]
    public string EmailAddress { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    [JsonPropertyName("password_confirm")]
    public string PasswordConfirm { get; set; } = string.Empty;
}