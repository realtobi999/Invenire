using System.Text.Json.Serialization;

namespace Invenire.Api.Users.Admin.Update;

public record UpdateAdminRequestBody
{
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = string.Empty;
}
